using Application.Commands.ReservationCommand;
using Application.DTO.Reservation;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFReservationCommand
{
    public class EFGetReservationCommand : EFBaseCommand, IGetReservationCommand
    {
        public EFGetReservationCommand(DBContext context) : base(context)
        {
        }

        public IEnumerable<ReservationGetDTO> Execute(int id)
        {
            var query = _context.Reservations.AsQueryable();

            if (_context.Reservations.Any(r => r.Id == id))
            {
                query = query.Where(r => r.Id == id);
            }
            else
            {
                throw new NotFoundException();
            }

            return query.Include(u => u.User)
                .Select(r => new ReservationGetDTO
                {
                    Id = r.Id,
                    ReservationDate = r.ReservationDate,
                    Guest = r.Guest,
                    Time = r.Time + " h",
                    UserName = r.User.Name + " " + r.User.Surname
                });
        }
    }
}
