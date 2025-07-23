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
        string conexion;
        public event Action CitaAgregada;
        private int idpacienteseleccionado;
        
        public Form5(int IdPaciente)
        {
            InitializeComponent();
            //Direcciones de la base de datos
            
            conexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AstraDB;Integrated Security=True";
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
            

            using (SqlConnection con = new SqlConnection(conexion))
            {
                try
                {
                    con.Open();
                    //Insercion a la base de datos

                    string actualizar = @"UPDATE Pacientes SET Proxima_cita = ? WHERE IdPaciente = ?";

                    SqlCommand cmd = new SqlCommand(actualizar, con);
                    cmd.Parameters.AddWithValue("?", cita.NuevaCita);
                    cmd.Parameters.AddWithValue("?", idpacienteseleccionado);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cita seleccionada para la fecha: " + cita.NuevaCita);

                    CitaAgregada?.Invoke();
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al agregar cita nueva " +  ex.Message);
                }
            }
        }
    }
}
