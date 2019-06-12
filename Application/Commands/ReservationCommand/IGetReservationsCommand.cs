using Application.DTO.Reservation;
using Application.Interfaces;
using Application.Responsed;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ReservationCommand
{
    public interface IGetReservationsCommand : ICommand<ReservationSearch, PagedRespone<ReservationGetDTO>>
    {
    }
}
