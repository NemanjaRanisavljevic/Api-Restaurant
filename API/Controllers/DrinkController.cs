using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.DrinkCommand;
using Application.DTO.CreateDTO;
using Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private IDrinkCreateCommand _createDrinkCommand;
        private IDeleteDrinkCommand _deleteDrinkCommand;

        public DrinkController(IDrinkCreateCommand createDrinkCommand, IDeleteDrinkCommand deleteDrinkCommand)
        {
            _createDrinkCommand = createDrinkCommand;
            _deleteDrinkCommand = deleteDrinkCommand;
        }


        // GET: api/Drink
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Radi");
        }

        // GET: api/Drink/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Drink
        [HttpPost]
        public IActionResult Post([FromBody] CreateDrinkDTO value)
        {
            try
            {
                _createDrinkCommand.Execute(value);
                return StatusCode(201,"Create Drink is succesfuly");
            }
            catch (DataCanNotBeNull)
            {
               return StatusCode(422, "Price can not be null");
            }
            catch (AlredyExistException)
            {
                return StatusCode(422, "Drink name alredy exist");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server errors, try later");
            }
        }

        // PUT: api/Drink/5
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
                _deleteDrinkCommand.Execute(id);
                return StatusCode(204, "Drink is deleted");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }
    }
}
