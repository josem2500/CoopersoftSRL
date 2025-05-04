using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopeSoft
{
    internal class DatabaseHelper
    {
        // Cadena de conexión - AJUSTA ESTOS VALORES
        private static readonly string ConnectionString =
            @"Server=.\SQLEXPRESS; 
              Database=CooperativaDB; 
              Integrated Security=True;
              TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static bool TestConnection()
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de SQL Server: {ex.Message}\nNúmero de error: {ex.Number}",
                    "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}

