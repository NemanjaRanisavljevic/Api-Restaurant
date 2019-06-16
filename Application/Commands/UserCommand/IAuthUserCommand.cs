using Application.DTO;
using Application.Helpers;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.UserCommand
{
    public interface IAuthUserCommand : ICommand<UserAuthDTO, LoggedUser>
    {
    }
}
