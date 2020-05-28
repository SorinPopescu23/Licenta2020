using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Licenta1.Models
{
    public class Poze
    {
        [ForeignKey("Eveniment")]
        [Key]
        public int PozeId { get; set; }
        public string Poza1 { get; set; }
        public string Poza2 { get; set; }
        public string Poza3 { get; set; }
        public string Poza4 { get; set; }
        //[Required]
        public virtual Eveniment Eveniment { get; set; }
    }
}