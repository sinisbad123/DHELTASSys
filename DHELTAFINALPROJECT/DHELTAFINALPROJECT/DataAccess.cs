using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace DHELTASSYS
{
    namespace DataAccess
    {
        public class DHELTASSysDataAccess
        {
            public static string connectionString = "SERVER=localhost;DATABASE=dheltassys;UID=dheltassys;PWD=teammegabyte;";

            public static void Modify(string SqlStatement)
            {
                SqlConnection connect = new SqlConnection(connectionString);
                connect.Open();
                SqlCommand command = new SqlCommand(SqlStatement, connect);
                command.ExecuteNonQuery();
                command.Dispose();
                connect.Close();
            }

            public static DataTable Select(string SelectStatement)
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter(SelectStatement, connectionString);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }




        }
    }
}