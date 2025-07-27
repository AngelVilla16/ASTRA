using Microsoft.Data.SqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace Astra
{
    public partial class Form6 : Form
    {
        string cadena_conexion;
        public Action pacienteAgregadoi;
        private int idpacienteseleccionado;
        private bool expedienteExiste = false;

        public Form6(int IdPaciente)
        {
            InitializeComponent();
            idpacienteseleccionado = IdPaciente;



            string ruta = Path.Combine(Application.StartupPath, @"Data\AstraDB.mdf");
            cadena_conexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AstraDB.mdf;Integrated Security=True;Connect Timeout=30";



        }

        private void CargarExpediente()
        {
            using (SqlConnection con = new SqlConnection(cadena_conexion))
            {
                try
                {
                    con.Open();
                    string consulta = "SELECT Expediente FROM Expedientes WHERE IdExpediente = @IdExpediente";
                    SqlCommand cmd = new SqlCommand(consulta, con);
                    cmd.Parameters.AddWithValue("@IdExpediente", idpacienteseleccionado);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        Expediente.Text = reader["Expediente"].ToString();
                        expedienteExiste = true;
                    }
                    else
                    {
                        expedienteExiste = false;
                        // O puedes dejar el TextBox vacío si es nuevo
                        Expediente.Text = "";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar el expediente: " + ex.Message);
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            CargarExpediente();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            string expediente = Expediente.Text.Trim();

            if (string.IsNullOrWhiteSpace(expediente))
            {
                MessageBox.Show("El campo expediente no puede estar vacío.");
                return;
            }

            using (SqlConnection con = new SqlConnection(cadena_conexion))
            {
                try
                {
                    con.Open();

                    string query;

                    if (expedienteExiste)
                    {
                        // Ya existe -> UPDATE
                        query = "UPDATE Expedientes SET Expediente = @Expediente WHERE IdExpediente = @IdExpediente";
                    }
                    else
                    {
                        // No existe -> INSERT
                        query = "INSERT INTO Expedientes (IdExpediente, Expediente) VALUES (@IdExpediente, @Expediente)";
                    }

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Expediente", expediente);
                    cmd.Parameters.AddWithValue("@IdExpediente", idpacienteseleccionado);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Expediente guardado correctamente");

                    expedienteExiste = true; // Si era nuevo, ya existe ahora.
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el expediente: " + ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
