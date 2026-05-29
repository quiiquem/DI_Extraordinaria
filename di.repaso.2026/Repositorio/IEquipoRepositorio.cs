using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace di.repaso._2026.Backend.Repositorio
{
    public interface IEquipoRepositorio : IRepository<Equipo>
    {
        // Añade aquí métodos específicos de Equipo si los necesitas, por ejemplo:
        Task<IEnumerable<Equipo>> ObtenerPorCategoriaAsync(string categoria);
    }
}