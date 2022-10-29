using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace InternetShop.Models
{
    public class Category
    {

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1, int.MaxValue, ErrorMessage = "Display Order for category must be greater than 0")]
        public string DisplayOrder { get; set; }
    }
}
