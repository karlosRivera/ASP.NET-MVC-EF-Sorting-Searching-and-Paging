using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCRUDPageList.Models;

namespace MVCCRUDPageList.Controllers
{
    public class HtmlTableController : Controller
    {
        // GET: WebGridMoreControls
        public ActionResult Index()
        {
            StudentListViewModel osvm = new StudentListViewModel();
            return View(osvm);
        }

        [HttpPost]
        public ActionResult Index(StudentListViewModel oStudentListViewModel)
        {
            return View(oStudentListViewModel);
        }
    }
}