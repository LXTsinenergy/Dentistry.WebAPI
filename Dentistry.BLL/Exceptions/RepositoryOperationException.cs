namespace Dentistry.BLL.Exceptions
{
    public class RepositoryOperationException : Exception
    {
        public RepositoryOperationException(string repositoryName, string exceptionMessage) 
            : base($"Error in {repositoryName} operation: \"{exceptionMessage}\"") { }
    }
}
