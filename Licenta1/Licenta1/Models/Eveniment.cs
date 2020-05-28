using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Licenta1.Models
{
    public class Eveniment
    {
        public int EvenimentId { get; set; }
        [Display(Name = "Denumirea")]
        public string NumeEvent { get; set; }
        [Display(Name = "Data si ora"), DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yy H:mm:ss tt}"), DataType(DataType.DateTime)]
        public DateTime DataEvent { get; set; }
        [Display(Name = "Descriere")]
        public string DescriereEvent { get; set; }
        [Display(Name = "Galerie foto")]
        public string PozeEvent { get; set; }
        [Display(Name = "Genul")]
        public string GenEvent { get; set; }

        public virtual Poze Poze { get; set; }
    }
}