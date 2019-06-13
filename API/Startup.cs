using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ForEncript;
using Application.Commands.DrinkCommand;
using Application.Commands.ImpressionCommand;
using Application.Commands.MealCommand;
using Application.Commands.MeniCommand;
using Application.Commands.ReservationCommand;
using Application.Commands.RoleCommand;
using Application.Commands.UserCommand;
using Application.Helpers;
using EFCommands.EFDrinkCommand;
using EFCommands.EFImpressionCommand;
using EFCommands.EFMealCommand;
using EFCommands.EFMeniCommand;
using EFCommands.EFReservationCommand;
using EFCommands.EFRolleCommand;
using EFCommands.EFUserCommand;
using EFDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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

            
            services.AddTransient<IDrinkCreateCommand, EFCreateDrinkCommand>();
            services.AddTransient<IDeleteDrinkCommand, EFDeleteDrinkCommand>();
            services.AddTransient<IEditDrinkCommand, EFEditDrinkCommand>();
            services.AddTransient<IGetDrinksCommand, EFGetDrinksCommand>();
            services.AddTransient<IGetDrinkCommand, EFGetDrinkCommand>();
            

            
            services.AddTransient<IAddRolleCommand, EFAddRolleCommand>();
            services.AddTransient<IGetRolesCommand, EFGetRolesCommand>();
            services.AddTransient<IGetRoleCommand, EFGetRoleCommand>();
            services.AddTransient<IEditRoleCommand, EFEditRoleCommand>();
            services.AddTransient<IDeleteRoleCommand, EFDeleteRoleCommand>();
            

            
            services.AddTransient<IAddUserCommand, EFAddUserCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            services.AddTransient<IGetUserCommand, EFGetUserCommand>();
            services.AddTransient<IEditUserCommand, EFEditUserCommand>();
            services.AddTransient<IGetUsersCommand, EFGetUsersCommand>();
            

            
            services.AddTransient<IAddImpresssionCommand, EFAddImpressionCommand>();
            services.AddTransient<IDeleteImpressionCommand, EFDeleteImpressionCommand>();
            services.AddTransient<IGetImpressionCommand, EFGetImpressionCommand>();
            services.AddTransient<IEditImpressionCommand, EFEditImpressionCommand>();
            services.AddTransient<IGetImpressionsCommand, EFGetImpressionsCommand>();
            

            
            services.AddTransient<IAddReservationCommmand, EFAddReservationCommand>();
            services.AddTransient<IDeleteReservationCommand, EFDeleteReservationCommand>();
            services.AddTransient<IGetReservationCommand, EFGetReservationCommand>();
            services.AddTransient<IEditReservationCommand, EFEditReservationCommand>();
            services.AddTransient<IGetReservationsCommand, EFGetReservationsCommand>();


            services.AddTransient<IAddMealCommand, EFAddMealCommand>();
            services.AddTransient<IDeleteMealCommand, EFDeleteMealCommand>();
            services.AddTransient<IGetMealCommand, EFGetMealCommand>();
            services.AddTransient<IGetMealsCommand, EFGetMealsCommand>();
            services.AddTransient<IEditMealCommand, EFEditMealCommand>();


            services.AddTransient<IAddMeniCommand, EFAddMeniCommand>();
            services.AddTransient<IGetMeniCommand, EFGetMeniCommand>();
            services.AddTransient<IGetMeniesCommand, EFGetMeniesCommand>();
            services.AddTransient<IEditMeniCommand, EFEditMeniCommand>();
            services.AddTransient<IDeleteMeniCommand, EFDeleteMenicommand>();

            services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAuthUserCommand, EFAuthUserCommand>();

            var key = Configuration.GetSection("Encryption")["key"];
            var enc = new Encryption(key);
            services.AddSingleton(enc);


            services.AddTransient(s => {
                var http = s.GetRequiredService<IHttpContextAccessor>();
                var value = http.HttpContext.Request.Headers["Authorization"].ToString();
                var encryption = s.GetRequiredService<Encryption>();

                try
                {
                    var decodedString = encryption.DecryptString(value);
                    decodedString = decodedString.Replace("\t", "");
                    var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);
                    user.IsLogged = true;
                    return user;
                }
                catch (Exception)
                {
                    return new LoggedUser
                    {
                        IsLogged = false
                    };
                }
            });

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
            app.UseStaticFiles();
        }
    }
}
