using System.Collections.Generic;
using StaticResourceMonitor.Downloads;

namespace StaticResourceMonitor.Statistics
{
    partial class DownloadStatisticCalculator
    {
        // загрузки в общем случае не стоит сравнивать на основании значений их свойств,
        // поэтому создаём comparer для данного конкретного случая
        private class DownloadEqualityComparer : IEqualityComparer<DownloadInfo>
        {
            public bool Equals(DownloadInfo x, DownloadInfo y)
            {
                return x.Resource == y.Resource && x.User == y.User;
            }

            public int GetHashCode(DownloadInfo obj)
            {
                // простые числа для генерации хэш-кода
                // комбинации из двух значений
                const int prime1 = 7, prime2 = 13;

                unchecked
                {
                    int hashCode = prime1;
                    hashCode = hashCode * prime2 + obj.Resource.GetHashCode();
                    hashCode = hashCode * prime2 + obj.User.GetHashCode();
                    return hashCode;
                }
            }
        }
    }
}