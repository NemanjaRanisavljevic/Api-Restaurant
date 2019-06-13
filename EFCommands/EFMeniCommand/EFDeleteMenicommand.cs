using System;
using System.Collections.Generic;
using System.Text;
using Application.Commands.MeniCommand;
using Application.Exceptions;
using EFDataAccess;

namespace EFCommands.EFMeniCommand
{
    public class EFDeleteMenicommand : EFBaseCommand, IDeleteMeniCommand
    {
        public EFDeleteMenicommand(DBContext context) : base(context)
        {
        }

        public void Execute(int id)
        {
            var meni = _context.Menis.Find(id);

            if(meni == null)
            {
                throw new NotFoundException();
            }

            var idSlike = meni.ImageId;
            var slika = _context.Images.Find(idSlike);

            _context.Remove(slika);
            _context.Remove(meni);
            _context.SaveChanges();

        }
    }
}
