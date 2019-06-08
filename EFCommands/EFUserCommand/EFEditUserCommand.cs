using Application.Commands.UserCommand;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFUserCommand
{
    public class EFEditUserCommand : EFBaseCommand, IEditUserCommand
    {
        public EFEditUserCommand(DBContext context) : base(context)
        {
        }

        public void Execute(UserSearchDTO request)
        {
            var user = _context.Users.Find(request.Id);

            if(user == null)
            {
                throw new NotFoundException();
            }

            if(request.Email != null)
            {
                if(_context.Users.Any(u => u.Email != request.Email))
                {
                    user.Email = request.Email;
                }
                else
                {
                    throw new AlredyExistException();
                }  
            }

            if (request.Name != null)
            {
                if (user.Name != request.Name)
                {
                    user.Name = request.Name;
                }
                else
                {
                    throw new AlredyExistException();
                }
            }

            if(request.Surname != null)
            {
                if(user.Surname != request.Surname)
                {
                    user.Surname = request.Surname;
                }else
                {
                    throw new AlredyExistException();
                }
                
            }

            if (request.Password != null)
            {
                if (user.Password != request.Password)
                {
                    user.Password = request.Password;
                }
                else
                {
                    throw new AlredyExistException();
                }

            }

            if(request.RoleId != 0)
            {
                if(user.RoleId != request.RoleId)
                {
                    if (_context.Roles.Any(r => r.Id == request.Id))
                    {
                        user.RoleId = request.RoleId;
                    }else
                    {
                        throw new NotFoundException();
                    }
                }else
                {
                    throw new AlredyExistException();
                }
            }

            
            
                if(user.IsDeleted != request.IsDelete)
                {
                    user.IsDeleted = request.IsDelete;
                }
            
            
            _context.SaveChanges();



        }
    }
}
