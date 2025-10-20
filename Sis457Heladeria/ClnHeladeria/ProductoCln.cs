using CadHeladeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHeladeria
{
    public class ProductoCln
    {
        public static int insertar(Producto producto)
        {

            using (var context = new LabHeladeriaEntities())
            {
                context.Producto.Add(producto);
                context.SaveChanges();
                return producto.id;
            }

        }
        public static int actualizar(Producto producto)
        {

            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.Producto.Find(producto.id);

                existe.nombre = producto.nombre;
                existe.precio = producto.precio;
                return context.SaveChanges();
            }

        }
        public static int eliminar(int id, string usuario)
        {

            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.Producto.Find(id);
                existe.estado = -1;
                existe.usuarioRegistro = usuario;
                return context.SaveChanges();
            }

        }
        public static Producto obtenerUno(int id)
        {

            using (var context = new LabHeladeriaEntities())
            {
                return context.Producto.Find(id);
            }

        }
        public static List<Producto> listar()
        {

            using (var context = new LabHeladeriaEntities())
            {
                return context.Producto.Where(p => p.estado == 1).ToList();
            }
        }
        public static List<paProductoListar_Result> listarPa(string parametro)
        {
            using (var context = new LabHeladeriaEntities())
            {
                return context.paProductoListar(parametro).ToList();
            }
        }
    }
}
