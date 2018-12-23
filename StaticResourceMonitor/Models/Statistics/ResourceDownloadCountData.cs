using System.Runtime.Serialization;

namespace StaticResourceMonitor.Models.Statistics
{
    // снабжаем атрибутами для возможнсти сериализации в XML при ответе для браузера
    [DataContract]
    public class ResourceDownloadCountData
    {
        [DataMember]
        public string Resource { get; set; }

        [DataMember]
        public int DownloadCount { get; set; }
    }
}