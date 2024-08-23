using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosLayer
{
    public class CustomerRepository
    {
        public List<customers> ObtenerTodos()
        {
            var conexion = DataBase.GetSqlConnection();
            string selectFrom = "";
            selectFrom += "SELECT [CompanyName] \n";
            selectFrom += "      ,[ContactName] \n";
            selectFrom += "      ,[ContactTitle] \n";
            selectFrom += "      ,[Address] \n";
            selectFrom += "      ,[City] \n";
            selectFrom += "      ,[Region] \n";
            selectFrom += "      ,[PostalCode] \n";
            selectFrom += "      ,[Country] \n";
            selectFrom += "      ,[Phone] \n";
            selectFrom += "      ,[Fax] \n";
            selectFrom += "  FROM [dbo].[Customers]";

            SqlCommand comando = new SqlCommand(selectFrom, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            List<customers> Customers = new List<customers>();

            while (reader.Read())
            {
                customers customers = new customers();
                customers.CompanyName = ((reader["CompanyName"] == DBNull.Value) ? "" : ((string)reader["CompanyName"]));
                customers.ContactName = ((reader["ContactName"] == DBNull.Value) ? "" : ((string)reader["ContactName"]));
                customers.ContactTitle = ((reader["ContactTitle"] == DBNull.Value) ? "" : ((string)reader["ContactTitle"]));
                customers.Address = ((reader["Address"] == DBNull.Value) ? "" : ((string)reader["Address"]));
                customers.City = ((reader["City"] == DBNull.Value) ? "" : ((string)reader["City"]));
                customers.Region = ((reader["Region"] == DBNull.Value) ? "" : ((string)reader["Region"]));
                customers.PostalCode = ((reader["PostalCode"] == DBNull.Value) ? "" : ((string)reader["PostalCode"]));
                customers.Country = ((reader["Country"] == DBNull.Value) ? "" : ((string)reader["Country"]));
                customers.Phone = ((reader["Phone"] == DBNull.Value) ? "" : ((string)reader["Phone"]));
                customers.Fax = ((reader["Fax"] == DBNull.Value) ? "" : ((string)reader["Fax"]));
                Customers.Add(customers);
            }
            conexion.Close();
            return Customers;
        }
    }
}
