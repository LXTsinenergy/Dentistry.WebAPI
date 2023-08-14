namespace Dentistry.BLL.Exceptions
{
    public class RepositoryOperationException : Exception
    {
        public RepositoryOperationException(string repositoryName) 
            : base($"Error in {repositoryName} operation") { }
    }
}
