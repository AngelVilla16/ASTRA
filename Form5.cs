using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astra
{
    public partial class Form5 : Form
    {
        Form1 form1 = new Form1();
        
        string ruta;
        string cadena_conexion;
        public event Action CitaAgregada;
        private int idpacienteseleccionado;
        
        public Form5(int IdPaciente)
        {
            InitializeComponent();
            //Direcciones de la base de datos



            string ruta = Path.Combine(Application.StartupPath, @"Data\AstraDB.mdf");
            cadena_conexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AstraDB.mdf;Integrated Security=True;Connect Timeout=30";


            idpacienteseleccionado = IdPaciente;
        }
       
        public class Cita
        {
            public DateTime NuevaCita { get; set; }

        }

        private void btnAgendar_Click(object sender, EventArgs e)

        {
            
            
            Cita cita = new Cita();

            cita.NuevaCita = mcCita.SelectionStart;
            

            using (SqlConnection con = new SqlConnection(cadena_conexion))
            {
                try
                {
                    con.Open();
                    //Insercion a la base de datos

                    string actualizar = @"UPDATE Pacientes SET Proxima_cita = @Proxima_cita WHERE IdPaciente = @IdPaciente";

                    SqlCommand cmd = new SqlCommand(actualizar, con);
                    cmd.Parameters.AddWithValue("@Proxima_cita", cita.NuevaCita);
                    cmd.Parameters.AddWithValue("@IdPaciente", idpacienteseleccionado);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cita seleccionada para la fecha: " + cita.NuevaCita.ToShortDateString());

                    CitaAgregada?.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al agregar cita nueva " +  ex.Message);
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
