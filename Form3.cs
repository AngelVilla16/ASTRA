using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.IO;


namespace Astra
{
    public partial class Form3 : Form
    {
      
        string ruta;
        string cadena_conexion;
        public Form3()
        {
            InitializeComponent();
            //Direcciones de la base de datos



            string ruta = Path.Combine(Application.StartupPath, @"Data\AstraDB.mdf");
            cadena_conexion = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\\AstraDB.mdf;Integrated Security=True;Connect Timeout=30";


        }
        //Metodo para cargar pacientes en el datagridview
        private void CargarPacientes()
        {
            //La base de datos conexion apunta al archivo local de la base de datos de sqlclient

            // Conexion y uso de la base de datos
            
            using (SqlConnection con = new SqlConnection(cadena_conexion))
            {//Probamos la conexion y si se abre la base de datos
                try
                {
                    con.Open();
                    //Seleccionamos los pacientes y creamos un adaptador
                    //El adaptador al momento de creear una tabla lo que hace es rellenar esta tabla con los datos actualizados del datagrid
                    string consulta = "SELECT * FROM Pacientes";

                    // --- INICIO DE LA CORRECCIÓN SOLICITADA ---
                    // Cambiado: SqliteDataReader (no se instancia directamente)
                    // Cambiado: adaptador.Fill(tabla) (no existe, se usa tabla.Load(reader))

                    // Creamos un comando SQLite para ejecutar la consulta
                    using (SqlCommand comando = new SqlCommand(consulta, con))
                    {
                        // Ejecutamos el comando y obtenemos un lector de datos
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            DataTable tabla = new DataTable();
                            // Llenamos el DataTable con los datos del lector
                            tabla.Load(reader); // Esta es la función equivalente a 'Fill' para DataTable con un DataReader

                            dgvPacientes.DataSource = tabla;
                        } // El DataReader se cerrará automáticamente aquí
                    } // El comando se liberará automáticamente aquí
                      // --- FIN DE LA CORRECCIÓN SOLICITADA ---

                }
                catch (SqlException ex) // Cambiado: Exception -> SQLiteException para manejo más específico
                {
                    MessageBox.Show("Error al cargar pacientes: " + ex.Message); // Mensaje mejorado
                }
                catch (Exception ex) // Para capturar cualquier otro tipo de excepción no relacionada con SQLite
                {
                    MessageBox.Show("Error inesperado al cargar pacientes: " + ex.Message);
                }

            } // La conexión se cerrará automáticamente aquí gracias al 'using'
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
           

            using (SqlConnection conn = new SqlConnection(cadena_conexion))
            {
                try
                {
                    conn.Open();
                    string eliminar = "DELETE FROM Pacientes WHERE IdPaciente = @IdPaciente";
                    SqlCommand cmd = new SqlCommand(eliminar,conn);
                    cmd.Parameters.AddWithValue("@IdPaciente", idpaciente);
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

        //Eliminar cita
        private void btnEliminar_Click(object sender, EventArgs e)
        {//Variables para obtener los valores de las celdas de acuerdo a su tipo de dato: Fecha y numerico
            DateTime cita;

             
            object valor = dgvPacientes.CurrentRow.Cells["Proxima_cita"].Value;

            if (string.IsNullOrEmpty(valor.ToString()))
            {
                MessageBox.Show("No hay cita agendada, error al eliminar");
            }
            else
            {
                cita = DateTime.Parse(dgvPacientes.CurrentRow.Cells["Proxima_cita"].Value.ToString());
            }

                int idpaciente = int.Parse(dgvPacientes.CurrentRow.Cells["IdPaciente"].Value.ToString());
            //Variable de nuestra ruta de datos
           
            
            using (SqlConnection con = new SqlConnection(cadena_conexion))
            { 
                try
                {
                    con.Open();
                    //Actualizacion de la base de datos
                    string update = "UPDATE Pacientes SET Proxima_cita = NULL WHERE IdPaciente = @IdPaciente";
                    //Comando para agregar valores y actualizar
                    SqlCommand cmd = new SqlCommand(update, con);
                    
                    cmd.Parameters.AddWithValue("@IdPaciente", idpaciente);
                   

                    cmd.ExecuteNonQuery();    

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Conexion fallida " + ex.Message);
                }
            }
            CargarPacientes();
        }

        private void btnExpediente_Click(object sender, EventArgs e)
        {
            int id = int.Parse(dgvPacientes.CurrentRow.Cells["IdPaciente"].Value.ToString());
            if(id == 0)
            {
                MessageBox.Show("Seleccione un paciente para ver su expediente");
                return;
            }
            Form6 form6 = new Form6(id);
           
            form6.ShowDialog();
        }
    }
}
