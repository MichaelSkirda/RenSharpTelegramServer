namespace BLL.Exceptions
{
    public class ResourceNotFoundException : Exception
    {
        public ResourceNotFoundException() { }
        public ResourceNotFoundException(string resource) : base($"Resource '{resource}' wasn't found.") { }
        public ResourceNotFoundException(string resource, object key) : base($"Resource '{resource}' wasn't found by key '{key}'.") { }
    }
}
