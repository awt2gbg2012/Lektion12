using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion12.Data.Entities;
using System.ComponentModel;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lektion12.Web.ViewModels
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        public int CategoryID { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Categories { get; set; }
        public int SubCategoryID { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Subcategories { get; set; }
        public string SelectedID { get; set; }
    }
}