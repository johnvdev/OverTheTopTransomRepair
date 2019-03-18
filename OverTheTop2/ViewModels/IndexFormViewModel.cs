using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OverTheTop2.Models;

namespace OverTheTop2.ViewModels
{
    public class IndexFormViewModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Review> Reviews { get; set; }

    }
}