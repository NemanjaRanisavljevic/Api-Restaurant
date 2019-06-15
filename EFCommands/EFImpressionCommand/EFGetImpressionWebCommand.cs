using Application.Commands.ImpressionCommand;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFImpressionCommand
{
    public class EFGetImpressionWebCommand : EFBaseCommand, IGetImpressionWebCommand
    {
        public EFGetImpressionWebCommand(DBContext context) : base(context)
        {
        }

        public ImpressionEditDTO Execute(int id)
        {
            var obj = _context.Impressions.Find(id);

            if (obj == null)
            {
                throw new NotFoundException();
            }
            

            return new ImpressionEditDTO
            {
                Id = obj.Id,
                Content = obj.Content
               
            };

        }
    }
}
