using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUDPageList.Models
{
    public class StudentListViewModel
    {
        public IList<Student> Students { get; set; }

        public List<Country> Country { get; set; }

        public StudentListViewModel()
        {
            Students = new List<Student>
            {
                new Student{ID=1,Name="Keith",CountryID=1},
                new Student{ID=2,Name="Paul",CountryID=2},
                new Student{ID=3,Name="Sam",CountryID=3}
            };

            Country = new List<Country>
            {
                new Country{ID=1,Name="India"},
                new Country{ID=2,Name="UK"},
                new Country{ID=3,Name="USA"}


            };
        }
    }
}