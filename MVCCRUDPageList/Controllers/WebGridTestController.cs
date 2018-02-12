using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDPageList.Controllers
{
    public class WebGridTestController : Controller
    {
        // GET: WebGridTest
        public ActionResult Index()
        {
            var objstudentmodel = StudentRecord();
            return View(objstudentmodel);
        }

        [HttpPost]
        public ActionResult Index(StudentModel objstudentmodel)
        {
            //var stusection = GetSectionList();
            //foreach (var item in objstudentmodel.StudentList)
            //{
            //    var objsection = new SelectList(stusection, item.StudentSection);
            //    item.SectionModel = objsection;
            //}
            return View(objstudentmodel);
        }

        public StudentModel StudentRecord()
        {
            var objstudentmodel = new StudentModel
            {
                StudentList = new List<Student>
                {
                    new Student
                    {
                        Name = "Name1",
                        ClassOfStudent = "12th",
                        Address = "Address1"
                    },
                    new Student
                    {
                        Name = "Name2",
                        ClassOfStudent = "5th",
                        Address = "Address2"
                    },
                    new Student
                    {
                        Name = "Name3",
                        ClassOfStudent = "10th",
                        Address = "Address3"
                    },
                    new Student
                    {
                        Name = "Name4",
                        ClassOfStudent = "1st",
                        Address = "Address4"
                    }
                }
            };
            return objstudentmodel;
        }
    }

    public class Student
    {
        public string Name { get; set; }
        public string ClassOfStudent { get; set; }
        public string Address { get; set; }
    }

    public class StudentModel
    {
        public List<Student> StudentList { get; set; }
    }
}