using System;
using StaticResourceMonitor.Helpers;

namespace StaticResourceMonitor.Resources
{
    public class ResourceInfo
    {
        public ResourceInfo(string reference)
        {
            if (String.IsNullOrWhiteSpace(reference))
                throw new ArgumentNullException(paramName: nameof(reference));

            Reference = Utils.DecodeUrl(reference);
        }

        public string Reference { get; }

        public override bool Equals(object obj)
            => obj is ResourceInfo resource && Reference == resource.Reference;

        public override int GetHashCode()
            => Reference.GetHashCode();

        public override string ToString()
            => Reference.ToString();
    }
}