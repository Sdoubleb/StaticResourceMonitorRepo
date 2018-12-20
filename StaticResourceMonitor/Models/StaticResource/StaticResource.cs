using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StaticResourceMonitor.Models.StaticResource
{
    [StaticResourceValidation(ErrorMessage = "Please enter a correct reference to a static resource.")]
    public class StaticResource
    {
        [Required, DisplayName("Reference to a static resource")]
        public string Reference { get; set; }
    }    
}