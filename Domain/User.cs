using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class User:Model
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool Active { get; set; }
        public string Token { get; set; }
        public int RoleId { get; set; }

        public Role Role { get; set; }

        public ICollection<Impression> Impressions { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
