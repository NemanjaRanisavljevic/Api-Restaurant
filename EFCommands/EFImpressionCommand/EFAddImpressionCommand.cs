using Application.Commands.ImpressionCommand;
using Application.DTO;
using Application.Exceptions;
using Domain;
using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFImpressionCommand
{
    public class EFAddImpressionCommand : EFBaseCommand, IAddImpresssionCommand
    {
        public EFAddImpressionCommand(DBContext context) : base(context)
        {
        }

        public void Execute(ImpressionDTO request)
        {
            if (_context.Users.Any(u => u.Id == request.UserId))
            {

            }
            else
            {
                throw new NotFoundException();
            }

            _context.Impressions.Add(new Impression {
                Content = request.Content,
                UserId = request.UserId
            });

            _context.SaveChanges();
        }
    }
}
