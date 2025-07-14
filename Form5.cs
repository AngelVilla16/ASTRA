using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Astra
{
    public partial class Form5 : Form
    {
        Form1 form1 = new Form1();
        OleDbConnection conn = new OleDbConnection();
        string ruta;
        string conexion;
        public event Action CitaAgregada;
        private int idpacienteseleccionado;
        
        public Form5(int IdPaciente)
        {
            InitializeComponent();
            //Direcciones de la base de datos
            ruta = @"C:\Users\Angel\Documents\Astra.accdb";
            conexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Angel\Documents\Astra.accdb;";
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
            

            using (OleDbConnection con = new OleDbConnection(conexion))
            {
                try
                {
                    con.Open();
                    //Insercion a la base de datos

                    string actualizar = @"UPDATE Pacientes SET Proxima_cita = ? WHERE IdPaciente = ?";

                    OleDbCommand cmd = new OleDbCommand(actualizar, con);
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
