﻿using DatosLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaConexion
{
    public partial class Form1 : Form
    {
        CustomerRepository customerRepository = new CustomerRepository();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCargar_Click(object sender, EventArgs e)
        {
            //dataGrid.DataSource = Customers;
            var Customers = customerRepository.ObtenerTodos();
            dataGrid.DataSource = Customers;
        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            //var filtro = Customers.FindAll(X => X.CompanyName.StartsWith(txtFiltro.Text));
            //dataGrid.DataSource = filtro;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DatosLayer.DataBase.ApplicationName = "Programacion 2 ejemplo";
            //DatosLayer.DataBase.ConnetionTimeout = 30;
            //string cadenaConexion = DatosLayer.DataBase.ConnectionString;
            ////MessageBox.Show(cadenaConexion);

            //var conectarDB = DatosLayer.DataBase.GetSqlConnection();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            var cliente = customerRepository.ObtenerPorID(txtBuscar.Text);
            if (cliente != null)
            {
                txtBuscar.Text = cliente.CompanyName;
                MessageBox.Show(cliente.CompanyName);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            var nuevoCliente = new Customers
            {
                CustomerID = tboxCustomerID.Text,
                CompanyName = tboxCompanyName.Text,
                ContactName = tboxContactName.Text,
                ContactTitle = tboxContactTitle.Text,
                Address = tboxAddress.Text,
                City = tboxCity.Text
            };
            var resultado = 0;
            if (validarCampoNull(nuevoCliente) == false)
            {
                resultado = customerRepository.InsertarCliente(nuevoCliente);
                MessageBox.Show("Filas insertadas correcta");
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos por favor" + resultado);
            }
        }

        public Boolean validarCampoNull(Object objeto)
        {
            foreach (PropertyInfo property in objeto.GetType().GetProperties())
            {
                object value = property.GetValue(objeto, null);
                if (value == "")
                {
                    return true;
                }
            }
            return false;
        }
    }
}
