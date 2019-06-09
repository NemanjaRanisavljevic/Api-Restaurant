using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Reservation
{
    public class ReservationGetDTO
    {
        public int Id { get; set; }
        public DateTime ReservationDate { get; set; }

        public int Guest { get; set; }
        
        public string Time { get; set; }


        public string UserName { get; set; }
    }
}
