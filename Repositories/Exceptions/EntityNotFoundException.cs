namespace AngularSandbox.Repositories.Exceptions
{
    /// <summary>
    /// Exception which will be thrown if an entity can not be found.
    /// </summary>
    public class EntityNotFoundException : RepositoryException
    {
        /// <summary>
        /// Creates a new <see="EntityNotFoundException"/>
        /// </summary>
        /// <param name="id"></param>
        public EntityNotFoundException(int id) : 
            base($"The entity with the id {id} was not found in the repository.")
        {}
    }
}