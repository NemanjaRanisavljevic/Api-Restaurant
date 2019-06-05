﻿using Application.DTO.CreateDTO;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Commands.DrinkCommand
{
    public interface IGetDrinkCommand:ICommand<int,IEnumerable<CreateDrinkDTO>>
    {
    }
}
