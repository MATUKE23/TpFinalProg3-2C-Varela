using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public enum TipoUsuario
    {
        Normal = 1,
        Admin = 2,
        Null = 0
    }

    public class Usuario

    {
       // public int DNI { get; set; }
        public string User { get; set; }

        public string Pass { get; set; }

        public TipoUsuario TipoUsuario { get; set; }

        public Usuario(string user, string pass, bool admin) //constructor, si la instancia es de tipo admin que guarda un 1 o un 2
        {
            User = user;
            Pass = pass;
            TipoUsuario = admin ? TipoUsuario.Admin : TipoUsuario.Normal;
        }
        public Usuario()
        {

        }


    }
}
