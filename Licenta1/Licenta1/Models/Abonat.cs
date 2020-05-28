using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Licenta1.Models
{
    public class Abonat
    {
        public int AbonatId { get; set; }
        public int UserId { get; set; }
        public int EvenimentId { get; set; }
        public virtual User User { get; set; }
        public virtual Eveniment Eveniment { get; set; }
    }
}