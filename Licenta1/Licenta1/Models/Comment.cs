﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Licenta1.Models
{
    public class Comment
    {
        public int CommentID { get; set; }

        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        public string Body { get; set; }

        public int EvenimentId { get; set; }
    }
}