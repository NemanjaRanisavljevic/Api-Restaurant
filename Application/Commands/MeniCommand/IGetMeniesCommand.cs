using Application.DTO.MeniDTO;
using Application.Interfaces;
using Application.Responsed;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.MeniCommand
{
    public interface IGetMeniesCommand : ICommand<MeniSearch, PagedRespone<MeniGetDTO>>
    {
    }
}
