using System;
using System.Collections.Generic;
using StaticResourceMonitor.Downloads;

namespace StaticResourceMonitor.Statistics
{
    partial class DownloadStatisticsCalculator
    {
        private class DownloadEqualityComparer : IEqualityComparer<DownloadInfo>
        {
            public bool Equals(DownloadInfo x, DownloadInfo y)
            {
                return String.Equals(x.Reference, y.Reference, StringComparison.InvariantCultureIgnoreCase)
                    && x.User == y.User;
            }

            public int GetHashCode(DownloadInfo obj)
            {
                // простые числа для генерации хэш-кода
                // комбинации из двух значений
                const int prime1 = 7, prime2 = 13;

                unchecked
                {
                    int hashCode = prime1;
                    hashCode = hashCode * prime2 + obj.Reference.GetHashCode();
                    hashCode = hashCode * prime2 + obj.User.GetHashCode();
                    return hashCode;
                }
            }
        }
    }
}