﻿using CapaConexion.Modelos;
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

            MessageBox.Show("Conexión cerrada");
            conexion.Close();

        }
    }
}
