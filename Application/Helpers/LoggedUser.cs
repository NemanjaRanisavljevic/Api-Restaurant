using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helpers
{
   public  class LoggedUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }

        public bool IsLogged { get; set; }
    }
}
