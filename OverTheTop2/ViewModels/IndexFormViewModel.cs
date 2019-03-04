using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OverTheTop2.Models;

namespace OverTheTop2.ViewModels
{
    public class IndexFormViewModel
    {
        private IEnumerable<SubCategory> SubCategories { get; set; }
        public IEnumerable<CategoryImage> CategoryImages { get; set; }
        public Category Category { get; set; }
    }
}