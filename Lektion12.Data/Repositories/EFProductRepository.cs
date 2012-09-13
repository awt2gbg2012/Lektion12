using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion12.Data.Context;
using Lektion12.Data.Entities;
using Lektion12.Data.Abstract;

namespace Lektion12.Data.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        private IQueryable<Product> Products { get { return context.Products; } }

        public void Save(Product product)
        {
            if (product.CategoryID == 0)
                product.CategoryID = 1; // Fullösning - vi kan inte editera Category ännu
            if (product.ProductID == 0)
                context.Products.Add(product);
            else
            {
                context.Entry(product).State = System.Data.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Delete(Product product)
        {
            context.Products.Remove(product);
            context.SaveChanges();
        }

        public Product Get(int id)
        {
            return context.Products.Include("Category").FirstOrDefault(p => p.ProductID == id);
        }

        public IQueryable<Product> GetProducts(int skip = 0, int? take = null, Func<Product,bool> filter = null)
        {
            IQueryable<Product> filteredResult = Products;
            if (null != filter)
                filteredResult = Products.Where(filter).AsQueryable();
            
            if (!take.HasValue)
                return filteredResult.OrderBy(p => p.ProductID).Skip(skip);
            else
                return filteredResult.OrderBy(p => p.ProductID).Skip(skip).Take(take.Value);
        }
    }
}
