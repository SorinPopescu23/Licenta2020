using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Licenta1.Models
{
    public class User//: IValidatableObject
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Abonat> Abonati { get; set; }

    }
}