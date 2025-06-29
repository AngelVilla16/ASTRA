
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Astra
{
    public partial class Form1 : Form
    {
        public Form1(Form2 form2)
        {
            InitializeComponent();
           
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string usuario, password;

            usuario = txtUsuario.Text;
            password = txtContraseña.Text;

            if(usuario == "admin" && password== "admin")
            {


            }
          
        }
    }

       
    
}
