using di.repaso._2026.Backend.Modelo;
using di.repaso._2026.MVVM.Base;
using Microsoft.Extensions.Logging;

namespace di.repaso._2026.Backend.Repositorio
{
    /// <summary>
    /// Repositorio concreto para la entidad Jugadore.
    /// Hereda CRUD de GenericRepository{Jugadore} e implementa IJugadorRepositorio.
    /// </summary>
    public class JugadorRepositorio : GenericRepository<Jugadore>, IJugadorRepositorio
    {
        private NbaContext contexto;
        public JugadorRepositorio(NbaContext context, ILogger<GenericRepository<Jugadore>> logger)
            : base(context, logger)
        {
            contexto = context;
        }

        public int getLastId()
        {
            Jugadore ju = contexto.Set<Jugadore>().OrderByDescending(j => j.Codigo).FirstOrDefault();
            return ju.Codigo;
        }

        public List<string> getPosiciones()
        {
            var pos = from ju in contexto.Jugadores
                      group ju by ju.Posicion into p
                      select p.Key;
            return pos.ToList();
        }

        public List<string> getTemporadas()
        {
            var result = from par in contexto.Partidos
                         group par by par.Temporada into t
                         select t.Key;
            return result.ToList();
        }
    }
}