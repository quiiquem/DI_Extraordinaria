using di.repaso._2026.Backend.Modelo;

namespace di.repaso._2026.Backend.Repositorio
{
    /// <summary>
    /// Contrato específico para repositorio de Jugador.
    /// Extiende las operaciones genéricas definidas en IGenericRepository{Jugadore}.
    /// </summary>
    public interface IJugadorRepositorio : IGenericRepository<Jugadore>
    {
        public int getLastId();
        public List<string> getPosiciones();
        public List<string> getTemporadas();

    }
}