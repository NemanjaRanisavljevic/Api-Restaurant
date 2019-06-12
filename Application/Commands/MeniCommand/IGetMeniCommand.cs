using Application.DTO.MeniDTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.MeniCommand
{
    public interface IGetMeniCommand : ICommand<int, IEnumerable<MeniGetDTO>>
    {
    }
}
