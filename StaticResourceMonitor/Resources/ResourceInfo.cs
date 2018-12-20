using System;
using StaticResourceMonitor.Helpers;

namespace StaticResourceMonitor.Resources
{
    public class ResourceInfo
    {
        internal ResourceInfo(string reference)
        {
            string decoded = Utils.DecodeUrl(reference);

            if (String.IsNullOrWhiteSpace(decoded))
                throw new ArgumentNullException(paramName: nameof(reference));

            Reference = decoded;
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