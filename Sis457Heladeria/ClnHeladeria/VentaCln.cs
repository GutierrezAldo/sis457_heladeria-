using CadHeladeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHeladeria
{
    public class VentaCln
    {
        public static int insertar(Venta venta)
        {

            using (var context = new LabHeladeriaEntities())
            {
                context.Venta.Add(venta);
                context.SaveChanges();
                return venta.id;
            }

        }
        public static int actualizar(Venta venta)
        {

            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.Venta.Find((object)venta.id);

                existe.idCliente = venta.idCliente;
                existe.idUsuario = venta.idUsuario;
                return context.SaveChanges();
            }

        }
        public static int eliminar(int id, string usuario)
        {

            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.Venta.Find(id);
                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }

        }
        public static Venta obtenerUno(int id)
        {

            using (var context = new LabHeladeriaEntities())
            {
                return context.Venta.Find(id);
            }

        }
        public static List<Venta> listar()
        {

            using (var context = new LabHeladeriaEntities())
            {
                return context.Venta.Where(p => p.estado == 1).ToList();
            }
        }

        public static List<paVentaListarRango_Result> listarPa(DateTime inicio, DateTime fin)
        {
            using (var context = new LabHeladeriaEntities())
            {
                return context.paVentaListarRango(inicio, fin).ToList();
            }
        }
    }
}
