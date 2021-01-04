using HB.Core.Entity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace HB.Entity.Application
{
    public class Comment : BaseEntity
    {
        public Guid ReservationID { get; set; }

        public string CommentText { get; set; }

        public Guid? UserID { get; set; }

        public Guid RoomNumber { get; set; }

        public string FullName { get; set; }

        [Column(TypeName = "decimal(18,1)")]
        public decimal RateGiven { get; set; }

        public virtual Reservation Reservation { get; set; }

        public virtual User User { get; set; }

        public virtual Room Room { get; set; }
    }
}
