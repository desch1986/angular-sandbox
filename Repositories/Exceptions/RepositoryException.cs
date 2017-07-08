using System;

namespace AngularSandbox.Repositories.Exceptions
{
    /// <summary>
    /// Exception for failed repository operation.
    /// </summary>
    public class RepositoryException : Exception
    {
        /// <summary>
        /// Creates a new <see="RepositoryException"/>.
        /// </summary>
        /// <param name="message"> The exceptional message. </param>
        public RepositoryException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates a new <see="RepositoryException"/>.
        /// </summary>
        /// <param name="message"> The exceptional message. </param> <summary>
        /// <param name="innerException"> An inner exception which points to this exception. </param>
        public RepositoryException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}