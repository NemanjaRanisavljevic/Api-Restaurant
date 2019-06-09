using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ReservationCommand
{
    public interface IDeleteReservationCommand : ICommand<int>
    {
    }
}
