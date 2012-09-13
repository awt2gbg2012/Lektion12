using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion12.Data.Entities;
using System.ComponentModel;

namespace Lektion12.Web.ViewModels
{
    public class ProductEditViewModel
    {
        public Product Product { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Categories { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Subcategories { get; set; }
        [DisplayName("Select a Subcategory")]
        public int SelectedID { get; set; }
    }
}