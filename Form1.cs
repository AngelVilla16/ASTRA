
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.IO;
namespace Astra
{
    public partial class Form1 : Form
    {   
        string rutaDb;
        string cadena_conexion;
        public Form1()
        {

            InitializeComponent();

            //Cadena de conexion para sqlite


            string ruta = Path.Combine(Application.StartupPath, @"Data\AstraDB.mdf");
            cadena_conexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AstraDB.mdf;Integrated Security=True;Connect Timeout=30";




        }
        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            //Creamos las variables para traer el texto de los texbox
            string usuario = txtUsuario.Text;
            string contraseña = txtContraseña.Text;
           
            using (SqlConnection con = new SqlConnection(cadena_conexion)) 
            {
                try // Es fundamental tener un try-catch que envuelva la apertura de la conexión y las operaciones
                {
                    con.Open();

                    // Si tu tabla 'Usuarios' es la misma que 'usuarios' en el ejemplo de Form4,
                    // la capitalización podría importar dependiendo de la configuración de la DB,
                    // pero generalmente SQLite no distingue mayúsculas/minúsculas para nombres de tablas/columnas.

                    // --- CORRECCIÓN DE LA CONSULTA Y LOS PARÁMETROS ---
                    // 1. Uso de parámetros nombrados (@usuario, @contraseña) - MUY RECOMENDADO
                    string consulta = "SELECT COUNT(*) FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";

                    
                    using (SqlCommand comando = new SqlCommand(consulta, con))
                    {
                        // 2. Añadir parámetros por nombre, esto es más robusto y claro.
                        comando.Parameters.AddWithValue("@Usuario", usuario); // El nombre del parámetro debe coincidir con la consulta
                        comando.Parameters.AddWithValue("@Contraseña", contraseña);

                        // --- CORRECCIÓN EN LA CONVERSIÓN DE EXECUTESCALAR ---
                        // ExecuteScalar devuelve un 'object'. Para COUNT(*), será un 'long' (0 o más).
                        // Es más seguro usar Convert.ToInt32() o un cast a 'long' primero.
                        object resultado = comando.ExecuteScalar();
                        int cuenta = 0;

                        if (resultado != null && resultado != DBNull.Value)
                        {
                            cuenta = Convert.ToInt32(resultado); // Convierte el resultado a int de forma segura
                        }
                        // Si resultado es null o DBNull.Value (lo cual no debería ocurrir con COUNT(*)), cuenta seguirá siendo 0.

                        if (cuenta > 0)
                        {
                            MessageBox.Show("Inicio de sesion exitoso");

                            Form3 form3 = new Form3();
                            form3.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario y/o contraseña incorrectos."); // Mensaje más preciso
                        }
                    }
                }
                catch (SqlException ex) // Captura errores específicos de SQLite
                {
                    MessageBox.Show($"Error de base de datos: {ex.Message}", "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Opcional: Debug.WriteLine(ex.ToString()); para ver más detalles en la salida de depuración
                }
                catch (Exception ex) // Captura cualquier otro error inesperado
                {
                    MessageBox.Show($"Ocurrió un error inesperado: {ex.Message}", "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                // El 'using' se encarga de cerrar la conexión automáticamente al salir del bloque.
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {   
            txtUsuario.Clear();
            txtContraseña.Clear();
            Form2 form2 = new Form2();
            form2.Show();
            

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtUsuario.Clear();
            txtContraseña.Clear();

        }

        private void Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
          if(arrastrar)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - puntoInicio.X, p.Y - puntoInicio.Y);
            }
        }
        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
           arrastrar = false;
        }
    }

       
    
}
