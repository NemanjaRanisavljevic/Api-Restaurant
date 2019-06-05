using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.DrinkCommand;
using Application.DTO.CreateDTO;
using Application.Exceptions;
using Application.Searches;
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
        private IEditDrinkCommand _editDrinkCommand;
        private IGetDrinksCommand _getDrinksCommand;
        private IGetDrinkCommand _getDrinkCommand;

        public DrinkController(IDrinkCreateCommand createDrinkCommand, IDeleteDrinkCommand deleteDrinkCommand, IEditDrinkCommand editDrinkCommand, IGetDrinksCommand getDrinksCommand, IGetDrinkCommand getDrinkCommand)
        {
            _createDrinkCommand = createDrinkCommand;
            _deleteDrinkCommand = deleteDrinkCommand;
            _editDrinkCommand = editDrinkCommand;
            _getDrinksCommand = getDrinksCommand;
            _getDrinkCommand = getDrinkCommand;
        }

        // GET: api/Drink
        [HttpGet]
        public IActionResult Get([FromQuery] DrinkSearch drinkSearch)
        {
            try
            {
               var search = _getDrinksCommand.Execute(drinkSearch);
                return Ok(search);
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // GET: api/Drink/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            try
            {
                var drink = _getDrinkCommand.Execute(id);
                return Ok(drink);
            }catch(NotFoundException)
            {
                return NotFound();
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
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
        public IActionResult Put(int id,[FromBody] CreateDrinkDTO value)
        {
            try
            {
                _editDrinkCommand.Execute(value);
                return NoContent();
            }catch(AlredyExistException)
            {
                return StatusCode(409, "Drink name Alredy Exist");
            }catch(DataCanNotBeNull)
            {
                return StatusCode(409, "Price can not be null");
            }catch(NotFoundException)
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
                _deleteDrinkCommand.Execute(id);
                return NoContent();
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
