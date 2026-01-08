using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
//using MySql.Data.MySqlClient;
namespace Astra
{
    public partial class Form7 : Form
    {
        string ruta;
        string cadena_conexion;
        private int idpacienteseleccionado;
        string nombre;
        string apellido;
        public event Action PacienteActualizado;
        public Form7(int IdPaciente)
        {
            InitializeComponent();
            idpacienteseleccionado = IdPaciente;
           ruta = Path.Combine(Application.StartupPath, @"Data\AstraDB.mdf");
            cadena_conexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AstraDB.mdf; Integrated Security=True;Connect Timeout=30;";

        }
        private bool arrastrar = false;
        private Point puntoInicio;
        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                arrastrar = true;
                puntoInicio = new Point(e.X, e.Y);
            }
        }
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (arrastrar)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - puntoInicio.X, p.Y - puntoInicio.Y);
            }
        }
        private void panel2_MouseUp(object sender, MouseEventArgs e)
        {
            arrastrar = false;
        }
        private void CargarDatosAnteriores()

        {
            string edadprevia = "";
            string pesoprevio = "";
            string alturaprevia = "";
            string padecimientoprevio = " ";
            string alergiaprevia = "";


            using(SqlConnection con = new SqlConnection(cadena_conexion))
            {
                try
                {

                    con.Open();

                    string consulta = "SELECT Edad, Altura, Peso FROM Pacientes WHERE IdPaciente = @IdPaciente";
                    using (SqlCommand cmd = new SqlCommand(consulta, con))
                    {
                        cmd.Parameters.AddWithValue("@IdPaciente", idpacienteseleccionado);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            edadprevia= reader["Edad"].ToString();
                            alturaprevia = reader["Altura"].ToString();
                            pesoprevio = reader["Peso"].ToString();

                            txtEdadPrevio.Text = edadprevia;
                            txtAlturaPrevia.Text = alturaprevia;
                            txtPesoPrevio.Text = pesoprevio;
                            
                        }
                       reader.Close();





                    }

                    string consulta2 = "SELECT Alergia FROM Alergias WHERE IdPaciente = @IdPaciente ";
                    using(SqlCommand cmd2 = new SqlCommand(consulta2, con))
                    {

                        cmd2.Parameters.AddWithValue("@IdPaciente", idpacienteseleccionado);
                        SqlDataReader reader2 = cmd2.ExecuteReader();

                        if (reader2.Read())
                        {
                            alergiaprevia = reader2["Alergia"].ToString();

                            txtAlergiasPrevio.Text = alergiaprevia;


                        }
                        reader2.Close();


                    }
                    string consulta3 = "SELECT Padecimiento FROM Padecimientos WHERE IdPaciente = @IdPaciente";
                    using(SqlCommand cmd3 = new SqlCommand(consulta3, con))
                    {

                        cmd3.Parameters.AddWithValue("@IdPaciente", idpacienteseleccionado);
                        SqlDataReader reader3 = cmd3.ExecuteReader();

                        if (reader3.Read())
                        {

                            padecimientoprevio = reader3["Padecimiento"].ToString();
                            txtPadecimientosPrevios.Text = padecimientoprevio;

                        }
                        reader3.Close();

                    }




                }

                catch(Exception ex)
                {
                    MessageBox.Show("Error al cargar datos previos " + ex.Message);
                    return;




                }






            }




        }
        private void CargarNombrePaciente()
        {
            using(SqlConnection con = new SqlConnection(cadena_conexion))
            {
                try
                {
                    con.Open();
                    string consulta = "SELECT Nombre, Apellido FROM Pacientes WHERE IdPaciente = @IdPaciente";
                    SqlCommand cmd = new SqlCommand(consulta, con);
                    cmd.Parameters.AddWithValue("@IdPaciente", idpacienteseleccionado);
                    //Lector sql que permite leer los datos del paciente nombre y apellido
                    SqlDataReader reader = cmd.ExecuteReader();
                    //Si el lector lee los datos, los asigna a las variables y las muestra en el textbox
                    if (reader.Read())
                    { //Si el lector lee los datos, los asigna a las variables y las muestra en el textbox
                        nombre = reader["Nombre"].ToString();
                        apellido = reader["Apellido"].ToString();
                        //Concatena el nombre y apellido
                        txtPaciente.Text = $"{nombre} + {apellido}";
                    }
                    else
                    {
                        txtPaciente.Text = "Paciente no encontrado";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el nombre del paciente: " + ex.Message);
                }
            }
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            CargarNombrePaciente();
            CargarDatosAnteriores();
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            
            int edad;
            double peso;
            double altura;
            string alergia;
            string padecimiento;
            try
            {
                edad = int.Parse(txtEdad.Text);
                peso = double.Parse(txtPeso.Text);
                altura = double.Parse(txtAltura.Text);
                alergia = txtAlergias.Text;
                padecimiento = txtPadecimientos.Text; 

                if( edad<=0 || edad>= 100)
                {

                    MessageBox.Show("Ingrese una edad valida ", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para Edad, Peso y Altura.", "Error de entrada", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            using (SqlConnection con = new SqlConnection(cadena_conexion))
            {
                try
                {
                    con.Open();
                    string actualizar = "UPDATE Pacientes SET Edad = @Edad, Altura = @Altura, Peso = @Peso WHERE IdPaciente = @IdPaciente";

                    using(SqlCommand cmd = new SqlCommand(actualizar, con))
                    {
                        cmd.Parameters.AddWithValue("@IdPaciente", idpacienteseleccionado);
                        cmd.Parameters.AddWithValue("@Edad", edad);
                        cmd.Parameters.AddWithValue("@Peso", peso);
                        cmd.Parameters.AddWithValue("Altura", altura);
                        cmd.ExecuteNonQuery();
                    }
                    string actualizaralergia = "UPDATE Alergias SET Alergia = @Alergia WHERE IdPaciente = @IdPaciente";
                    using(SqlCommand cmd2 = new SqlCommand(actualizaralergia, con))
                    {

                        cmd2.Parameters.AddWithValue("@IdPaciente", idpacienteseleccionado);
                        cmd2.Parameters.AddWithValue("@Alergia", alergia);
                        cmd2.ExecuteNonQuery();

                    }
                    string actualizarPadecimiento = "UPDATE Padecimientos SET Padecimiento = @Padecimiento WHERE IdPaciente = @IdPaciente";
                    using(SqlCommand cmd3 = new SqlCommand(actualizarPadecimiento, con))
                    {

                        cmd3.Parameters.AddWithValue("@IdPaciente", idpacienteseleccionado);
                        cmd3.Parameters.AddWithValue("@Padecimiento", padecimiento);

                    }
                    MessageBox.Show("Datos actualizados del paciente ");
                    PacienteActualizado.Invoke();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar los datos del paciente: " + ex.Message);
                }
            }
           


        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
