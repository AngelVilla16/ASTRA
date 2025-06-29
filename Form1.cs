
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
namespace Astra
{
    public partial class Form1 : Form
    {   OleDbConnection conn = new OleDbConnection();
        string ruta;
        string conexion;
        public Form1()
        {
            
            InitializeComponent();
            
            ruta = @"C:\Users\Angel\Documents\Astra.accdb";
            conexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Angel\Documents\Astra.accdb;";
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Creamos las variables para traer el texto de los texbox
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;

            using (OleDbConnection con = new OleDbConnection(conexion))
            {
                con.Open();

                string consulta = "SELECT COUNT(*) FROM usuarios WHERE Usuario = ? AND Contraseña = ?";

                OleDbCommand comando = new OleDbCommand(consulta, con);
                comando.Parameters.AddWithValue("?", usuario);
                comando.Parameters.AddWithValue("?", contraseña);

                int cuenta = (int)comando.ExecuteScalar();
                if (cuenta > 0)
                {
                    MessageBox.Show("Inicio de sesion exitoso");

                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("usuario y contraseña incorrectos");
                }



            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();

        }
    }

       
    
}
