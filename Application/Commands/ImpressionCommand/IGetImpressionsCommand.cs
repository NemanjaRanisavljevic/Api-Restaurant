using Application.DTO;
using Application.Interfaces;
using Application.Responsed;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.ImpressionCommand
{
    public interface IGetImpressionsCommand : ICommand<ImpressSearch,PagedRespone<ImpressionDTO>>
    {
    }
}
