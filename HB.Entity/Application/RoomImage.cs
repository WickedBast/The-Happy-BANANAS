using HB.Core.Entity;
using System;

namespace HB.Entity.Application
{
    public class RoomImage : BaseEntity
    {
        public Guid RoomID { get; set; }

        public string Image { get; set; }

        public virtual Room Room { get; set; }
    }
}