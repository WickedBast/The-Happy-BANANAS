using HB.Entity.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Presentation.Models.Room
{
    public class RoomVM
    {
        public RoomVM()
        {
            Item = new List<RoomMM>();
        }

        public List<RoomMM> Item { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
    }

    public class RoomMM
    {
        public RoomMM()
        {
            User = new UserMM();
        }

        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }        
        public UserMM User { get; set; }
        public int PersonCapacity { get; set; }
        public string Type { get; set; }
        public RoomImage RoomImage { get; set; }
        public int Cost { get; set; }

    }

    public class UserMM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
