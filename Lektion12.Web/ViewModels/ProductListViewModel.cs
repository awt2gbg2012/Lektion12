using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lektion12.Data.Entities;
using Lektion12.Web.ViewModels;

namespace Lektion12.Web.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string SearchString { get; set; }
    }
}