using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Presentation.Models.Comment
{
    public class CommentVM
    {
        public CommentVM()
        {
            Items = new List<CommentMM>();
        }

        public List<CommentMM> Items { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }
        public int Count { get; set; }
    }

    public class CommentMM
    {
        public CommentMM()
        {
            User = new UserMM();
            Room = new RoomMM();
        }

        public Guid Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string Explanation { get; set; }
        public string PNRNumber{ get; set; }
        public UserMM User { get; set; }
        public decimal RateAVG { get; set; }
        public RoomMM Room { get; set; }
    }

    public class RoomMM
    {
        public string Type { get; set; }
    }

    public class UserMM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
