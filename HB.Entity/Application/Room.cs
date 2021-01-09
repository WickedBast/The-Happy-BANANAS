using HB.Core.Entity;
using System.Collections.Generic;

namespace HB.Entity.Application
{
    public class Room : BaseEntity
    {
        public string RoomNumber { get; set; }

        public string Type { get; set; }

        public bool IsFull { get; set; }

        public int PersonCapacity { get; set; }

        public int Price { get; set; }

        public virtual IList<RoomImage> RoomImages { get; set; }

        public virtual IList<Reservation> Reservations { get; set; }

        public virtual IList<Comment> Comments { get; set; }
    }
}
