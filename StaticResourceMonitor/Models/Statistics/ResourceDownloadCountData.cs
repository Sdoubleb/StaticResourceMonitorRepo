using System.Runtime.Serialization;

namespace StaticResourceMonitor.Models.Statistics
{
    [DataContract]
    public class ResourceDownloadCountData
    {
        [DataMember]
        public string Resource { get; set; }

        [DataMember]
        public int DownloadCount { get; set; }
    }
}