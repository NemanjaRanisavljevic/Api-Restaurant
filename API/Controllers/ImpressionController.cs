using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.ImpressionCommand;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImpressionController : ControllerBase
    {
        private IAddImpresssionCommand _addImpressionCommand;
        private IDeleteImpressionCommand _deleteImpressionCommand;
        private IGetImpressionCommand _getImpressionCommand;
        private IEditImpressionCommand _editImpressionCommand;
        private IGetImpressionsCommand _getImpressionsCommand;

        public ImpressionController(IAddImpresssionCommand addImpressionCommand, 
            IDeleteImpressionCommand deleteImpressionCommand, 
            IGetImpressionCommand getImpressionCommand, 
            IEditImpressionCommand editImpressionCommand, 
            IGetImpressionsCommand getImpressionsCommand)
        {
            _addImpressionCommand = addImpressionCommand;
            _deleteImpressionCommand = deleteImpressionCommand;
            _getImpressionCommand = getImpressionCommand;
            _editImpressionCommand = editImpressionCommand;
            _getImpressionsCommand = getImpressionsCommand;
        }



        // GET: api/Impression
        [HttpGet]
        public IActionResult Get([FromQuery] ImpressSearch request)
        {
            try
            {
                var search = _getImpressionsCommand.Execute(request);
                return Ok(search);
            }catch(NotFoundException)
            {
                return NotFound();
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // GET: api/Impression/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var res = _getImpressionCommand.Execute(id);
                return Ok(res);
            }catch(NotFoundException)
            {
                return NotFound();
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // POST: api/Impression
        [HttpPost]
        public IActionResult Post([FromBody] ImpressionDTO value)
        {
            try
            {
                _addImpressionCommand.Execute(value);
                return StatusCode(201, "Impression is create");
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

        // PUT: api/Impression/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ImpressionEditDTO value)
        {
            try
            {
                _editImpressionCommand.Execute(value);
                return NoContent();
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
                _deleteImpressionCommand.Execute(id);
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
