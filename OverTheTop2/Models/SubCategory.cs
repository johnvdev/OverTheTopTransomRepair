﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverTheTop2.Models
{
    public class SubCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Beforeimg { get; set; }

        public string Afterimg { get; set; }

        public ICollection<SubCategoryImage> SubCategoryImages { get; set; }




    }
}