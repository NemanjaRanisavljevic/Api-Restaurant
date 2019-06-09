using Application.Commands.ReservationCommand;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFReservationCommand
{
    public class EFAddReservationCommand : EFBaseCommand, IAddReservationCommmand
    {
        public EFAddReservationCommand(DBContext context) : base(context)
        {
        }

        public void Execute(ReservationDTO request)
        {
            if(request.Guest <= 0)
            {
                throw new DataCanNotBeNull();
            }

            
            
            if(_context.Users.Any(u => u.Id != request.UserId))
            {
                throw new NotFoundException();
            }

            _context.Reservations.Add(new Reservation
            {
                ReservationDate = request.ReservationDate,
                Guest = request.Guest,
                Time = request.Time,
                UserId = request.UserId
            });

            _context.SaveChanges();
        }
    }
}
