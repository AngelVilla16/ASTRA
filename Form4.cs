using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astra
{
    public partial class Form4 : Form
    {
        string conexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Angel\Documents\Astra.accdb;";
        
        public event Action PacienteAgregado; // Evento personalizado

        public Form4()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Obtener variables y datos en las variables
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            int edad = int.Parse(txtEdad.Text);
            double altura = double.Parse(txtAltura.Text);
            double peso = double.Parse(txtPeso.Text);
            string alergias = txtAlergias.Text;
            string padecimientos = txtPadecimientos.Text;

            //usando la base de datos
            using (OleDbConnection con = new OleDbConnection(conexion))
            {

                try
                {
                    con.Open();
                    //Orden insertar para usar la palabra reservada INSERT INTO para indicar "Insertar en" tabla Pacientes "valores" 

                    string insertar = @"INSERT INTO Pacientes (Nombre, Apellido, Edad, Altura, Peso, Alergia, Padecimiento) VALUES (?, ?, ?, ?,?,?,?)";

                    OleDbCommand cmd = new OleDbCommand(insertar, con);
                    cmd.Parameters.AddWithValue("?", nombre);
                    cmd.Parameters.AddWithValue("?", apellidos);
                    cmd.Parameters.AddWithValue("?", edad);
                    cmd.Parameters.AddWithValue("?", altura);
                    cmd.Parameters.AddWithValue("?", peso);
                    cmd.Parameters.AddWithValue("?", alergias);
                    cmd.Parameters.AddWithValue("?", padecimientos);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente registrado correctamente");
                    // Disparar evento para actualizar el otro formulario
                    PacienteAgregado?.Invoke();
                    this.Close();

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al registrar paciente" +  ex.Message);
                }
            }
        }
       
    }
}
