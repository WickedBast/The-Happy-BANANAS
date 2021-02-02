using HB.Core.Mapping;
using HB.Entity.Application;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Mapping.Application
{
    public class ExtraServiceMapping : BaseMap<ExtraService>
    {
        public ExtraServiceMapping(EntityTypeBuilder<ExtraService> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.ExtraService).HasForeignKey(x => x.UserID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
