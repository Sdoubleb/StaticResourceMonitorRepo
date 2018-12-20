using System;
using System.Collections.Concurrent;

namespace StaticResourceMonitor.Resources
{
    public partial class ResourceStorage : IResourceStorage
    {
        private const int INITIAL_CAPACITY = Byte.MaxValue + 1;

        private ConcurrentDictionary<string, ResourceInfo> _resources
            = new ConcurrentDictionary<string, ResourceInfo>(Environment.ProcessorCount, INITIAL_CAPACITY,
                new ReferenceEqualityComparer());

        public ResourceInfo GetOrAddResource(string reference)
        {
            return _resources.GetOrAdd(reference, r => new ResourceInfo(r));
        }
    }
}