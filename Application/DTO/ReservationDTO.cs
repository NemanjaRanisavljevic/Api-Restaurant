using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Reservation date is required")]
        public DateTime ReservationDate { get; set; }
        [Required(ErrorMessage = "Numper guest is required")]
        public int Guest { get; set; }
        [Required(ErrorMessage = "Time date is required")]
        [MaxLength(2,ErrorMessage ="Max char for Time is 3")]
        [Range(6,23,ErrorMessage ="Range for time is 6 - 23 h")]
        public string Time { get; set; }
        [Required(ErrorMessage = "User is required")]
        public int UserId { get; set; }
    }
}
