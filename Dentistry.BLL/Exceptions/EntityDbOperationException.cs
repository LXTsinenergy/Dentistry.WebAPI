namespace Dentistry.BLL.Exceptions
{
    public class EntityDbOperationException : Exception
    {
        public EntityDbOperationException(object entity, string repositoryName) :
            base($"The {repositoryName} could not perform an operation with the entity: {entity}") { }
    }
}
