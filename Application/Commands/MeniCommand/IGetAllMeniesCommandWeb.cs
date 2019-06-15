﻿using Application.DTO.MeniDTO;
using Application.Interfaces;
using Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.MeniCommand
{
    public interface IGetAllMeniesCommandWeb :ICommand<MeniSearchWeb, IEnumerable<MeniGetDTO>>
    {
    }
}
