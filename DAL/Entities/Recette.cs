using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Entities
{
   public class Recette
    {
        [Key]
        public int id { set; get; }
        [DisplayName("Titre")]
        [Required]
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
