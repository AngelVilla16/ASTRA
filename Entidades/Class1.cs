using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Astra.Entidades
{ // Clase usuario para poder obtener los datos del usuario a registrar
    public class Usuario
    {//variables privadas para instanciar los metodos con get y set
        private string user;
        private string password;
        //Constructores con los metodos get y set
        public string usuario {  get=> user; set => user = value; }
        public string contraseña { get => password; set => password = value; }
        //metodo para realizar el registro
        public void Registro(string us, string cont)
        {

            usuario = us;
            contraseña = cont;
        }
        public bool Login (string us, string cont)
        {

            if (usuario == us & contraseña == cont)
            {
                return true;
            }
        }
    }
}
