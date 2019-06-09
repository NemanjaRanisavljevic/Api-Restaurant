using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ReservationCommand;
using Application.DTO;
using Application.Exceptions;
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

        public ReservationController(IAddReservationCommmand addReservationCommand, IDeleteReservationCommand deleteReservationCommand, IGetReservationCommand getReservationCommand)
        {
            _addReservationCommand = addReservationCommand;
            _deleteReservationCommand = deleteReservationCommand;
            _getReservationCommand = getReservationCommand;
        }



        // GET: api/Reservation
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public void Put(int id, [FromBody] string value)
        {
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
