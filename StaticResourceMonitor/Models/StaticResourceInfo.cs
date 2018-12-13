using System.ComponentModel;

namespace StaticResourceMonitor.Models
{
    [StaticResourceInfoValidation(ErrorMessage = "Please enter a correct reference to a static resource.")]
    public class StaticResourceInfo
    {
        [DisplayName("Reference to a static resource")]
        public string Reference { get; set; }
    }    
}