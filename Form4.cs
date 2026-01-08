using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;
namespace Astra
{
    public partial class Form4 : Form
    {
        
        string cadena_conexion;
       
        public event Action PacienteAgregado; // Evento personalizado


        public class Paciente
        {
            public string Nombre {  get; set; }
            public string Apellidos {  get; set; }
            public int Edad {  get; set; }
            public double Altura { get; set; }
            public double Peso { get; set; }
            public string Alergia {  get; set; }
            public string Padecimiento { get; set; }

        }
        public Form4()
        {
            InitializeComponent();



            string ruta = Path.Combine(Application.StartupPath, @"Data\AstraDB.mdf");
            cadena_conexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AstraDB.mdf; Integrated Security=True;Connect Timeout=30;";



        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            //Obtener variables y datos en los atributos de la clase Paciente
            Paciente paciente = new Paciente();
            try
            {
               
                paciente.Nombre = txtNombre.Text;
                paciente.Apellidos = txtApellidos.Text;

                
                paciente.Edad = int.Parse(txtEdad.Text);
                paciente.Altura = double.Parse(txtAltura.Text);
                paciente.Peso = double.Parse(txtPeso.Text);
                paciente.Alergia = txtAlergias.Text;
                paciente.Padecimiento = txtPadecimientos.Text;

                if (paciente.Edad <= 0 || paciente.Edad >= 100 )
                {
                    MessageBox.Show("Ingrese una edad valida ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                
            }
            catch
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Salir del método si hay un error
            }

            //usando la base de datos
            using (SqlConnection con = new SqlConnection(cadena_conexion))
            {

                try
                {
                    con.Open();
                    //Orden insertar para usar la palabra reservada INSERT INTO para indicar "Insertar en" tabla Pacientes "valores" 

                    string insertar = @"INSERT INTO Pacientes (Nombre, Apellido, Edad, Altura, Peso) VALUES (@Nombre, @Apellido, @Edad,
                                        @Altura,@Peso); SELECT SCOPE_IDENTITY();";

                   SqlCommand cmd = new SqlCommand(insertar,con);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", paciente.Apellidos);
                    cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                    cmd.Parameters.AddWithValue("@Altura", paciente.Altura);
                    cmd.Parameters.AddWithValue("@Peso", paciente.Peso);

                    int idpaciente = Convert.ToInt32(cmd.ExecuteScalar());

                    //Nueva insercion de los datos de alergias y padecimientos

                    string insertarAlergias = @"INSERT INTO Alergias (IdPaciente, Alergia) VALUES (@IdPaciente,@Alergia)";

                    SqlCommand cmdAlergias = new SqlCommand(insertarAlergias, con);
                    cmdAlergias.Parameters.AddWithValue("@IdPaciente", idpaciente);
                    cmdAlergias.Parameters.AddWithValue("@Alergia", paciente.Alergia);

                    string insertarPadecimientos = @"INSERT INTO Padecimientos (IdPaciente, Padecimiento) VALUES (@IdPaciente,@Padecimiento)";
                    SqlCommand cmdPadecimientos = new SqlCommand(insertarPadecimientos, con);
                    cmdPadecimientos.Parameters.AddWithValue("@IdPaciente", idpaciente);
                    cmdPadecimientos.Parameters.AddWithValue("@Padecimiento", paciente.Padecimiento);

                    cmdAlergias.ExecuteNonQuery();
                    cmdPadecimientos.ExecuteNonQuery();
                    MessageBox.Show("Paciente registrado correctamente");
                    // Disparar evento para actualizar el otro formulario
                    PacienteAgregado?.Invoke();
                    this.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al registrar paciente" + ex.Message);
                }
            }
        }

        private void Cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        
        private bool arrastrar = false;
        private Point puntoInicio;
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                arrastrar = true;
                puntoInicio = new Point(e.X, e.Y);
            }
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrar)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - puntoInicio.X, p.Y - puntoInicio.Y);
            }
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrar = false;
        }
    }
}
