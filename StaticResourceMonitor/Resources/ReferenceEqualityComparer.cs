using System;
using System.Collections.Generic;
using StaticResourceMonitor.Helpers;

namespace StaticResourceMonitor.Resources
{
    partial class ResourceStorage
    {
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