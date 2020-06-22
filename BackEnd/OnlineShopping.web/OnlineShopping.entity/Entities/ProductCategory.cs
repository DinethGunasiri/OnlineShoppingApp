using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OnlineShopping.data.Entities
{
    public class ProductCategory
    {
        [Key]
        [Required]
        public int CategooryId { get; set; }

        [Required]
        [StringLength(255)]
        public string Category { get; set; }
    }
}
