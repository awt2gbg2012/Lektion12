using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Lektion12.Data.Entities
{
    public class Product
    {
        [HiddenInput(DisplayValue=false)]
        public int ProductID { get; set; }
        [Required(ErrorMessage="Please enter a product name.")]
        public string Name { get; set; }
        [Required(ErrorMessage="Please enter a product description.")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage="Please enter a positive value")]
        public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        public DateTime? FeaturedDate { get; set; }
    }
}
