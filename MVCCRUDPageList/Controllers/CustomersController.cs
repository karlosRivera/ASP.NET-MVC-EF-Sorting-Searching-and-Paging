﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCCRUDPageList.Models;
using PagedList;

namespace MVCCRUDPageList.Controllers
{
    public class CustomersController : Controller
    {
        private CustomersEntities db = new CustomersEntities();

        // GET: Customers
        public ActionResult Index(int? page, string SortColumn, string CurrentSort)
        {
            var customer = (object) null; 

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.CurrentPage = pageNumber;
            SortColumn = String.IsNullOrEmpty(SortColumn) ? "CompanyName" : SortColumn;
            ViewBag.CurrentSort = SortColumn;
            ViewBag.OldSort = CurrentSort;

            switch (SortColumn)
            {
                case "CompanyName":
                    if (SortColumn.Equals(CurrentSort))
                    {
                        customer = db.Customers.OrderByDescending(m => m.CompanyName).ToPagedList(pageNumber, pageSize);
                        ViewBag.CurrentSort = "";
                    }
                    else
                        customer = db.Customers.OrderBy(m => m.CompanyName).ToPagedList(pageNumber, pageSize);
                    break;

                case "ContactName":
                    if (SortColumn.Equals(CurrentSort))
                    {
                        customer = db.Customers.OrderByDescending(m => m.ContactName).ToPagedList(pageNumber, pageSize);
                        ViewBag.CurrentSort = "";
                    }
                    else
                        customer = db.Customers.OrderBy(m => m.ContactName).ToPagedList(pageNumber, pageSize);
                    break;

                case "ContactTitle":
                    if (SortColumn.Equals(CurrentSort))
                    {
                        customer = db.Customers.OrderByDescending(m => m.ContactTitle).ToPagedList(pageNumber, pageSize);
                        ViewBag.CurrentSort = "";
                    }
                    else
                        customer = db.Customers.OrderBy(m => m.ContactTitle).ToPagedList(pageNumber, pageSize);
                    break;

                case "Address":
                    if (SortColumn.Equals(CurrentSort))
                    {
                        customer = db.Customers.OrderByDescending(m => m.Address).ToPagedList(pageNumber, pageSize);
                        ViewBag.CurrentSort = "";
                    }
                    else
                        customer = db.Customers.OrderBy(m => m.Address).ToPagedList(pageNumber, pageSize);
                    break;

                case "Default":
                    customer = db.Customers.OrderBy(m => m.CompanyName).ToPagedList(pageNumber, pageSize);
                    break;
            }

            return View(customer);

            //return View(db.Customers.ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(string id, int page)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CurrentPage = page;
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CustomerID,CompanyName,ContactName,ContactTitle,Address,City,Region,PostalCode,Country,Phone,Fax")] Customer customer, int page)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { page = page });
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
