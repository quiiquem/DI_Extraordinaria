using di.repaso._2026.Backend.Modelo;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading;

namespace di.repaso._2026.Backend.Repositorio
{
    /// <summary>
    /// Repositorio específico para la entidad Equipo.
    /// Hereda la funcionalidad CRUD de GenericRepository{Equipo} e implementa IEquipoRepositorio.
    /// </summary>
    public class EquipoRepositorio : GenericRepository<Equipo>, IEquipoRepositorio
    {
        private NbaContext contexto;
        public EquipoRepositorio(NbaContext context, ILogger<GenericRepository<Equipo>> logger)
            : base(context, logger)
        {
            contexto = context;
        }

        // Añade aquí métodos específicos para Equipo si los necesitas, p. ej.:
        public int getLastId()
        {
            Jugadore ju = contexto.Set<Jugadore>().OrderByDescending(j => j.Codigo).FirstOrDefault();
            return ju.Codigo;
        }

        public bool NombreUnico(string nombre)
        {
            return contexto.Set<Equipo>().Where(e => e.Nombre == nombre).Count() == 0;
        }

        public List<string> getDivisiones()
        {
            var result = from eq in contexto.Equipos
                         group eq by eq.Division into d
                         select d.Key;
            return result.ToList();

            /*var result = contexto.Database.SqlQuery<string>("select Division from equipos group by Division").ToList();
            return result;*/
        }

        public List<string> getConferencias()
        {
            var confs = from eq in contexto.Equipos
                        group eq by eq.Conferencia into c
                        select c.Key;
            return confs.ToList();
        }
    }
}