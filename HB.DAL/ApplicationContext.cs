using HB.Core.Entity;
using HB.Entity.Application;
using HB.Mapping.Application;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using static HB.Core.Enum.Enums;

namespace HB.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            #region Application

            new CommentMapping(builder.Entity<Comment>());
            new ExtraServiceMapping(builder.Entity<ExtraService>());
            new ReservationMapping(builder.Entity<Reservation>());
            new RoomMapping(builder.Entity<Room>());
            new RoomImageMapping(builder.Entity<RoomImage>());
            new UserMapping(builder.Entity<User>());

            #endregion
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            if (ChangeTracker.HasChanges())
            {
                foreach (var item in ChangeTracker.Entries())
                {
                    var temp = (BaseEntity)item.Entity;
                    switch (item.State)
                    {
                        case EntityState.Detached:
                            break;
                        case EntityState.Unchanged:
                            break;
                        case EntityState.Added:
                            temp.RecordStatus = RecordStatus.Active;
                            temp.CreateDate = DateTime.UtcNow;
                            temp.UpdateDate = DateTime.UtcNow;
                            break;
                        case EntityState.Deleted:
                            temp.RecordStatus = RecordStatus.Deleted;
                            temp.UpdateDate = DateTime.UtcNow;
                            break;
                        case EntityState.Modified:
                            temp.UpdateDate = DateTime.UtcNow;
                            break;
                        default:
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }
    }
}
