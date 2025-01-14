using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace procedures
{
    internal class Connection
    {
        public SqlConnection _connection;
        
        public Connection(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }

        public void OpenConnection()
        { 
            _connection.Open();
        }

        public void CloseConnection() 
        {
            _connection.Close(); 
        }

        public SqlCommand CreateCommand(string query)
        {
            return new SqlCommand(query, _connection);
        }
    }
}
