using System;
using System.ComponentModel.DataAnnotations;

namespace StaticResourceMonitor.Models.StaticResource
{
    [AttributeUsage(AttributeTargets.Class)]
    class StaticResourceValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var info = (StaticResource)value;
            return StaticResourceConstants.IsMatch(info.Reference);
        }
    }
}