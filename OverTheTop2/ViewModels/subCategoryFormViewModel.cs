using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OverTheTop2.ViewModels
{
    public class subCategoryFormViewModel
    {
        public string Name { get; set; }
        public HttpPostedFileBase Before { get; set; }
        public HttpPostedFileBase After { get; set; }
        public IEnumerable<HttpPostedFileBase> Images { get; set; }
    }
}