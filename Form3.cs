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
            //Conexion y uso de la base de datos
            using (OleDbConnection conn = new OleDbConnection(conexion))
            {//Probamos la conexion y si se abre la base de datos
                try
                {
                    conn.Open();
                    //Seleccionamos los pacientes y creamos un adaptador
                    //El adaptador al momento de creear una tabla lo que hace es rellenar esta tabla con los datos actualizados del datagrid
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
        //Al momento de abrir el formulario se manda a llamar al metodo de carga pacientes
        private void Form3_Load(object sender, EventArgs e)
        {
            CargarPacientes();
        }
        //El boton de agregar pacientes
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor seleccione un paciente a eliminar");
                return;
            }
            DialogResult confirmacion = MessageBox.Show("¿Esta seguro de que desea eliminar al paciente? ", "Confirmar eliminacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.No)
                return;

            int idpaciente = Convert.ToInt32
                (dgvPacientes.SelectedRows[0].Cells["IdPaciente"].Value);
            string conexion = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Angel\Documents\Astra.accdb;";

            using (OleDbConnection conn = new OleDbConnection(conexion))
            {
                try
                {
                    conn.Open();
                    string eliminar = "DELETE FROM Pacientes WHERE IdPaciente = ?";
                    OleDbCommand cmd = new OleDbCommand(eliminar, conn);
                    cmd.Parameters.AddWithValue("?", idpaciente);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Paciente eliminado correctamente");


                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se pudo eliminar el paciente " + ex.Message);

                }
            }
            CargarPacientes();

        }

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente para agendar su cita por favor");
                return;
            }
            int id = int.Parse(dgvPacientes.CurrentRow.Cells["IdPaciente"].Value.ToString());
            Form5 form5 = new Form5(id);
            form5.CitaAgregada += () =>
            {
                CargarPacientes();
            };
            
            
            form5.ShowDialog();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPacientes.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccione un paciente para agendar su cita por favor");
                return;
            }
            int id = int.Parse(dgvPacientes.CurrentRow.Cells["IdPaciente"].Value.ToString());
            Form5 form5 = new Form5(id);
            form5.CitaAgregada += () =>
            {
                CargarPacientes();
            };


            form5.ShowDialog();
        }
    }
}
