using CadHeladeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHeladeria
{
    public class VentaDetalleCln
    {
        public static int insertar(VentaDetalle ventaDetalle)
        {

            using (var context = new LabHeladeriaEntities())
            {
                context.VentaDetalle.Add(ventaDetalle);
                context.SaveChanges();
                return ventaDetalle.id;
            }

        }
        public static int actualizar(VentaDetalle ventaDetalle)
        {

            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.VentaDetalle.Find((object)ventaDetalle.id);

                existe.idVenta = ventaDetalle.idVenta;
                existe.idProducto = ventaDetalle.idProducto;
                existe.cantidad = ventaDetalle.cantidad;
                existe.precioUnitario = ventaDetalle.precioUnitario;
                existe.total = ventaDetalle.total;
                existe.tipoPago = ventaDetalle.tipoPago;
                return context.SaveChanges();
            }

        }
        public static int eliminar(int id, string usuario)
        {

            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.VentaDetalle.Find(id);
                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }

        }
        public static VentaDetalle obtenerUno(int id)
        {

            using (var context = new LabHeladeriaEntities())
            {
                return context.VentaDetalle.Find(id);
            }

        }
        public static List<VentaDetalle> listar()
        {

            using (var context = new LabHeladeriaEntities())
            {
                return context.VentaDetalle.Where(p => p.estado == 1).ToList();
            }
        }
    }
}
