using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace di.repaso._2026.Backend.Repositorio
{
    /// <summary>
    /// Contrato de repositorio genérico para operaciones CRUD comunes usando Entity Framework Core.
    /// Las implementaciones proporcionan un envoltorio ligero alrededor de un DbContext y su DbSet{T}.
    /// </summary>
    /// <typeparam name="T">Tipo de entidad.</typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Construye un <see cref="IQueryable{T}"/> sobre el conjunto de entidades.
        /// Úsalo para componer consultas (filtrado, includes, paginación, proyección).
        /// </summary>
        /// <param name="asNoTracking">
        /// Si es true, la consulta resultante usará <c>AsNoTracking()</c> 
        /// (recomendado para lecturas sin modificación).
        /// </param>
        /// <param name="includes">Propiedades de navegación a incluir en la consulta.</param>
        /// <returns>Un <see cref="IQueryable{T}"/> componible sobre el conjunto de entidades.</returns>
        IQueryable<T> Query(bool asNoTracking = true, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Busca una entidad por su valor de clave primaria de forma asíncrona.
        /// </summary>
        /// <param name="id">Valor de la clave primaria. Para claves compuestas usar la aproximación adecuada.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>La entidad si se encuentra; en caso contrario, null.</returns>
        Task<T?> GetByIdAsync(object id);

        /// <summary>
        /// Devuelve la primera entidad que cumpla el predicado proporcionado, o null si no hay coincidencias.
        /// </summary>
        /// <param name="predicate">Expresión de filtrado.</param>
        /// <param name="asNoTracking">Si es true, la consulta se ejecutará sin tracking.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <param name="includes">Propiedades de navegación a incluir.</param>
        /// <returns>Primera entidad que cumple la condición o null.</returns>
        Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate, bool asNoTracking = true, 
            CancellationToken cancellationToken = default, params Expression<Func<T, object>>[] includes);

        /// <summary>
        /// Recupera todas las entidades del tipo <typeparamref name="T"/> desde el DbSet.
        /// Este método devuelve entidades trackeadas. Usa <see cref="Query"/> para comportamiento sin tracking o incluir navegación.
        /// </summary>
        /// <returns>Lista con todas las entidades.</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        /// Busca las entidades que coinciden con el predicado proporcionado.
        /// </summary>
        /// <param name="predicate">Expresión de filtrado.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <param name="asNoTracking">Si es true, la consulta se ejecutará sin tracking.</param>
        /// <param name="includes">Propiedades de navegación a incluir.</param>
        /// <returns>Lista con las entidades que coinciden.</returns>
        Task<List<T>> FindAsync(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken = default, bool asNoTracking = true, params Expression<Func<T, object>>[] includes);
        /// <summary>
        /// Este método busca la primera entidad que cumple con el filtro proporcionado.
        /// </summary>
        /// <param name="filter">Expresión booleana que filtra la lista</param>
        /// <returns>Devuelve la entidad o nulo en caso de no encontrar nada</returns>
        /// <exception cref="DataAccessException"></exception>
        Task<T?> GetFirstOrDefaultAsync(
            Expression<Func<T, bool>> filter);
        /// <summary>
        /// Añade una entidad y persiste los cambios en la base de datos.
        /// Este método llama internamente a <see cref="SaveChangesAsync"/>.
        /// </summary>
        /// <param name="entity">Entidad a añadir.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        Task AddAsync(T entity);

        /// <summary>
        /// Añade múltiples entidades y persiste los cambios en la base de datos.
        /// Este método llama internamente a <see cref="SaveChangesAsync"/>.
        /// </summary>
        /// <param name="entities">Entidades a añadir.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        Task AddRangeAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default);

        /// <summary>
        /// Marca una entidad como modificada y persiste los cambios en la base de datos.
        /// Este método llama internamente a <see cref="SaveChangesAsync"/>.
        /// </summary>
        /// <param name="entity">Entidad a actualizar.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        Task UpdateAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Elimina una entidad y persiste los cambios en la base de datos.
        /// Este método llama internamente a <see cref="SaveChangesAsync"/>.
        /// </summary>
        /// <param name="entity">Entidad a eliminar.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        Task RemoveAsync(T entity, CancellationToken cancellationToken = default);

        /// <summary>
        /// Elimina una entidad por clave primaria si existe y persiste los cambios en la base de datos.
        /// Este método llama internamente a <see cref="SaveChangesAsync"/>.
        /// </summary>
        /// <param name="id">Valor de la clave primaria.</param>
        /// <param name="cancellationToken">Token de cancelación.</param>
        Task RemoveByIdAsync(object id);

        /// <summary>
        /// Persiste los cambios pendientes en la base de datos y devuelve el número de entradas afectadas.
        /// Úsalo cuando necesites control explícito sobre SaveChanges (por ejemplo para agrupar operaciones).
        /// </summary>
        /// <param name="cancellationToken">Token de cancelación.</param>
        /// <returns>Número de entradas de estado escritas en la base de datos.</returns>
        Task<int> SaveChangesAsync();
    }
}