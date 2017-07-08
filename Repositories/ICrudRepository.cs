using System.Linq;
using System.Threading.Tasks;
using AngularSandbox.Repositories.Entities;

namespace AngularSandbox.Repositories
{
    /// <summary>
    /// Interface for an entity repository, which supports
    /// asynchronous Create, Read, Update and Delete operations.
    /// </summary>
    public interface ICrudRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Creates a new entity.
        /// </summary>
        /// <param name="entity"> The entity which has to be created. </param>
        /// <returns> Task for the asyncronous operation which holds the created entity. </returns> <summary>
        /// <exception cref="RepositoryException"> Thrown if the operation fails. </exception>
        Task<TEntity> CreateAsync(TEntity entity);
        
        /// <summary>
        /// Gets a query which allows to read and filter all the entities.
        /// </summary>
        /// <returns> Queryable entities. </returns>
        /// <exception cref="RepositoryException"> Thrown if the operation fails. </exception>
        IQueryable<TEntity> ReadAll();

        /// <summary>
        /// Updates the given entity.
        /// </summary>
        /// <param name="entity"> The entity which has to be updated. </param>
        /// <returns> Task for the asyncronous operation which holds the updated entity. </returns>
        /// <exception cref="RepositoryException"> Thrown if the operation fails. </exception>
        Task<TEntity> UpdateAsync(TEntity entity);

        /// <summary>
        /// Deletes the given entity.
        /// </summary>
        /// <param name="entity"> The entity which has to be deleted. </param>
        /// <returns> Task for the asyncronous operation. </returns>
        /// <exception cref="RepositoryException"> Thrown if the operation fails. </exception>
        /// <exception cref="EntityNotFoundException"> Thrown if the entity can not be found. </exception>
        Task DeleteAsync(TEntity entity);
    }
}