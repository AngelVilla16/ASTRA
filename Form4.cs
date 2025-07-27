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
            public string Alergias {  get; set; }
            public string Padecimientos { get; set; }

        }
        public Form4()
        {
            InitializeComponent();



            string ruta = Path.Combine(Application.StartupPath, @"Data\AstraDB.mdf");
            cadena_conexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AstraDB.mdf;Integrated Security=True;Connect Timeout=30";



        }
        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            //Obtener variables y datos en las variables
            Paciente paciente = new Paciente();
            paciente.Nombre = txtNombre.Text;
            paciente.Apellidos = txtApellidos.Text;
            paciente.Edad = int.Parse(txtEdad.Text);
            paciente.Altura = double.Parse(txtAltura.Text);
            paciente.Peso = double.Parse(txtPeso.Text);
            paciente.Alergias = txtAlergias.Text;
            paciente.Padecimientos = txtPadecimientos.Text;

            //usando la base de datos
            using (SqlConnection con = new SqlConnection(cadena_conexion))
            {

                try
                {
                    con.Open();
                    //Orden insertar para usar la palabra reservada INSERT INTO para indicar "Insertar en" tabla Pacientes "valores" 

                    string insertar = @"INSERT INTO Pacientes (Nombre, Apellido, Edad, Altura, Peso, Alergia, Padecimiento) VALUES (@Nombre, @Apellido, @Edad,
                                        @Altura,@Peso,@Alergia,@Padecimiento)";

                   SqlCommand cmd = new SqlCommand(insertar,con);
                    cmd.Parameters.AddWithValue("@Nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", paciente.Apellidos);
                    cmd.Parameters.AddWithValue("@Edad", paciente.Edad);
                    cmd.Parameters.AddWithValue("@Altura", paciente.Altura);
                    cmd.Parameters.AddWithValue("@Peso", paciente.Peso);
                    cmd.Parameters.AddWithValue("@Alergia", paciente.Alergias);
                    cmd.Parameters.AddWithValue("@Padecimiento ", paciente.Padecimientos);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente registrado correctamente" + MessageBoxButtons.OK);
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
    }
}
