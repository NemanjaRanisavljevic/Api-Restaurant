using Application.DTO.Reservation;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ReservationCommand
{
   public interface IGetReservationCommand: ICommand<int, IEnumerable<ReservationGetDTO>>
    {
    }
}
