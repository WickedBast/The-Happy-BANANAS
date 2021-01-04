using System;
using System.ComponentModel.DataAnnotations.Schema;
using static HB.Core.Enum.Enums;

namespace HB.Core.Entity
{
    public class BaseEntity
    {
        public Guid Id { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public RecordStatus RecordStatus { get; set; }
    }
}