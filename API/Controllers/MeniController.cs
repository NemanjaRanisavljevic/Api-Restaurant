using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using API.HTTPDTO;
using Application.Commands.MeniCommand;
using Application.DTO.MeniDTO;
using Application.Exceptions;
using Application.Helpers;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeniController : ControllerBase
    {
        private IAddMeniCommand _addMeniCommand;
        private IGetMeniCommand _getMeniCommand;
        private IGetMeniesCommand _getMeniesCommand;
        private IEditMeniCommand _editMeniCommand;
        private IDeleteMeniCommand _deleteMeniCommand;

        public MeniController(IAddMeniCommand addMeniCommand, 
            IGetMeniCommand getMeniCommand, 
            IGetMeniesCommand getMeniesCommand, 
            IEditMeniCommand editMeniCommand, 
            IDeleteMeniCommand deleteMeniCommand)
        {
            _addMeniCommand = addMeniCommand;
            _getMeniCommand = getMeniCommand;
            _getMeniesCommand = getMeniesCommand;
            _editMeniCommand = editMeniCommand;
            _deleteMeniCommand = deleteMeniCommand;
        }



        // GET: api/Meni
        [HttpGet]
        public IActionResult Get([FromQuery] MeniSearch request)
        {
            try
            {
                var menies = _getMeniesCommand.Execute(request);
                return Ok(menies);
            }catch(Exception)
            {
                return StatusCode(500, "Server error try later");
            }
        }

        // GET: api/Meni/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var search = _getMeniCommand.Execute(id);
                return Ok(search);
            }catch(NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error try later");
            }
        }

        // POST: api/Meni
        [HttpPost]
        public IActionResult Post([FromForm] HttpSlikaDTO p)
        {
            
                var ext = Path.GetExtension(p.Image.FileName); //daje ekstenziju .jpg

                if (!FileUpload.AllowExtensions.Contains(ext))
                {
                    return UnprocessableEntity("Image extension is not allowed.");
                }
            

            try
            {
                  var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;//unique za ime fajla

                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

                    p.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                
                   
                var dto = new MeniAddDTO
                {
                    NameFood = p.NameFood,
                    Ingradiant = p.Ingradiant,
                    FileName = newFileName,
                    Price = p.Price,
                    MealId = p.MealId
                };

                _addMeniCommand.Execute(dto);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return StatusCode(404, "Meal of food not found");
            }catch(AlredyExistException)
            {
                return StatusCode(422, "Name of food alredy exist");
            }
            catch (Exception)
            {
                return StatusCode(500,"Server error try later");
            }
         
        }

        // PUT: api/Meni/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] HttpSlikaUpdateDTO p)
        {
            var ext = Path.GetExtension(p.Image.FileName); //daje ekstenziju .jpg

            if (!FileUpload.AllowExtensions.Contains(ext))
            {
                return UnprocessableEntity("Image extension is not allowed.");
            }

            try
            {
                var newFileName = Guid.NewGuid().ToString() + "_" + p.Image.FileName;//unique za ime fajla

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", newFileName);

                p.Image.CopyTo(new FileStream(filePath, FileMode.Create));


                var dto = new MeniAddDTO
                {
                    Id = p.Id,
                    NameFood = p.NameFood,
                    Ingradiant = p.Ingradiant,
                    FileName = newFileName,
                    Price = p.Price,
                    MealId = p.MealId
                };

                _editMeniCommand.Execute(dto);
                return NoContent();
            }
            catch (NotFoundException)
            {
                return StatusCode(404, "Meal id not found or id of meni");
            }
            catch (AlredyExistException)
            {
                return StatusCode(422, "Name of food alredy exist");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error try later");
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _deleteMeniCommand.Execute(id);
                return NoContent();
            }catch(NotFoundException)
            {
                return NotFound();
            }catch(Exception)
            {
                return StatusCode(500, "Server error try later");
            }
        }
    }



}
