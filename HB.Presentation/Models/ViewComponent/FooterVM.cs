using HB.Presentation.Models.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HB.Presentation.Models.ViewComponent
{
    public class FooterVM
    {
        public FooterVM()
        {
            Item = new List<ReservationMM>();
        }
        public List<ReservationMM> Item { get; set; }
    }
}
