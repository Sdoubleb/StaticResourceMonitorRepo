using System;
using System.ComponentModel.DataAnnotations;

namespace StaticResourceMonitor.Models.StaticResource
{
    [AttributeUsage(AttributeTargets.Class)]
    class StaticResourceInfoValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var info = (StaticResourceInfo)value;
            return StaticResourceConstants.IsMatch(info.Reference);
        }
    }
}