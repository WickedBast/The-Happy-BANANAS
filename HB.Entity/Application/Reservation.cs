using HB.Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HB.Entity.Application
{
    public class Reservation : BaseEntity
    {
        public Guid? UserID { get; set; }

        public string Slug { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal RateAVG { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal Cost { get; set; }

        public Guid RoomNumber { get; set; }

        public int NumberOfPerson { get; set; }

        public int RoomCount { get; set; }

        public string PNRNumber { get; set; }

        public virtual Room Room { get; set; }

        public virtual IList<Comment> Comments { get; set; }

        public virtual User User { get; set; }
    }
}