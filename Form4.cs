using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astra
{
    public partial class Form4 : Form
    {
        string conexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Angel\Documents\Astra.accdb;";
        
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
            using (OleDbConnection con = new OleDbConnection(conexion))
            {

                try
                {
                    con.Open();
                    //Orden insertar para usar la palabra reservada INSERT INTO para indicar "Insertar en" tabla Pacientes "valores" 

                    string insertar = @"INSERT INTO Pacientes (Nombre, Apellido, Edad, Altura, Peso, Alergia, Padecimiento) VALUES (?, ?, ?, ?,?,?,?)";

                    OleDbCommand cmd = new OleDbCommand(insertar, con);
                    cmd.Parameters.AddWithValue("?", paciente.Nombre);
                    cmd.Parameters.AddWithValue("?", paciente.Apellidos);
                    cmd.Parameters.AddWithValue("?", paciente.Edad);
                    cmd.Parameters.AddWithValue("?", paciente.Altura);
                    cmd.Parameters.AddWithValue("?", paciente.Peso);
                    cmd.Parameters.AddWithValue("?", paciente.Alergias);
                    cmd.Parameters.AddWithValue("?", paciente.Padecimientos);
                    cmd.ExecuteNonQuery();
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
    }
}
