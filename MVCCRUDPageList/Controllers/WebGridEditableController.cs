using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCCRUDPageList.Controllers
{
    public class WebGridEditableController : Controller
    {
        // GET: WebGridEditable
        public ActionResult Index()
        {
            List<UserModel> users = UserModel.getUsers();
            return View(users);
        }

        // GET: WebGridEditable
        [HttpPost]
        public ActionResult Index(List<UserModel> oUserModel)
        {
            return View(oUserModel);
        }
    }

    public class UserModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public static List<UserModel> getUsers()
        {
            List<UserModel> users = new List<UserModel>()  
            {  
                new UserModel (){ ID=1, FirstName="Anubhav", LastName="Chaudhary" },   
                new UserModel (){ ID=2, FirstName="Mohit", LastName="Singh" },  
                new UserModel (){ ID=3, FirstName="Sonu", LastName="Garg" },  
                new UserModel (){ ID=4, FirstName="Shalini", LastName="Goel" },  
                new UserModel (){ ID=5, FirstName="James", LastName="Bond" },  
            };
            return users;
        }
    }  
}