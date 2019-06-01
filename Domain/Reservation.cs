using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Reservation:Model
    {
        public DateTime ReservationDate { get; set; }
        public int Guest { get; set; }
        public string Time { get; set; }
        public int UserId { get; set; }

        public User User { get; set; }
    }
}
