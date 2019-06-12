using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ReservationCommand;
using Application.DTO;
using Application.DTO.Reservation;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private IAddReservationCommmand _addReservationCommand;
        private IDeleteReservationCommand _deleteReservationCommand;
        private IGetReservationCommand _getReservationCommand;
        private IEditReservationCommand _editReservationCommand;
        private IGetReservationsCommand _getReservationsCommmand;

        public ReservationController(IAddReservationCommmand addReservationCommand, IDeleteReservationCommand deleteReservationCommand, IGetReservationCommand getReservationCommand, IEditReservationCommand editReservationCommand, IGetReservationsCommand getReservationsCommmand)
        {
            _addReservationCommand = addReservationCommand;
            _deleteReservationCommand = deleteReservationCommand;
            _getReservationCommand = getReservationCommand;
            _editReservationCommand = editReservationCommand;
            _getReservationsCommmand = getReservationsCommmand;
        }




        // GET: api/Reservation
        [HttpGet]
        public IActionResult Get([FromQuery] ReservationSearch request)
        {
            try
            {
                var response = _getReservationsCommmand.Execute(request);
                return Ok(response);
            }
            catch
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // GET: api/Reservation/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var res = _getReservationCommand.Execute(id);
                return Ok(res);
            }catch(NotFoundException)
            {
                return NotFound();
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // POST: api/Reservation
        [HttpPost]
        public IActionResult Post([FromBody] ReservationDTO value)
        {
            try
            {
                _addReservationCommand.Execute(value);
                return StatusCode(201, "Reservation create");
            }catch(DataCanNotBeNull)
            {
                return StatusCode(422, "Guest can not be null");
            }catch(NotFoundException)
            {
                return StatusCode(404, "User not found");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // PUT: api/Reservation/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ReservationEditDTO value)
        {
            try
            {
                _editReservationCommand.Execute(value);
                return NoContent();
            }catch(AlredyExistException)
            {
                return StatusCode(422, "Any of parameters alredy exit value");

            }
            catch(NotFoundException)
            {
                return NotFound();
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteReservationCommand.Execute(id);
                return NoContent();
            }catch(NotFoundException)
            {
                return NotFound();
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }
    }
}
