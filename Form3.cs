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
            // Aseguramos que la conexión permita múltiples lectores
            string cadenaConexion = cadena_conexion + ";MultipleActiveResultSets=True";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                try
                {
                    con.Open();

                    // 1. Cargar todos los pacientes
                    string consultaPacientes = "SELECT IdPaciente, Nombre, Apellido, Edad, Altura, Peso FROM Pacientes";
                    DataTable tablaPacientes = new DataTable();
                    using (SqlDataAdapter adaptador = new SqlDataAdapter(consultaPacientes, con))
                    {
                        adaptador.Fill(tablaPacientes);
                    }

                    // 2. Crear columnas extra en memoria
                    if (!tablaPacientes.Columns.Contains("Alergias"))
                        tablaPacientes.Columns.Add("Alergias", typeof(string));
                    if (!tablaPacientes.Columns.Contains("Padecimientos"))
                        tablaPacientes.Columns.Add("Padecimientos", typeof(string));
                    if(!tablaPacientes.Columns.Contains("Proxima_cita"))
                        tablaPacientes.Columns.Add("Proxima_cita", typeof(DateTime));

                    // 3. Recorrer pacientes y obtener datos relacionados
                    foreach (DataRow fila in tablaPacientes.Rows)
                    {
                        int idPaciente = Convert.ToInt32(fila["IdPaciente"]);

                        // Obtener alergias
                        List<string> listaAlergias = new List<string>();
                        using (SqlCommand cmdAlergias = new SqlCommand(
                            "SELECT Alergia FROM Alergias WHERE IdPaciente = @IdPaciente", con))
                        {
                            cmdAlergias.Parameters.AddWithValue("@IdPaciente", idPaciente);
                            using (SqlDataReader dr = cmdAlergias.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    listaAlergias.Add(dr["Alergia"].ToString());
                                }
                            }
                        }
                        fila["Alergias"] = string.Join(", ", listaAlergias);

                        // Obtener padecimientos
                        List<string> listaPadecimientos = new List<string>();
                        using (SqlCommand cmdPadecimientos = new SqlCommand(
                            "SELECT Padecimiento FROM Padecimientos WHERE IdPaciente = @IdPaciente", con))
                        {
                            cmdPadecimientos.Parameters.AddWithValue("@IdPaciente", idPaciente);
                            using (SqlDataReader dr = cmdPadecimientos.ExecuteReader())
                            {
                                while (dr.Read())
                                {
                                    listaPadecimientos.Add(dr["Padecimiento"].ToString());
                                }
                            }
                        }
                        fila["Padecimientos"] = string.Join(", ", listaPadecimientos);
                        // Obtener proxima cita
                        using (SqlCommand cmdCita = new SqlCommand(
                            "SELECT Proxima_cita FROM Pacientes WHERE IdPaciente = @IdPaciente", con))
                        {
                            cmdCita.Parameters.AddWithValue("@IdPaciente", idPaciente);
                            object cita = cmdCita.ExecuteScalar();
                            if (cita != null && cita != DBNull.Value)
                            {
                                fila["Proxima_cita"] = Convert.ToDateTime(cita);
                            }
                            else
                            {
                                fila["Proxima_cita"] = DBNull.Value; // Si no hay cita, dejamos el valor como nulo
                            }
                        }
                    }

                    // 4. Mostrar en el DataGridView
                    dgvPacientes.DataSource = tablaPacientes;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error de base de datos: " + ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error inesperado: " + ex.Message);
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
           

            using (SqlConnection conn = new SqlConnection(cadena_conexion))
            {
                try
                {
                    conn.Open();
                    //Al usar claves foraneas el orden de eliminacion es importante
                    string eliminarPadecimientos = "DELETE FROM Padecimientos WHERE IdPaciente = @IdPaciente";
                    SqlCommand cmdPadecimientos = new SqlCommand(eliminarPadecimientos, conn);
                    cmdPadecimientos.Parameters.AddWithValue("@IdPaciente", idpaciente);
                    cmdPadecimientos.ExecuteNonQuery();

                    string eliminarAlergias = "DELETE FROM Alergias WHERE IdPaciente = @IdPaciente";
                    SqlCommand cmdAlergias = new SqlCommand(eliminarAlergias, conn);
                    cmdAlergias.Parameters.AddWithValue("@IdPaciente", idpaciente);
                    cmdAlergias.ExecuteNonQuery();

                    string eliminarPaciente = "DELETE FROM Pacientes WHERE IdPaciente = @IdPaciente";
                    SqlCommand cmd = new SqlCommand(eliminarPaciente, conn);
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
           

             
            object valor = dgvPacientes.CurrentRow.Cells["Proxima_cita"].Value;

            if (string.IsNullOrEmpty(valor.ToString()))
            {
                MessageBox.Show("No hay cita agendada, error al eliminar");
                return;
            }
            
            DialogResult confirmacion = MessageBox.Show("¿Esta seguro de que desea eliminar la cita del paciente?", "Confirmar eliminacion ", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirmacion == DialogResult.No)
                return;
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
                    MessageBox.Show("Cita eliminada correctamente " );
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

        private void Minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Maximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
