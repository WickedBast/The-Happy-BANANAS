using HB.Core.Mapping;
using HB.Entity.Application;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Mapping.Application
{
    public class RoomImageMapping : BaseMap<RoomImage>
    {
        public RoomImageMapping(EntityTypeBuilder<RoomImage> builder)
        {
            builder.HasOne(x => x.Room).WithMany(x => x.RoomImages).HasForeignKey(x => x.RoomID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
