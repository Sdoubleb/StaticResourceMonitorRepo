using System;
using System.Runtime.Serialization;

namespace StaticResourceMonitor.Models.Statistics
{
    // снабжаем атрибутами для возможнсти сериализации в XML при ответе для браузера
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