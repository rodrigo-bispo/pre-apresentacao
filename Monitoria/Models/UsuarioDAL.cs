using Monitoria.Controllers;
using System.Linq;

namespace Monitoria.Models
{
    public class UsuarioDAL 

    {
        public static bool VerificaEmail(string email)
        {
            using (MonitoriaEntities5 dc = new MonitoriaEntities5())
            {
                var existeEmail = (from u in dc.Usuarios
                                   where u.Email == email
                                   select u).FirstOrDefault();
                if (existeEmail != null)
                    return true;
                else
                    return false;
            }

        }
    }
}
    

