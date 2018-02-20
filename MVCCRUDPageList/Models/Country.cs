using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCCRUDPageList.Models
{
    public class Country
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

    public class Hobby
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public bool Checked { get; set; }
    }

}