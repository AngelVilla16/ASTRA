

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;



namespace Astra
{
   
    public partial class Form2 : Form
    {
        string ruta;

        string cadena_conexion;


        public Form2()
        {
            InitializeComponent();


            string ruta = Path.Combine(Application.StartupPath, @"Data\AstraDB.mdf");
            cadena_conexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AstraDB.mdf;Integrated Security=True;Connect Timeout=30";



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
            
            using (SqlConnection con = new SqlConnection(cadena_conexion ))
            {
                try
                {
                    con.Open();
                    string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario";
                    SqlCommand verificar = new SqlCommand(consulta,con);
                    verificar.Parameters.AddWithValue("@Usuario", usuario);
                    int existe = (int)verificar.ExecuteScalar();
                    if (existe > 0)
                    {

                        MessageBox.Show("El usuario ya esta registrado");
                        return;
                    }
                    //Insertar el nuevo usuario
                    string insertar = "INSERT INTO Usuarios (Usuario, Contraseña) VALUES (@Usuario,@Contraseña)";
                    SqlCommand cmd = new SqlCommand(insertar,con);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
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
