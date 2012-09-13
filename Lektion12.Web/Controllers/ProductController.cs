using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lektion12.Data.Entities;
using Lektion12.Web;
using Lektion12.Data.Abstract;
using Lektion12.Web.ViewModels;
using System.Threading;

namespace Lektion12.Web.Controllers
{ 
    public class ProductController : Controller
    {
        private int PageSize { get; set; }
        private IProductRepository _productRepo;
        private ICategoryRepository _categoryRepo;
        public ProductController(IProductRepository productRepo,
                                ICategoryRepository categoryRepo) 
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            PageSize = 5; 
        }

        //
        // GET: /Product/

        public ViewResult Index(int page = 1)
        {
            return View(page);
        }

        public PartialViewResult ProductList(int page = 1, string searchString = "")
        {
            Func<Product, bool> nameFilter = p => p.Name.Contains(searchString);

            var products = _productRepo.GetProducts(PageSize * (page - 1), PageSize, nameFilter);

            var pageInfo = new PagingInfo { CurrentPage = page,
                                            ItemsPerPage = PageSize,
                                            TotalItems = _productRepo.GetProducts(0, null, nameFilter).Count()
            };

            var vm = new ProductListViewModel { Products = products, 
                                                PagingInfo = pageInfo,
                                                SearchString = searchString
                                                };

            return PartialView("_PageableProductList", vm);
        }

        public PartialViewResult List(int page = 1)
        {
            var products = _productRepo.GetProducts(PageSize * (page - 1), PageSize);
            return PartialView("_List",products);
        }

        //
        // GET: /Product/Details/5

        public ViewResult Details(int id)
        {
            Product product = _productRepo.Get(id);
            return View(product);
        }

        //
        // GET: /Product/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Product/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productRepo.Save(product);
                return RedirectToAction("Index");  
            }

            return View(product);
        }
        
        //
        // GET: /Product/Edit/5
 
        public ActionResult Edit(int id)
        {
            var product = _productRepo.Get(id);
            var vm = new ProductEditViewModel
            {
                Product = product,
                Categories = _categoryRepo.GetSelectListForCategories(),
                Subcategories = _categoryRepo.GetSelectListForCategories(product.CategoryID),
                SelectedID = product.CategoryID
            };
            
            return View(vm);
        }

        //
        // POST: /Product/Edit/5

        [HttpPost]
        public ActionResult Edit(ProductEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Product.CategoryID = vm.SelectedID;
                _productRepo.Save(vm.Product);
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        //
        // GET: /Product/Delete/5
 
        public ActionResult Delete(int id)
        {
            Product product = _productRepo.Get(id);
            return View(product);
        }

        //
        // POST: /Product/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            _productRepo.Delete(_productRepo.Get(id));
            return RedirectToAction("Index");
        }
    }
}