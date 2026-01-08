

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
//using MySql.Data.MySqlClient;


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
            cadena_conexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AstraDB.mdf; Integrated Security=True;Connect Timeout=30;";



        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string usuario = txtRegistroUsuario.Text;
            string contraseña = txtRegistroContraseña.Text;
            string confirm = txtConfirmarContraseña.Text;

            if (usuario == "" || contraseña == "" || nombre == "")
            {
                MessageBox.Show("Por favor ingrese todos los datos");
                return;
            }
            
            if(confirm != contraseña)
            {
                MessageBox.Show("Las contraseñas no coinciden ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(cadena_conexion))
            {
                try
                {
                    con.Open();
                    string consulta = "SELECT COUNT(*) FROM Doctores WHERE Usuario = @Usuario";
                    SqlCommand verificar = new SqlCommand(consulta, con);
                    verificar.Parameters.AddWithValue("@Usuario", usuario);
                    int existe = (int)verificar.ExecuteScalar();
                    if (existe > 0)
                    {

                        MessageBox.Show("El usuario ya esta registrado");
                        return;
                    }
                    //Insertar el nuevo usuario
                    string insertar = "INSERT INTO Doctores (Usuario, Contraseña, Doctor) VALUES (@Usuario,@Contraseña, @Doctor)";
                    SqlCommand cmd = new SqlCommand(insertar, con);
                    cmd.Parameters.AddWithValue("@Usuario", usuario);
                    cmd.Parameters.AddWithValue("@Contraseña", contraseña);
                    cmd.Parameters.AddWithValue("@Doctor", nombre);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Usuario registrado con exito");
                    this.Close();
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al registrar " + ex.Message);
                }
            }
        }
        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        
        private bool arrastrar = false;
        private Point puntoInicio;
        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                arrastrar = true;
                puntoInicio = new Point(e.X, e.Y);
            }
        }
        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrar)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - puntoInicio.X, p.Y - puntoInicio.Y);
            }
        }
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrar = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtRegistroContraseña.PasswordChar = '\0';
                txtConfirmarContraseña.PasswordChar = '\0';
            }
            else
            {
                txtRegistroContraseña.PasswordChar= '*';
                txtConfirmarContraseña.PasswordChar = '*';
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
