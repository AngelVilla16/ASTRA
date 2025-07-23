using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Astra
{
    public partial class Form6 : Form
    {
        string conexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Angel\Documents\Astra.accdb;";
        public Action pacienteAgregadoi;
        Form3 form3 = new Form3();
        private int idpacienteseleccionado;
        public class Consulta
        {
            string NombrePaciente { get; set; }
            int Edad { get; set; }
            DateTime FechaUltimaCita { get; set; }
            string Motivo { get; set; }
            string Diagnostico { get; set; }
            string Tratamiento { get; set; }
        }
        public Form6(int IdPaciente)
        {
            InitializeComponent();
            idpacienteseleccionado = IdPaciente;
           
        }
        
        private void btnConfirmar_Click(object sender, EventArgs e)
        {

        }
    }
}
