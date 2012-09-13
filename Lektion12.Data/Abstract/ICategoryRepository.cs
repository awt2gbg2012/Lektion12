using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lektion12.Data.Entities;
using System.Web.Mvc;

namespace Lektion12.Data.Abstract
{
    public interface ICategoryRepository
    {
        void Save(Category category);
        void Delete(Category category);
        Category Get(int id);
        IQueryable<Category> GetCategories(int skip = 0, int? take = null, Func<Category, bool> filter = null);
        List<SelectListItem> GetSelectListForCategories(int? withSiblingsToCategoryID = null);
    }
}
