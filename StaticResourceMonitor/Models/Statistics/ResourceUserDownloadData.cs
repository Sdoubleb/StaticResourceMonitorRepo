using System;
using System.Runtime.Serialization;

namespace StaticResourceMonitor.Models.Statistics
{
    [DataContract]
    public class ResourceUserDownloadData
    {
        [DataMember]
        public string Resource { get; set; }

        [DataMember]
        public Guid User { get; set; }

        [DataMember]
        public DateTime LastDownloadDateTime { get; set; }
    }
}