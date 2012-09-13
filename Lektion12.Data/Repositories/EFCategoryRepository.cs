using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion12.Data.Context;
using Lektion12.Data.Entities;
using Lektion12.Data.Abstract;
using System.Web.Mvc;

namespace Lektion12.Data.Repositories
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private EFDbContext context = new EFDbContext();
        private IQueryable<Category> Categories { get { return context.Categories; } }

        public void Save(Category category)
        {
            if (category.CategoryID == 0)
                context.Categories.Add(category);
            else
            {
                context.Entry(category).State = System.Data.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public void Delete(Category category)
        {
            context.Categories.Remove(category);
            context.SaveChanges();
        }

        public Category Get(int id)
        {
            return context.Categories.FirstOrDefault(c => c.CategoryID == id);
        }

        public IQueryable<Category> GetCategories(int skip = 0, int? take = null, Func<Category, bool> filter = null)
        {
            IQueryable<Category> filteredResult = Categories;
            if (null != filter)
                filteredResult = Categories.Where(filter).AsQueryable();

            if (!take.HasValue)
                return filteredResult.OrderBy(c => c.CategoryID).Skip(skip);
            else
                return filteredResult.OrderBy(c => c.CategoryID).Skip(skip).Take(take.Value);
        }

        public List<SelectListItem> GetSelectListForCategories(int? withSiblingsToCategoryID = null)
        {
            int? parentID = withSiblingsToCategoryID.HasValue ? Get(withSiblingsToCategoryID.Value).ParentID
                                                                : null;
            return GetCategories(0, null, s => s.ParentID == parentID).OrderBy(c => c.Name).Select(sc =>
                new SelectListItem { Value = sc.CategoryID.ToString(), Text = sc.Name }
            ).ToList();
        }
    }
}
