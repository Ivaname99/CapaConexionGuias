using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaConexion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = 
                new SqlConnection
                ("Data Source=DESKTOP-SIMON\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True;");
            MessageBox.Show("Conexión creada");
            conexion.Open();

            //-----------------------
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
            //-----------------------

            SqlCommand comando = new SqlCommand(selectFrom, conexion);
            SqlDataReader reader = comando.ExecuteReader();

            while (reader.Read())
            {
                var customerId = reader["CompanyName"];
            }

            MessageBox.Show("Conexión cerrada");
            conexion.Close();

        }
    }
}
