
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
using System.Security.Cryptography;




namespace Astra
{
   
    public partial class Form2 : Form
    {
        string ruta;

        string conexion = @"Provider=Microsoft.ACE.OLEDB.12.0; Data Source=C:\Users\Angel\Documents\Astra.accdb;";


        public Form2()
        {
            InitializeComponent();
            ruta = @"C:\Users\Angel\Documents\Astra.accdb";

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
           string usuario = txtRegistroUsuario.Text;
            string contraseña = txtRegistroContraseña.Text;

            if (usuario == "" || contraseña == "")
            {
                MessageBox.Show("Por favor ingrese todos los datos");
                return;
            }

            using (OleDbConnection con = new OleDbConnection(conexion))
            {
                try
                {
                    con.Open();
                    string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = ?";
                    OleDbCommand verificar = new OleDbCommand(consulta, con);
                    verificar.Parameters.AddWithValue("?", usuario);
                    int existe = (int)verificar.ExecuteScalar();
                    if (existe > 0)
                    {

                        MessageBox.Show("El usuario ya esta registrado");
                        return;
                    }
                    //Insertar el nuevo usuario
                    string insertar = "INSERT INTO usuarios (usuario, contraseña) VALUES (?,?)";
                    OleDbCommand cmd = new OleDbCommand(insertar, con);
                    cmd.Parameters.AddWithValue("?", usuario);
                    cmd.Parameters.AddWithValue("?", contraseña);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuario registrado con exito");
                    this.Close();
                }
                catch(Exception ex) 
                {
                    MessageBox.Show("Error al registrar "  + ex.Message);
                }
            }
        }
    }
}
