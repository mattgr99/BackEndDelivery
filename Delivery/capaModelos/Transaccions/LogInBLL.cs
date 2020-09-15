using capaModelos.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capaModelos.Transaccions
{
    public class LogInBLL
    {
        public static LOG_IN Validate(LOG_IN cuenta)
        {
            DeliveryEntidades1 db = new DeliveryEntidades1();
            return db.LOG_IN.FirstOrDefault(x => x.usuario == cuenta.usuario
                && x.contrasena == cuenta.contrasena);

            /*            foreach (var item in db.Usuarios.ToList())
                        {
                            if (item.correo == persona.correo && item.password == persona.password)
                            {
                                return item;
                            }
                        }
                        return null;*/

        }
    }
}
