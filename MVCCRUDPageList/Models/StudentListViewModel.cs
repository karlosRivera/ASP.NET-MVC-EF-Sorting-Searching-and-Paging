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
        public List<Sex> Sex { get; set; }
        

        public StudentListViewModel()
        {
            Students = new List<Student>
            {
                new Student
                {
                    ID=1,Name="Keith",CountryID=0,SexID="F",
                    Hobbies= new List<Hobby>
                    {
                        new Hobby{ID=1,Name="Football",Checked=false},
                        new Hobby{ID=2,Name="Hocky",Checked=false},
                        new Hobby{ID=3,Name="Cricket",Checked=false}
                    }
        
                },

                new Student
                {
                    ID=2,Name="Paul",CountryID=2,
                    Hobbies= new List<Hobby>
                    {
                        new Hobby{ID=1,Name="Football",Checked=false},
                        new Hobby{ID=2,Name="Hocky",Checked=false},
                        new Hobby{ID=3,Name="Cricket",Checked=false}
                    }
                },

                new Student
                {
                    ID=3,Name="Sam",CountryID=3,
                    Hobbies= new List<Hobby>
                    {
                        new Hobby{ID=1,Name="Football",Checked=false},
                        new Hobby{ID=2,Name="Hocky",Checked=false},
                        new Hobby{ID=3,Name="Cricket",Checked=false}
                    }
                }
            };

            Country = new List<Country>
            {
                new Country{ID=1,Name="India"},
                new Country{ID=2,Name="UK"},
                new Country{ID=3,Name="USA"}
            };

            Sex = new List<Sex>
            {
                new Sex{ID="M",SexName="Male"},
                new Sex{ID="F",SexName="Female"}
            };

        }
    }
}