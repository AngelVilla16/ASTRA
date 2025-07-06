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
using System.IO;

namespace Astra
{
    public partial class Form3 : Form
    {
        OleDbConnection conn = new OleDbConnection();
        string ruta;
        string conexion;
        public Form3()
        {
            InitializeComponent();
            //Direcciones de la base de datos
            ruta = @"C:\Users\Angel\Documents\Astra.accdb";
            conexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Angel\Documents\Astra.accdb;";
        }
        //Metodo para cargar pacientes en el datagridview
        private void CargarPacientes()
        {
            string conexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Angel\Documents\Astra.accdb;";

            using (OleDbConnection conn = new OleDbConnection(conexion))
            {
                try
                {
                    conn.Open();
                    string consulta = "SELECT * FROM Pacientes";
                    OleDbDataAdapter adaptador = new OleDbDataAdapter(consulta, conn);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvPacientes.DataSource = tabla;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar pacietne" + ex.Message);
                }

            }
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            CargarPacientes();
        }

        private void btnAgregarPaciente_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            //Suscribirse al evento
            form4.PacienteAgregado += () =>
            {
                CargarPacientes();
            };
           form4.ShowDialog();
        }
    }
}
