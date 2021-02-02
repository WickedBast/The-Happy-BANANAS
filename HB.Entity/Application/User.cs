using HB.Core.Entity;
using System;
using System.Collections.Generic;
using static HB.Core.Enum.Enums;

namespace HB.Entity.Application
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PhoneNumber { get; set; }

        public Role Role { get; set; }

        public virtual IList<Reservation> Reservations { get; set; }

        public virtual IList<Comment> Comments { get; set; }

        public virtual IList<ExtraService> ExtraService { get; set; }
    }
}