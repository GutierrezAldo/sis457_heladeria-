using CadHeladeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHeladeria
{
    public class ClienteCln
    {
        public static int insertar(Cliente cliente)
        {

            using (var context = new LabHeladeriaEntities())
            {
                context.Cliente.Add(cliente);
                context.SaveChanges();
                return cliente.id;
            }

        }
        public static int actualizar(Cliente cliente)
        {

            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.Cliente.Find((object)cliente.id);

                existe.nombre = cliente.nombre;
                existe.ci = cliente.ci;
                existe.razonSocial = cliente.razonSocial;
                existe.telefono = cliente.telefono;
                return context.SaveChanges();
            }

        }
        public static int eliminar(int id, string usuario)
        {

            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.Cliente.Find(id);
                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }

        }
        public static Cliente obtenerUno(int id)
        {

            using (var context = new LabHeladeriaEntities())
            {
                return context.Cliente.Find(id);
            }

        }
        public static List<Cliente> listar()
        {

            using (var context = new LabHeladeriaEntities())
            {
                return context.Cliente.Where(p => p.estado == 1).ToList();
            }
        }
    }
}
