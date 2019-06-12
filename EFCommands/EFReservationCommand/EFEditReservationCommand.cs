using Application.Commands.ReservationCommand;
using Application.DTO.Reservation;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFReservationCommand
{
    public class EFEditReservationCommand : EFBaseCommand, IEditReservationCommand
    {
        public EFEditReservationCommand(DBContext context) : base(context)
        {
        }

        public void Execute(ReservationEditDTO request)
        {
            var reservation = _context.Reservations.Find(request.Id);

            if (reservation == null)
            {
                throw new NotFoundException();
            }

            if(request.ReservationDate != null)
            {
                if (reservation.ReservationDate != request.ReservationDate)
                {
                    reservation.ReservationDate = request.ReservationDate;
                }
                else
                {
                    throw new AlredyExistException();
                }
            }

            if (request.Guest != null)
            {
                if (reservation.Guest != request.Guest)
                {
                    reservation.Guest = (int)request.Guest;
                }
                else
                {
                    throw new AlredyExistException();
                }
            }

            if (request.Time != null)
            {
                if (reservation.Time != request.Time)
                {
                    reservation.Time = request.Time;
                }
                else
                {
                    throw new AlredyExistException();
                }
            }

            _context.SaveChanges();

        }
    }
}
