using CadHeladeria;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClnHeladeria
{
    public class UsuarioCln
    {
        public static Usuario validar(string usuario, string clave)
        {
            using (var context = new LabHeladeriaEntities())
            {
                return context.Usuario
                    .Where(u => u.usuario1 == usuario && u.clave == clave)
                    .FirstOrDefault();
            }
        }

        public static List<Usuario> listar()
        {
            using (var context = new LabHeladeriaEntities())
            {
                return context.Usuario
                    .Where(x => x.estado == 1)
                    .OrderBy(x => x.usuario1)
                    .ToList();
            }
        }

        public static void insertar(Usuario usuario)
        {
            using (var context = new LabHeladeriaEntities())
            {
                if (usuario.estado == 0)
                {
                    usuario.estado = 1;
                }

                context.Usuario.Add(usuario);
                context.SaveChanges();
            }
        }

        public static void actualizar(Usuario usuario)
        {
            using (var context = new LabHeladeriaEntities())
            {
                var existente = context.Usuario.Find(usuario.id);
                if (existente != null)
                {
                    existente.usuario1 = usuario.usuario1;
                    existente.clave = usuario.clave;
                    existente.role = usuario.role;
                    existente.estado = usuario.estado;
                    existente.usuarioRegistro = usuario.usuarioRegistro;

                    context.SaveChanges();
                }
            }
        }

        public static Usuario obtenerUno(int id)
        {
            using (var context = new LabHeladeriaEntities())
            {
                return context.Usuario.FirstOrDefault(x => x.id == id);
            }
        }

        public static bool existeUsuario(string usuario)
        {
            using (var context = new LabHeladeriaEntities())
            {
                int count = context.Usuario
                    .Count(u => u.usuario1 == usuario);

                return count > 0;
            }
        }
    }
}
