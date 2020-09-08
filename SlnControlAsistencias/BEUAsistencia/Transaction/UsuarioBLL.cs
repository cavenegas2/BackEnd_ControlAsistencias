using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEUAsistencia.Transaction
{
    public class UsuarioBLL
    {
        public static Usuario Validate(Usuario usuario){
            Entities db = new Entities();
            return db.Usuario.FirstOrDefault(x => x.nombre == usuario.nombre && x.contrasena == usuario.contrasena);
        }

    }
}
