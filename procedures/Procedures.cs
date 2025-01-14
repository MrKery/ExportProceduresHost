
using System;
using System.Collections.Generic;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace procedures
{
    public partial class Procedures : Form
    {
        private string sql;
        string savedPath = "path.txt";
        string hostName = SystemInformation.ComputerName;
        string searchText;
        
        BindingSource bs = new BindingSource();

        DataTable dataTable = new DataTable();
        DataTable dtSchemas = new DataTable();
        DataTable dtDbase = new DataTable();

        public Procedures()
        {
            InitializeComponent();
            sql = ConfigurationManager.ConnectionStrings["master"].ConnectionString;
            LoadDbNames(sql);
            if (File.Exists(savedPath))
            {
                path.Text = File.ReadAllText(savedPath);
            }
            else
            {
                path.Text = "";
            }

            dataProcedures.AutoGenerateColumns = false;
            searchSchemas.Enabled = false;
            rbtnAll.Enabled = false;
            rbtnHost.Enabled = false;
        }

        private void btnEditPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.Description = "Выберите путь для сохранения файлов";

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = folderBrowserDialog.SelectedPath;
                path.Text = filePath;

                File.WriteAllText(savedPath, filePath);
            }
        }

        private void SqlConnect(string sql, string query, DataTable dtTableName)
        {
            Connection sqlConnection = new Connection(sql);
            try
            {
                sqlConnection.OpenConnection();

                SqlCommand command = sqlConnection.CreateCommand(query);

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                dataAdapter.Fill(dtTableName);

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sqlConnection.CloseConnection();
            }
        }

        private void LoadDbNames(string sql)
        {
            string query = "select database_id as id, name from sys.databases where name not in ('beta', 'dbase3', 'model', 'msdb', 'tempdb') order by name";
			//в перечислении query указать базы, которые не используются
            SqlConnect(sql, query, dtDbase);
            DataRow row = dtDbase.NewRow();
            row["id"] = 0;
            row["name"] = "";
            dtDbase.Rows.InsertAt(row, 0);
            dbName.DataSource = dtDbase;
        }

        private void LoadSchNames(string sql, string dbaseName)
        {
            string query = $"select schema_id as id, [name] from [{dbaseName}].[sys].[schemas]";

            dtSchemas.Clear();
            SqlConnect(sql, query, dtSchemas);
            DataRow row = dtSchemas.NewRow();
            row["id"] = 0;
            row["name"] = "";
            dtSchemas.Rows.InsertAt(row, 0);
            schemaName.DataSource = dtSchemas;
            searchSchemas.Enabled = true;
            rbtnHost.Enabled = true;
            rbtnAll.Enabled = true;
        }

        private void dbName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (dbName.SelectedValue.ToString() != "")
            {
                string name = dbName.SelectedValue.ToString();
                LoadSchNames(sql, name);
                //DeleteNullRow(dtDbase);
            }
            else
            {
                dtSchemas.Clear();
            }

        }


        private void LoadData()
        {
            dataTable.Clear();
            string query = default;
            query = $"set language Russian; WITH RankedData AS (SELECT HostName, definition, name, create_date, modify_date, ROW_NUMBER() OVER (ORDER BY modify_date DESC) as rn FROM (select '' as HostName, M.definition, O.name, O.create_date, O.modify_date from    {dbName.SelectedValue.ToString()}.sys.objects as O left join  {dbName.SelectedValue.ToString()}.sys.sql_modules as M on O.object_id = M.object_id left join {dbName.SelectedValue.ToString()}.sys.schemas as S on S.schema_id = O.schema_id where type = 'P' and S.name = '{schemaName.SelectedValue.ToString()}' and modify_date between '{Convert.ToDateTime(dateModifiedFrom.Text)}' and DATEADD(day, 1, '{Convert.ToDateTime(dateModifiedTo.Text)}') union select distinct I.HostName, M.definition, O.name, O.create_date, O.modify_date from  {dbName.SelectedValue.ToString()}.sys.traces T CROSS Apply ::fn_trace_gettable(T.path, T.max_files) I Join {dbName.SelectedValue.ToString()}.sys.trace_events E On  I.eventclass = E.trace_event_id left join {dbName.SelectedValue.ToString()}.sys.objects as O on I.ObjectID = O.object_id left join  {dbName.SelectedValue.ToString()}.sys.sql_modules as M on O.object_id = M.object_id left join {dbName.SelectedValue.ToString()}.sys.schemas as S on S.schema_id = O.schema_id where  T.id = 1 And E.name = 'Object:Altered' and  O.type = 'P' and S.name = '{schemaName.SelectedValue.ToString()}' and modify_date between '{Convert.ToDateTime(dateModifiedFrom.Text)}' and DATEADD(day, 1, '{Convert.ToDateTime(dateModifiedTo.Text)}')) a), DataWithLead AS (SELECT HostName, definition, name, create_date, modify_date, rn, LEAD(HostName, 1, NULL) OVER (ORDER BY modify_date DESC) as NextHostName, LEAD(name, 1, NULL) OVER (ORDER BY modify_date DESC) as NextName FROM RankedData) SELECT DISTINCT CASE  WHEN HostName = '' AND name = NextName THEN NextHostName ELSE HostName END as HostName, definition, name, create_date, modify_date FROM DataWithLead WHERE  HostName IS NOT NULL order by modify_date desc";
            SqlConnect(sql, query, dataTable);
            dataProcedures.DataSource = dataTable;
            SetFilter(true);

        }


        private void schemaName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string dbaseChosen = dbName.SelectedValue?.ToString();
            string schemaChosen = schemaName.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(dbaseChosen) && !string.IsNullOrEmpty(schemaChosen))
            {
                LoadData();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!CheckAnyCheckBoxSelected())
            {
                MessageBox.Show("Выберите хотя бы одно значение.", "Ошибка выгрузки", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            Dictionary<string, string> alteredProc = new Dictionary<string, string>();
            Dictionary<string, string> createdProc = new Dictionary<string, string>();


            foreach (DataGridViewRow row in dataProcedures.Rows)
            {

                bool isAltered = Convert.ToBoolean(row.Cells["c_Alter"].Value);
                bool isCreated = Convert.ToBoolean(row.Cells["c_Create"].Value);

                if (isAltered)
                {
                    alteredProc.Add(row.Cells["c_Proc"].Value.ToString(), row.Cells["definition"].Value.ToString());

                }
                if (isCreated)
                {
                    createdProc.Add(row.Cells["c_Proc"].Value.ToString(), row.Cells["definition"].Value.ToString());

                }
            }

            string newText;

            DialogResult dialog = MessageBox.Show("Выгрузить выбранные процедуры?", "Выгрузка", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (dialog == DialogResult.Yes)
            {
                ClearCheckBoxes();
                bool niceSaved = false;
                foreach (KeyValuePair<string, string> kvp in alteredProc)
                {
                    string text = kvp.Value;
                    string nameProc = kvp.Key;

                    if (text.Contains("CREATE PROCEDURE"))
                    {
                        newText = text.Replace("CREATE PROCEDURE", "ALTER PROCEDURE");
                    }
                    else if (text.Contains("CREATE   proc"))
                    {
                        newText = text.Replace("CREATE   proc", "ALTER PROCEDURE");
                    }
                    else if (text.Contains("CREATE proc"))
                    {
                        newText = text.Replace("CREATE proc", "ALTER PROCEDURE");
                    }
                    else
                    {
                        newText = text;
                    }

                    string name = $"ALTER PROCEDURE [{schemaName.Text}].[{nameProc}]";
                    if (SaveProcToFile(newText, name))
                    {
                        niceSaved = true;
                    }

                }

                foreach (KeyValuePair<string, string> kvp in createdProc)
                {
                    string text = kvp.Value;
                    string nameProc = kvp.Key;

                    newText = text;
                    string name = $"CREATE PROCEDURE [{schemaName.Text}].[{nameProc}]";

                    if (SaveProcToFile(newText, name))
                    {
                        niceSaved = true;
                    }

                }

                if (niceSaved)
                {
                    MessageBox.Show($"Выгрузка завершена по пути {path.Text}");
                }


            }

        }

        private void ClearCheckBoxes()
        {
            foreach (DataGridViewRow row in dataProcedures.Rows)
            {
                row.Cells["c_Alter"].Value = false;
                row.Cells["c_Create"].Value = false;
            }
        }


        private bool SaveProcToFile(string value, string nameProc)
        {
            string pathF = $"{path.Text}\\{nameProc}.sql";
            if (File.Exists(savedPath))
            {
                File.WriteAllText(pathF, value);
                return true;
            }
            else
            {
                MessageBox.Show("Сначала задайте путь для сохранения файлы");
                return false;
            }
        }


        private void dateModified_ValueChanged(object sender, EventArgs e)
        {
            CheckCalendar();
            string dbaseChosen = dbName.SelectedValue?.ToString();
            string schemaChosen = schemaName.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(dbaseChosen) && !string.IsNullOrEmpty(schemaChosen))
            {
                LoadData();
            }
        }

        private void dateModifiedTo_ValueChanged(object sender, EventArgs e)
        {
            CheckCalendar();
            string dbaseChosen = dbName.SelectedValue?.ToString();
            string schemaChosen = schemaName.SelectedValue?.ToString();
            if (!string.IsNullOrEmpty(dbaseChosen) && !string.IsNullOrEmpty(schemaChosen))
            {
                LoadData();
            }
        }

        private void CheckCalendar()
        {
            if (dateModifiedTo.Value < dateModifiedFrom.Value)
            {
                dateModifiedFrom.Value = dateModifiedTo.Value;
            }
            else if (dateModifiedFrom.Value > dateModifiedTo.Value)
            {
                dateModifiedTo.Value = dateModifiedFrom.Value;
            }
        }

        private void dataProcedures_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) { return; }

            if (dataProcedures.Columns[e.ColumnIndex].Name == "c_Create" || dataProcedures.Columns[e.ColumnIndex].Name == "c_Alter")
            {
                bool checkBoxValue = Convert.ToBoolean(dataProcedures.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);

                if (dataProcedures.Columns[e.ColumnIndex].Name == "c_Create")
                {
                    if (checkBoxValue)
                    {
                        dataProcedures.Rows[e.RowIndex].Cells["c_Alter"].Value = false;
                    }
                }

                else if (dataProcedures.Columns[e.ColumnIndex].Name == "c_Alter")
                {
                    if (checkBoxValue)
                    {
                        dataProcedures.Rows[e.RowIndex].Cells["c_Create"].Value = false;
                    }
                }
            }
        }

        private void dataProcedures_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataProcedures.IsCurrentCellDirty)
            {
                dataProcedures.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private bool CheckAnyCheckBoxSelected()
        {
            foreach (DataGridViewRow row in dataProcedures.Rows)
            {
                bool checkAltered = Convert.ToBoolean(row.Cells["c_Alter"].Value);
                bool checkCreated = Convert.ToBoolean(row.Cells["c_Create"].Value);

                if (checkAltered || checkCreated)
                {
                    return true;
                }
            }

            return false;
        }

        private void searchSchemas_TextChanged(object sender, EventArgs e)
        {
            searchSchemas.SelectionStart = searchSchemas.Text.Length;
            searchText = checkText(searchSchemas.Text.ToLower());

        }

        private void searchSchemas_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(searchText) && e.KeyCode == Keys.Enter)
            {
                dtSchemas.DefaultView.RowFilter = $"name LIKE '%{searchText}%'";
                string dbaseChosen = dbName.SelectedValue?.ToString();
                string schemaChosen = schemaName.SelectedValue?.ToString();
                if (!string.IsNullOrEmpty(dbaseChosen) && !string.IsNullOrEmpty(schemaChosen))
                {
                    LoadData();
                }
            }
            else
            {
                string name = dbName.SelectedValue.ToString();
                LoadSchNames(sql, name);
            }
        }

        private string checkText(string text)
        {

            char[] badChars = new char[] { '.', '*', '/', '%', '+', '$', '[', ']', '"', '\'', ' ' };
            foreach (char ch in badChars)
            {
                text = text.Replace(ch.ToString(), "");

            }
            return text;

        }

        private void searchSchemas_Enter(object sender, EventArgs e)
        {
            searchSchemas.Clear();
            searchSchemas.ForeColor = Color.Black;
        }

        private void rbtnHost_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnHost.Checked)
            {
                SetFilter(false);
            }
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnAll.Checked)
            {
                SetFilter(true);
            }
        }

        private void SetFilter(bool isAll)
        {
            
            bs.DataSource = dataTable.DefaultView;
            dataProcedures.DataSource = bs;
            try
            {
                bs.Filter = isAll ? "" : $"HostName = '{hostName}'";
            }
            catch { }

        }

        private void dataProcedures_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataProcedures.Rows[e.RowIndex].Selected)
            {
                Rectangle r = e.RowBounds;
                 
                ControlPaint.DrawBorder(e.Graphics, r, Color.Violet, 2, ButtonBorderStyle.Solid, Color.Violet, 2, ButtonBorderStyle.Solid, Color.DarkViolet, 2, ButtonBorderStyle.Solid, Color.DarkViolet, 2, ButtonBorderStyle.Solid);
            }
        }
    }
}