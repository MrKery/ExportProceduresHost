using System;
using System.Drawing;

namespace procedures
{
    partial class Procedures
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Procedures));
            this.dbName = new System.Windows.Forms.ComboBox();
            this.schemaName = new System.Windows.Forms.ComboBox();
            this.dateModifiedFrom = new System.Windows.Forms.DateTimePicker();
            this.dataProcedures = new System.Windows.Forms.DataGridView();
            this.path = new System.Windows.Forms.TextBox();
            this.btnEditPath = new System.Windows.Forms.Button();
            this.txtModified = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateModifiedTo = new System.Windows.Forms.DateTimePicker();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.searchSchemas = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblHost = new System.Windows.Forms.Label();
            this.rbtnHost = new System.Windows.Forms.RadioButton();
            this.rbtnAll = new System.Windows.Forms.RadioButton();
            this.lblAll = new System.Windows.Forms.Label();
            this.c_Proc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_HostName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEdit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.definition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_Create = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.c_Alter = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataProcedures)).BeginInit();
            this.SuspendLayout();
            // 
            // dbName
            // 
            this.dbName.DisplayMember = "name";
            this.dbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dbName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dbName.FormattingEnabled = true;
            this.dbName.Location = new System.Drawing.Point(12, 12);
            this.dbName.Name = "dbName";
            this.dbName.Size = new System.Drawing.Size(121, 21);
            this.dbName.TabIndex = 0;
            this.dbName.ValueMember = "name";
            this.dbName.SelectionChangeCommitted += new System.EventHandler(this.dbName_SelectionChangeCommitted);
            // 
            // schemaName
            // 
            this.schemaName.DisplayMember = "name";
            this.schemaName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.schemaName.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.schemaName.FormattingEnabled = true;
            this.schemaName.Location = new System.Drawing.Point(12, 39);
            this.schemaName.Name = "schemaName";
            this.schemaName.Size = new System.Drawing.Size(121, 21);
            this.schemaName.TabIndex = 1;
            this.schemaName.ValueMember = "name";
            this.schemaName.SelectionChangeCommitted += new System.EventHandler(this.schemaName_SelectionChangeCommitted);
            // 
            // dateModifiedFrom
            // 
            this.dateModifiedFrom.CalendarFont = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateModifiedFrom.Location = new System.Drawing.Point(295, 12);
            this.dateModifiedFrom.Name = "dateModifiedFrom";
            this.dateModifiedFrom.Size = new System.Drawing.Size(152, 22);
            this.dateModifiedFrom.TabIndex = 3;
            this.dateModifiedFrom.Value = new System.DateTime(2024, 8, 24, 12, 59, 27, 482);
            this.dateModifiedFrom.ValueChanged += new System.EventHandler(this.dateModified_ValueChanged);
            // 
            // dataProcedures
            // 
            this.dataProcedures.AllowUserToAddRows = false;
            this.dataProcedures.AllowUserToDeleteRows = false;
            this.dataProcedures.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataProcedures.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataProcedures.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataProcedures.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_Proc,
            this.c_HostName,
            this.dateEdit,
            this.definition,
            this.c_Create,
            this.c_Alter});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataProcedures.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataProcedures.Location = new System.Drawing.Point(12, 75);
            this.dataProcedures.Name = "dataProcedures";
            this.dataProcedures.RowHeadersVisible = false;
            this.dataProcedures.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataProcedures.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataProcedures.Size = new System.Drawing.Size(435, 227);
            this.dataProcedures.TabIndex = 4;
            this.dataProcedures.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataProcedures_CellValueChanged);
            this.dataProcedures.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataProcedures_CurrentCellDirtyStateChanged);
            this.dataProcedures.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataProcedures_RowPostPaint);
            // 
            // path
            // 
            this.path.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.path.Location = new System.Drawing.Point(12, 311);
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Size = new System.Drawing.Size(239, 22);
            this.path.TabIndex = 5;
            // 
            // btnEditPath
            // 
            this.btnEditPath.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEditPath.Location = new System.Drawing.Point(257, 310);
            this.btnEditPath.Name = "btnEditPath";
            this.btnEditPath.Size = new System.Drawing.Size(35, 23);
            this.btnEditPath.TabIndex = 6;
            this.btnEditPath.Text = "...";
            this.toolTip1.SetToolTip(this.btnEditPath, "Выбрать путь сохранения");
            this.btnEditPath.UseVisualStyleBackColor = true;
            this.btnEditPath.Click += new System.EventHandler(this.btnEditPath_Click);
            // 
            // txtModified
            // 
            this.txtModified.AutoSize = true;
            this.txtModified.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtModified.Location = new System.Drawing.Point(272, 16);
            this.txtModified.Name = "txtModified";
            this.txtModified.Size = new System.Drawing.Size(18, 15);
            this.txtModified.TabIndex = 8;
            this.txtModified.Text = "С:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(273, 15);
            this.label1.TabIndex = 10;
            this.label1.Text = "Для выбора CREATE нажми галочку в колонке С";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(262, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "ДО:";
            // 
            // dateModifiedTo
            // 
            this.dateModifiedTo.CalendarFont = new System.Drawing.Font("SimSun", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateModifiedTo.Location = new System.Drawing.Point(295, 43);
            this.dateModifiedTo.Name = "dateModifiedTo";
            this.dateModifiedTo.Size = new System.Drawing.Size(152, 22);
            this.dateModifiedTo.TabIndex = 11;
            this.dateModifiedTo.ValueChanged += new System.EventHandler(this.dateModifiedTo_ValueChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackgroundImage = global::procedures.Properties.Resources.free_icon_folder_7477092;
            this.btnSave.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Location = new System.Drawing.Point(392, 322);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 46);
            this.btnSave.TabIndex = 9;
            this.toolTip1.SetToolTip(this.btnSave, "Выгрузить данные");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "Для выбора ALTER нажми галочку в колонке A";
            // 
            // searchSchemas
            // 
            this.searchSchemas.ForeColor = System.Drawing.Color.Silver;
            this.searchSchemas.Location = new System.Drawing.Point(139, 38);
            this.searchSchemas.Name = "searchSchemas";
            this.searchSchemas.Size = new System.Drawing.Size(103, 22);
            this.searchSchemas.TabIndex = 14;
            this.searchSchemas.Text = "Название схемы";
            this.searchSchemas.TextChanged += new System.EventHandler(this.searchSchemas_TextChanged);
            this.searchSchemas.Enter += new System.EventHandler(this.searchSchemas_Enter);
            this.searchSchemas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.searchSchemas_KeyDown);
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(139, 17);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(34, 13);
            this.lblHost.TabIndex = 15;
            this.lblHost.Text = "Host:";
            // 
            // rbtnHost
            // 
            this.rbtnHost.AutoSize = true;
            this.rbtnHost.Location = new System.Drawing.Point(179, 17);
            this.rbtnHost.Name = "rbtnHost";
            this.rbtnHost.Size = new System.Drawing.Size(14, 13);
            this.rbtnHost.TabIndex = 16;
            this.rbtnHost.UseVisualStyleBackColor = true;
            this.rbtnHost.CheckedChanged += new System.EventHandler(this.rbtnHost_CheckedChanged);
            // 
            // rbtnAll
            // 
            this.rbtnAll.AutoSize = true;
            this.rbtnAll.Checked = true;
            this.rbtnAll.Location = new System.Drawing.Point(228, 17);
            this.rbtnAll.Name = "rbtnAll";
            this.rbtnAll.Size = new System.Drawing.Size(14, 13);
            this.rbtnAll.TabIndex = 18;
            this.rbtnAll.TabStop = true;
            this.rbtnAll.UseVisualStyleBackColor = true;
            this.rbtnAll.CheckedChanged += new System.EventHandler(this.rbtnAll_CheckedChanged);
            // 
            // lblAll
            // 
            this.lblAll.AutoSize = true;
            this.lblAll.Location = new System.Drawing.Point(199, 17);
            this.lblAll.Name = "lblAll";
            this.lblAll.Size = new System.Drawing.Size(23, 13);
            this.lblAll.TabIndex = 17;
            this.lblAll.Text = "All:";
            // 
            // c_Proc
            // 
            this.c_Proc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.c_Proc.DataPropertyName = "name";
            this.c_Proc.HeaderText = "Процедура";
            this.c_Proc.Name = "c_Proc";
            this.c_Proc.ReadOnly = true;
            this.c_Proc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // c_HostName
            // 
            this.c_HostName.DataPropertyName = "HostName";
            this.c_HostName.HeaderText = "Хост";
            this.c_HostName.Name = "c_HostName";
            this.c_HostName.ReadOnly = true;
            this.c_HostName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_HostName.Width = 80;
            // 
            // dateEdit
            // 
            this.dateEdit.DataPropertyName = "modify_date";
            this.dateEdit.HeaderText = "Дата изменения";
            this.dateEdit.Name = "dateEdit";
            this.dateEdit.ReadOnly = true;
            this.dateEdit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // definition
            // 
            this.definition.DataPropertyName = "definition";
            this.definition.HeaderText = "definition";
            this.definition.Name = "definition";
            this.definition.Visible = false;
            // 
            // c_Create
            // 
            this.c_Create.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.c_Create.FillWeight = 10F;
            this.c_Create.HeaderText = "C";
            this.c_Create.Name = "c_Create";
            this.c_Create.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_Create.Width = 40;
            // 
            // c_Alter
            // 
            this.c_Alter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.c_Alter.HeaderText = "A";
            this.c_Alter.MinimumWidth = 10;
            this.c_Alter.Name = "c_Alter";
            this.c_Alter.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.c_Alter.Width = 40;
            // 
            // Procedures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(459, 384);
            this.Controls.Add(this.rbtnAll);
            this.Controls.Add(this.lblAll);
            this.Controls.Add(this.rbtnHost);
            this.Controls.Add(this.lblHost);
            this.Controls.Add(this.searchSchemas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateModifiedTo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtModified);
            this.Controls.Add(this.btnEditPath);
            this.Controls.Add(this.path);
            this.Controls.Add(this.dataProcedures);
            this.Controls.Add(this.dateModifiedFrom);
            this.Controls.Add(this.schemaName);
            this.Controls.Add(this.dbName);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Procedures";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выгрузка процедур";
            ((System.ComponentModel.ISupportInitialize)(this.dataProcedures)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox dbName;
        private System.Windows.Forms.ComboBox schemaName;
        private System.Windows.Forms.DateTimePicker dateModifiedFrom;
        private System.Windows.Forms.DataGridView dataProcedures;
        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Button btnEditPath;
        private System.Windows.Forms.Label txtModified;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateModifiedTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox searchSchemas;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.RadioButton rbtnHost;
        private System.Windows.Forms.RadioButton rbtnAll;
        private System.Windows.Forms.Label lblAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_Proc;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_HostName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEdit;
        private System.Windows.Forms.DataGridViewTextBoxColumn definition;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Create;
        private System.Windows.Forms.DataGridViewCheckBoxColumn c_Alter;
    }
}

