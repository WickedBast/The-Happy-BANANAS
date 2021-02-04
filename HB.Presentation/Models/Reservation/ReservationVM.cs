using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Presentation.Models.Reservation
{
    public class ReservationVM
    {

        public ReservationVM()
        {
            Item = new List<ReservationMM>();
            Items = new List<ReservationMM>();
            Res = new ReservationMM();
        }

        public List<ReservationMM> Item { get; set; }
        public List<ReservationMM> Items { get; set; }
        public ReservationMM Res { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }
        public int CurrentPage { get; set; }


    }

    public class ReservationDetailVM
    {
        public ReservationDetailVM()
        {
            Item = new ReservationDetailMM();
            Items = new List<ReservationDetailMM>();
        }

        public ReservationDetailMM Item { get; set; }
        public List<ReservationDetailMM> Items { get; set; }
    }

    public class ReservationMM
    {
        public ReservationMM()
        {
            User = new UserMM();
        }

        public Guid Id { get; set; }
        public string Number { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Image { get; set; }
        public string Detail { get; set; }
        public UserMM User { get; set; }
        public string Slug { get; set; }
        public int NumberOfPerson { get; set; }
        public int RoomCount { get; set; }
        public decimal Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Night { get; set; }
        public string Type { get; set; }

    }

    public class ReservationDetailMM
    {
        public ReservationDetailMM()
        {
            User = new UserMM();
            
        }
        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string RoomImage { get; set; }
        public UserMM User { get; set; }
        public string Slug { get; set; }
        public string Type { get; set; }
        public int NumberOfPerson { get; set; }
        public int Cost { get; set; }
        public string Name { get; set; }
    }

    public class UserMM
    {        
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
