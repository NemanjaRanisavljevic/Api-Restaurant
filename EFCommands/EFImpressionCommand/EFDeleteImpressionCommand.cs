using Application.Commands.ImpressionCommand;
using Application.Exceptions;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands.EFImpressionCommand
{
    public class EFDeleteImpressionCommand : EFBaseCommand, IDeleteImpressionCommand
    {
        public EFDeleteImpressionCommand(DBContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var search = _context.Impressions.Find(id);

            if(search == null)
            {
                throw new NotFoundException();
            }

            _context.Impressions.Remove(search);

            _context.SaveChanges();
        }
    }
}
