using System;
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
        public int recordcount = 0;

        // GET: Customers
        public ActionResult Index(int? page, string SortColumn, string CurrentSort, String SearchText)
        {
            var customer = (from s in db.Customers
                            // select s;
                            select new CustomerDTO
                            {
                                CustomerID = s.CustomerID,
                                CompanyName = s.CompanyName,
                                ContactName = s.ContactName,
                                ContactTitle = s.ContactTitle,
                                Address = s.Address
                            });

            int pageSize = 5;
            int pageNumber = (page ?? 1);
            ViewBag.CurrentPage = pageNumber;
            SortColumn = String.IsNullOrEmpty(SortColumn) ? "CompanyName" : SortColumn;
            ViewBag.CurrentSort = SortColumn;
            //ViewBag.OldSort = CurrentSort;
            ViewBag.SearchText = SearchText;

            if (!String.IsNullOrEmpty(SearchText))
            {
                customer = customer.Where(s => s.CompanyName.ToUpper().Contains(SearchText.ToUpper())
                || s.ContactName.ToUpper().Contains(SearchText.ToUpper())
                || s.ContactTitle.ToUpper().Contains(SearchText.ToUpper())
                || s.Address.ToUpper().Contains(SearchText.ToUpper()));
            }

            switch (SortColumn)
            {
                case "CompanyName":
                    ViewBag.OldSort = "CompanyName";
                    if (SortColumn.Equals(CurrentSort))
                    {
                        customer = customer.OrderByDescending(m => m.CompanyName);
                        ViewBag.CurrentSort = "";
                        ViewBag.SortOrder = "desc";
                    }
                    else
                    {
                        customer = customer.OrderBy(m => m.CompanyName);
                        ViewBag.SortOrder = "asc";
                    }
                    break;

                case "ContactName":
                    ViewBag.OldSort = "ContactName";
                    if (SortColumn.Equals(CurrentSort))
                    {
                        customer = customer.OrderByDescending(m => m.ContactName);
                        ViewBag.CurrentSort = "";
                        ViewBag.SortOrder = "desc";
                    }
                    else
                    {
                        customer = customer.OrderBy(m => m.ContactName);
                        ViewBag.SortOrder = "asc";
                    }
                    break;

                case "ContactTitle":
                    ViewBag.OldSort = "ContactTitle";
                    if (SortColumn.Equals(CurrentSort))
                    {
                        customer = customer.OrderByDescending(m => m.ContactTitle);
                        ViewBag.CurrentSort = "";
                        ViewBag.SortOrder = "desc";
                    }
                    else
                    {
                        customer = customer.OrderBy(m => m.ContactTitle);
                        ViewBag.SortOrder = "asc";
                    }
                    break;

                case "Address":
                    ViewBag.OldSort = "Address";
                    if (SortColumn.Equals(CurrentSort))
                    {
                        customer = customer.OrderByDescending(m => m.Address);
                        ViewBag.CurrentSort = "";
                        ViewBag.SortOrder = "desc";
                    }
                    else
                    {
                        customer = customer.OrderBy(m => m.Address);
                        ViewBag.SortOrder = "asc";
                    }
                    break;

                case "Default":
                    ViewBag.OldSort = "CompanyName";
                    customer = customer.OrderBy(m => m.CompanyName);
                    ViewBag.SortOrder = "asc";
                    break;
            }

            IPagedList<CustomerDTO> oCustomer = customer.ToPagedList(pageNumber, pageSize);
            return View(oCustomer);
        }

        // GET: Customers/Details/5
        public ActionResult Details(string id, int page)
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
        public ActionResult Edit(int page, string id)
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
        public ActionResult Delete(string id, int page)
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
