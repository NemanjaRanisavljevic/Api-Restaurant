using Application.Commands.ReservationCommand;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFReservationCommand
{
    public class EFDeleteReservationCommand : EFBaseCommand, IDeleteReservationCommand
    {
        public EFDeleteReservationCommand(DBContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var res = _context.Reservations.Find(id);

            if(res == null)
            {
                throw new NotFoundException();
            }

            _context.Remove(res);

            _context.SaveChanges();
        }
    }
}
