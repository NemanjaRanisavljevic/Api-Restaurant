using Application.Commands.ImpressionCommand;
using Application.DTO;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFImpressionCommand
{
    public class EFEditImpressionCommand : EFBaseCommand, IEditImpressionCommand
    {
        public EFEditImpressionCommand(DBContext context) : base(context)
        {
        }

        public void Execute(ImpressionEditDTO request)
        {
            var searches = _context.Impressions.Find(request.Id);

            if(searches == null)
            {
                throw new NotFoundException();
            }

            searches.Content = request.Content;

            _context.SaveChanges();
        }
    }
}
