using CadHeladeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHeladeria
{
    public class EmpleadoCln
    {
        public static Empleado insertar(Empleado empleado)
        {
            using (var context = new LabHeladeriaEntities())
            {
                context.Empleado.Add(empleado);
                context.SaveChanges();

                return empleado;
            }
        }

        public static int actualizar(Empleado empleado)
        {
            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.Empleado.Find(empleado.id);
                existe.nombres = empleado.nombres;
                existe.primerApellido = empleado.primerApellido;
                existe.segundoApellido = empleado.segundoApellido;
                existe.fechaContratacion = empleado.fechaContratacion;
                existe.telefono = empleado.telefono;
                existe.direccion = empleado.direccion;
                existe.usuarioRegistro = empleado.usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static int eliminar(int id, string usuarioRegistro)
        {
            using (var context = new LabHeladeriaEntities())
            {
                var existe = context.Empleado.Find(id);
                existe.estado = -1;
                existe.usuarioRegistro = usuarioRegistro;
                return context.SaveChanges();
            }
        }

        public static Empleado obtenerUno(int id)
        {
            using (var context = new LabHeladeriaEntities())
            {
                return context.Empleado
                .Include("Usuario")
                .FirstOrDefault(e => e.id == id);
            }
        }

        public static List<Empleado> listar()
        {
            using (var context = new LabHeladeriaEntities())
            {
                return context.Empleado.Where(x => x.estado != -1).ToList();
            }
        }

        public static List<paUsuarioEmpleadoListar_Result> listarPa(string parametro)
        {
            using (var context = new LabHeladeriaEntities())
            {
                return context.paUsuarioEmpleadoListar(parametro).ToList();
            }
        }
    }
}
