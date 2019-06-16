using Application.DTO.WebDTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.MeniCommand
{
    public interface IGetEditMeniCommand : ICommand<int,HttpEditMeni>
    {
    }
}
