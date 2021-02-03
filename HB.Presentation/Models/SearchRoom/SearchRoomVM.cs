using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Presentation.Models.SearchRoom
{
    public class SearchRoomVM
    {
        public DateTime? DateFrom { get; set; } = null;
        public DateTime? DateTo { get; set; } = null;
        public int NoOfRooms { get; set; }
        public int NoOfPerson { get; set; }
        public string Type { get; set; }
        //public IList<Room> Room { get; set; } = new List<Room>();
    }
}
