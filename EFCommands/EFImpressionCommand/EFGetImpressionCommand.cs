using Application.Commands.ImpressionCommand;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFImpressionCommand
{
    public class EFGetImpressionCommand : EFBaseCommand, IGetImpressionCommand
    {
        public EFGetImpressionCommand(DBContext context) : base(context)
        {
        }

        public ImpressionDTO Execute(int id)
        {
            var obj = _context.Impressions.Find(id);

            if (obj == null)
            {
                throw new NotFoundException();
            }

            var user = _context.Users.Find(obj.UserId);

            

            return new ImpressionDTO
            {
                Id = obj.Id,
                Content = obj.Content,
                UserId = obj.UserId,
                NameSurname = user.Name + " " + user.Surname
            };
            
            
        }
    }
}
