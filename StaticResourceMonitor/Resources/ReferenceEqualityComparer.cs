using System;
using System.Collections.Generic;
using StaticResourceMonitor.Helpers;

namespace StaticResourceMonitor.Resources
{
    partial class ResourceStorage
    {
        // реализует сравнение двух декодированных ссылок, приведённых к нижнему регистру
        private class ReferenceEqualityComparer : IEqualityComparer<string>
        {
            public bool Equals(string x, string y)
                => String.Equals(Utils.DecodeUrl(x), Utils.DecodeUrl(y),
                    StringComparison.InvariantCultureIgnoreCase);

            public int GetHashCode(string obj)
                => Utils.DecodeUrl(obj).GetHashCode();
        }
    }
}