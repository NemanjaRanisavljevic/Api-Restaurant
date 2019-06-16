using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.MealCommand;
using Application.DTO.MealDTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private IAddMealCommand _addMealCommand;
        private IDeleteMealCommand _deleteMealCommand;
        private IGetMealCommand _getMealCommand;
        private IGetMealsCommand _getMealsCommand;
        private IEditMealCommand _editMealCommand;

        public MealController(IAddMealCommand addMealCommand, 
            IDeleteMealCommand deleteMealCommand, 
            IGetMealCommand getMealCommand, 
            IGetMealsCommand getMealsCommand, 
            IEditMealCommand editMealCommand)
        {
            _addMealCommand = addMealCommand;
            _deleteMealCommand = deleteMealCommand;
            _getMealCommand = getMealCommand;
            _getMealsCommand = getMealsCommand;
            _editMealCommand = editMealCommand;
        }

        // GET: api/Meal
        [HttpGet]
        public ActionResult<IEnumerable<MealGetDTO>> Get([FromQuery] MealSearch request)
        {
            try
            {
                var meals = _getMealsCommand.Execute(request);
                return Ok(meals);
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // GET: api/Meal/5
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<MealGetDTO>> Get(int id)
        {
            try
            {
                var meal = _getMealCommand.Execute(id);
                return Ok(meal);
            }catch(NotFoundException)
            {
                return StatusCode(404, "Meal not found or meal is deleted");
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // POST: api/Meal
        [HttpPost]
        public ActionResult Post([FromBody] MealCreateDTO value)
        {
            try
            {
                _addMealCommand.Execute(value);
                return StatusCode(201, "Meal is succesfuly create");
            }catch(AlredyExistException)
            {
                return StatusCode(422, "Name of meal alredy exist");

            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // PUT: api/Meal/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] MealGetDTO value)
        {
            try
            {
                _editMealCommand.Execute(value);
                return NoContent();
            }catch(NotFoundException)
            {
                return NotFound();
            }catch(AlredyExistException)
            {
                return StatusCode(422, "Name alredy exist");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _deleteMealCommand.Execute(id);
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
