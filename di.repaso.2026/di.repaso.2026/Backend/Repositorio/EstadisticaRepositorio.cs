using di.repaso._2026.Backend.Modelo;
using Microsoft.Extensions.Logging;

namespace di.repaso._2026.Backend.Repositorio
{
    /// <summary>
    /// Repositorio concreto para la entidad Estadistica.
    /// Hereda CRUD de GenericRepository{Estadistica} e implementa IEstadisticaRepositorio.
    /// </summary>
    public class EstadisticaRepositorio : GenericRepository<Estadistica>, IEstadisticaRepositorio
    {
        public EstadisticaRepositorio(NbaContext context, ILogger<GenericRepository<Estadistica>> logger)
            : base(context, logger)
        {
        }

    }
}