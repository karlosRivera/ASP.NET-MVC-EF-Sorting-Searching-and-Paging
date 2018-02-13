using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDPageList.test.Controllers
{
    public class WebGridTextBoxForController : Controller
    {
        // GET: WebGrid
        public ActionResult Index()
        {
            var UserList = new List<Student>
            {
                new Student (){ ID=1, FirstName="Anubhav", LastName="Chaudhary" },   
                new Student (){ ID=2, FirstName="Mohit", LastName="Singh" },  
                new Student (){ ID=3, FirstName="Sonu", LastName="Garg" },  
                new Student (){ ID=4, FirstName="Shalini", LastName="Goel" },  
                new Student (){ ID=5, FirstName="James", LastName="Bond" }
            };

            return View(UserList);
        }

        [HttpPost]
        public ActionResult Index(List<Student> oStudent)
        {
            return View(oStudent);
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }              
    }
}