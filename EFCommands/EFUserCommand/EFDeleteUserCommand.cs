using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.UserCommand;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.EFUserCommand
{
    public class EFDeleteUserCommand : EFBaseCommand, IDeleteUserCommand
    {
        public EFDeleteUserCommand(DBContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var user = _context.Users.Find(id);

            if(user == null)
            {
                throw new NotFoundException();
            }

            if(user.IsDeleted == true)
            {
                throw new AlredyExistException();
            }

            user.IsDeleted = true;

            _context.SaveChanges();
        }
    }
}
