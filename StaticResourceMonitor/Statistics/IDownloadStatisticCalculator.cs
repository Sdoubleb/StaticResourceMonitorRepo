using System.Collections.Generic;

namespace StaticResourceMonitor.Statistics
{
    /// <summary>
    /// Подсчитывает статистику загрузок ресурсов.
    /// </summary>
    public interface IDownloadStatisticCalculator
    {
        /// <summary>
        /// Возвращает статистику загрузок ресурсов:
        /// время последней загрузки для каждого пользователя.
        /// </summary>
        IEnumerable<ResourceUserDownload> GetUserDownloadStatistics();


        /// <summary>
        /// Возвращает статистику загрузок ресурсов:
        /// количество загрузок уникальными пользователями.
        /// </summary>
        IEnumerable<ResourceDownloadCount> GetDownloadCountStatistics();
    }
}