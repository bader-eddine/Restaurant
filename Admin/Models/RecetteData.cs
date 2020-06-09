using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin.Models
{
    public class RecetteData
    {
         public int id { set; get; }
         public string titre { set; get; }
        public string recette { set; get; }
        public string description { set; get; }
        public string origine { set; get; }
        public int typeRecette { set; get; }
        public int createdBy { set; get; }
        public DateTime dateAdd { set; get; }
        public DateTime dateModify { set; get; }
    }
}
