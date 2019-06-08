using Application.Commands.Response;
using Application.DTO;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.UserCommand
{
   public interface IGetUsersCommand : ICommand<UserSearch, PagedResponse<UserSearchDTO>>
    {
    }
}
