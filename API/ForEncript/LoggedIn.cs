using Application.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace API.ForEncript
{
    public class LoggedIn : Attribute, IResourceFilter
    {
        private readonly string _role;
        public LoggedIn(string RoLeName)
        {
            _role = RoLeName;
        }

        public LoggedIn()
        {

        }
        //nakon akcije kontrolera se poziva
        public void OnResourceExecuted(ResourceExecutedContext context)
        {

        }
        //poziva se pre akcije kontrolera
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            var user = context.HttpContext.RequestServices.GetService<LoggedUser>();

            if (!user.IsLogged)
            {
                context.Result = new UnauthorizedResult();
            }
            else
            {
                if (_role != null)
                {
                    if (user.RoleName != _role)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
            }
        }
    }
}
