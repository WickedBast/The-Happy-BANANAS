using HB.Core.Mapping;
using HB.Entity.Application;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Mapping.Application
{
    public class CommentMapping : BaseMap<Comment>
    {
        public CommentMapping(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.Comments).HasForeignKey(x => x.UserID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);

            builder.HasOne(x => x.Reservation).WithMany(x => x.Comments).HasForeignKey(x => x.ReservationID).OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}
