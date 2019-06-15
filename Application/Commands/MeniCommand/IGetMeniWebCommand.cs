using Application.DTO.MeniDTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.MeniCommand
{
    public interface IGetMeniWebCommand : ICommand<int, MeniGetDTO>
    {
    }
}
