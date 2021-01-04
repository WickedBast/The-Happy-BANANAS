using HB.Core.Repository;
using HB.DAL;
using HB.Entity.Application;
using HB.Repository.Interface.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace HB.Repository.Repository.Application
{
    class RoomRepository : BaseRepository<Room>, IRoomRepository
    {
        public RoomRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
