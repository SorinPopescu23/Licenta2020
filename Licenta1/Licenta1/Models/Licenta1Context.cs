using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Licenta1.Models
{
    public class Licenta1Context:DbContext
    {
        public Licenta1Context():base("Licenta1Context")
        {
        }
        public virtual DbSet<User> Useri { get; set; }
        public virtual DbSet<Eveniment> Evenimente { get; set; }
        public virtual DbSet<Abonat> Abonati { get; set; }
        public virtual DbSet<Poze> Foto { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}