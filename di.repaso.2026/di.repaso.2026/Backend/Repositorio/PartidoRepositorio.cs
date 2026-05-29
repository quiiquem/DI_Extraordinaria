using di.repaso._2026.Backend.Modelo;
using Microsoft.Extensions.Logging;

namespace di.repaso._2026.Backend.Repositorio
{
    /// <summary>
    /// Repositorio concreto para la entidad Partido.
    /// Hereda CRUD de GenericRepository{Partido} e implementa IPartidoRepositorio.
    /// </summary>
    public class PartidoRepositorio : GenericRepository<Partido>, IPartidoRepositorio
    {
        public PartidoRepositorio(NbaContext context, ILogger<GenericRepository<Partido>> logger)
            : base(context, logger)
        {
        }

    }
}