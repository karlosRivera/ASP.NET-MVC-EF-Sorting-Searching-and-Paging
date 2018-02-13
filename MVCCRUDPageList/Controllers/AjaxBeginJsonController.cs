﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDPageList.other.Controllers
{
    public class AjaxBeginJsonController : Controller
    {
        // GET: AjaxBeginJson
        public ActionResult Index()
        {
            Customer oCustomer = new Customer();
            return View(oCustomer);
        }

        [HttpPost]
        public ActionResult Index(Customer oCustomer)
        {
            System.Threading.Thread.Sleep(2000);
            if (Request.IsAjaxRequest())
                return PartialView(oCustomer);

            return View(oCustomer);
        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}