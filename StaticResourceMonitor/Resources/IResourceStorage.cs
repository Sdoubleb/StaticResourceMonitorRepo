namespace StaticResourceMonitor.Resources
{
    public interface IResourceStorage
    {
        ResourceInfo GetOrAddResource(string reference);
    }
}