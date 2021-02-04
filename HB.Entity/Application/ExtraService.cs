using HB.Core.Entity;
using System;
using System.Collections.Generic;

namespace HB.Entity.Application
{
    public class ExtraService : BaseEntity
    {
        public Guid? UserID { get; set; }

        public string ServiceType { get; set; }

        public string PNRNumber { get; set; }

        public int Cost { get; set; }

        public int Quota { get; set; }

        public DateTime Date { get; set; }

        public string Hour { get; set; }

        public int NumberOfPerson { get; set; }

        public virtual User User { get; set; }
    }
}