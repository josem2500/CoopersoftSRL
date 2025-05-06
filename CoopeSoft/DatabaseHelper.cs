using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopeSoft
{
    internal class DatabaseHelper
    {
        // Cadena de conexión - AJUSTA ESTOS VALORES
        private static readonly string ConnectionString =
            @"Server=DEVT470P; 
              Database=CooperativaDB; 
              Integrated Security=True;
              TrustServerCertificate=True;";

        /* public static SqlConnection GetConnection()
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

          public static int ExecuteNonQuery(string commandText, params SqlParameter[] parameters)
          {
              try
              {
                  using (var connection = GetConnection())
                  {
                      connection.Open();
                      using (var command = new SqlCommand(commandText, connection))
                      {
                          if (parameters != null)
                          {
                              command.Parameters.AddRange(parameters);
                          }
                          return command.ExecuteNonQuery();
                      }
                  }
              }
              catch (SqlException ex)
              {
                  // Log del error (evitar MessageBox en clases de acceso a datos)
                  throw new Exception($"Error en ExecuteNonQuery: {ex.Message}", ex);
              }
          }
          public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
          {
              DataTable dt = new DataTable();
              using (var connection = GetConnection())
              {
                  connection.Open();
                  using (var command = new SqlCommand(query, connection))
                  {
                      if (parameters != null)
                      {
                          command.Parameters.AddRange(parameters);
                      }
                      using (var adapter = new SqlDataAdapter(command))
                      {
                          adapter.Fill(dt);
                      }
                  }
              }
              return dt;
          }*/

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

        public static int ExecuteNonQuery(string commandText, params SqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(commandText, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en ExecuteNonQuery: {ex.Message}", ex);
            }
        }

        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                DataTable dt = new DataTable();
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en ExecuteQuery: {ex.Message}", ex);
            }
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en ExecuteScalar: {ex.Message}", ex);
            }
        }



    }
}

/*

using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace CoopeSoft
{
    internal class DatabaseHelper
    {
        // Cadena de conexión - Hardcodeada
        private static readonly string ConnectionString =
            @"Server=DEVT470P; 
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

        public static int ExecuteNonQuery(string commandText, params SqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(commandText, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en ExecuteNonQuery: {ex.Message}", ex);
            }
        }

        public static DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            try
            {
                DataTable dt = new DataTable();
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        using (var adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dt);
                        }
                    }
                }
                return dt;
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en ExecuteQuery: {ex.Message}", ex);
            }
        }

        public static object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            try
            {
                using (var connection = GetConnection())
                {
                    connection.Open();
                    using (var command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }
                        return command.ExecuteScalar();
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Error en ExecuteScalar: {ex.Message}", ex);
            }
        }
    }
}*/