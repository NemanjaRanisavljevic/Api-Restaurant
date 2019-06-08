using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.DrinkCommand;
using Application.Commands.RoleCommand;
using Application.Commands.UserCommand;
using EFCommands.EFDrinkCommand;
using EFCommands.EFRolleCommand;
using EFCommands.EFUserCommand;
using EFDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<DBContext>();

            #region Drink
            services.AddTransient<IDrinkCreateCommand, EFCreateDrinkCommand>();
            services.AddTransient<IDeleteDrinkCommand, EFDeleteDrinkCommand>();
            services.AddTransient<IEditDrinkCommand, EFEditDrinkCommand>();
            services.AddTransient<IGetDrinksCommand, EFGetDrinksCommand>();
            services.AddTransient<IGetDrinkCommand, EFGetDrinkCommand>();
            #endregion

            #region Role
            services.AddTransient<IAddRolleCommand, EFAddRolleCommand>();
            services.AddTransient<IGetRolesCommand, EFGetRolesCommand>();
            services.AddTransient<IGetRoleCommand, EFGetRoleCommand>();
            services.AddTransient<IEditRoleCommand, EFEditRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
            #endregion

            #region User
            services.AddTransient<IAddUserCommand, EFAddUserCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            services.AddTransient<IGetUserCommand, EFGetUserCommand>();
            services.AddTransient<IEditUserCommand, EFEditUserCommand>();
            services.AddTransient<IGetUsersCommand, EFGetUsersCommand>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
