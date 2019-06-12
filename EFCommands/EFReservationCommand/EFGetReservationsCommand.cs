using Application.Commands.ReservationCommand;
using Application.DTO.Reservation;
using Application.Responsed;
using Application.Searches;
using EFDataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCommands.EFReservationCommand
{
    public class EFGetReservationsCommand : EFBaseCommand, IGetReservationsCommand
    {
        public EFGetReservationsCommand(DBContext context) : base(context)
        {
        }

        public PagedRespone<ReservationGetDTO> Execute(ReservationSearch request)
        {
            var query = _context.Reservations.AsQueryable();

            

            if(request.NameUser != null)
            {
                var name = request.NameUser.ToLower();
                query = query.Where(r => r.User.Name.ToLower().Contains(name));
            }

            var totalCount = query.Count();

            query = query.Skip((request.PageNumber - 1) * request.PerPage)
                .Take(request.PerPage);

            var pageCount = (int)Math.Ceiling((double)totalCount / request.PerPage);

            var response = new PagedRespone<ReservationGetDTO>
            {

                CurrentPage = request.PageNumber,
                TotalCount = totalCount,
                PageCount = pageCount,
                Data = query.Include(u => u.User)
                .Select(r => new ReservationGetDTO
                {
                    Id = r.Id,
                    ReservationDate = r.ReservationDate,
                    Guest = r.Guest,
                    Time = r.Time,
                    UserName = r.User.Name + ' ' + r.User.Surname

                })

            };
            return response; 
        }
    }
}
