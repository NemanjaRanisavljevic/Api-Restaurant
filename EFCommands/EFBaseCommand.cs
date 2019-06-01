using EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace EFCommands
{
    public abstract class EFBaseCommand
    {
        protected readonly DBContext _context;

        public EFBaseCommand(DBContext context)
        {
            this._context = context;
        }
         
    }
}
