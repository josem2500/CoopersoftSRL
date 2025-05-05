using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoopeSoft
{
   /* public static class SqlExtensions
    {
        public static DataTable ExecuteQuery(this SqlConnection connection, string query)
        {
            DataTable dt = new DataTable();
            using (var cmd = new SqlCommand(query, connection))
            using (var adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
            return dt;
        }

        public static DataTable ToDataTable(this SqlDataReader reader)
        {
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
    }*/
}
