using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OverTheTop2.Models
{
    public class Category
    {
        public int id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<CategoryImage> CategoryImages { get; set; }

        public ICollection<SubCategory> SubCategory { get; set; }


    }
}