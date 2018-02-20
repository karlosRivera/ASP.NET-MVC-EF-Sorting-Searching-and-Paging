using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCCRUDPageList.Models
{
    public class Student
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "First Name Required")]
        public string Name { get; set; }
        //[Required(ErrorMessage = "Last Name Required")]
        //public string LastName { get; set; }

        public int CountryID { get; set; }
        public IList<Hobby> Hobbies { get; set; }

    }
}