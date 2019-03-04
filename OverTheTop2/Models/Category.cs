using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverTheTop2.Models
{
    public class Category
    {
        public int id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<CategoryImage> CategoryImages { get; set; }

        public ICollection<SubCategory> SubCategory { get; set; }


    }
}