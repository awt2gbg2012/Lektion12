using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lektion12.Data.Abstract;

namespace Lektion12.Web.Controllers
{
    public class APIController : Controller
    {
        private ICategoryRepository _repo;
        public APIController(ICategoryRepository repo) { _repo = repo; }

        //
        // GET: /API/

        public ActionResult Index()
        {
            return View();
        }

    }
}
