using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcEFHttpClient.Models
{
    public class Product
    {
        internal object response;

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "maximum length is 20")]
        [MinLength(6, ErrorMessage = "minimum length is 6")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        [Range(1, 100, ErrorMessage = "range in between 0 and 100")]
        public int QualityStock { get; set; }
        public string Supplier { get; set; }
    }
}