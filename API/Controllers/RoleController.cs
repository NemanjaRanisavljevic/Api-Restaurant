using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.RoleCommand;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private IAddRolleCommand _addRoleCommand;
        private IGetRolesCommand _getRolesCommand;
        private IGetRoleCommand _getRoleCommand;
        private IEditRoleCommand _editRoleCommand;
        private IDeleteRoleCommand _deleteRoleCommand;

        public RoleController(IAddRolleCommand addRoleCommand, IGetRolesCommand getRolesCommand, IGetRoleCommand getRoleCommand, IEditRoleCommand editRoleCommand, IDeleteRoleCommand deleteRoleCommand)
        {
            _addRoleCommand = addRoleCommand;
            _getRolesCommand = getRolesCommand;
            _getRoleCommand = getRoleCommand;
            _editRoleCommand = editRoleCommand;
            _deleteRoleCommand = deleteRoleCommand;
        }
        
        // GET: api/Role
        [HttpGet]
        public IActionResult GetRole([FromQuery] RuleSearch request)
        {
            try
            {
                var search = _getRolesCommand.Execute(request);
                return Ok(search);
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            try
            {
                var search = _getRoleCommand.Execute(id);
                return Ok(search);
            }catch(NotFoundException)
            {
                return NotFound();
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // POST: api/Role
        [HttpPost]
        public IActionResult PostRole([FromBody] RoleDTO value)
        {

            try
            {
                _addRoleCommand.Execute(value);
                return StatusCode(201,"Create now Role");
            }
            catch (AlredyExistException)
            {
                return StatusCode(422, "This role alredy exist.");
            }
            catch (DataCanNotBeNull)
            {
                return StatusCode(422, "Role name can not be null");
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public IActionResult PutRole(int id, [FromBody] RoleDTO value)
        {
            try
            {
                _editRoleCommand.Execute(value);
                return NoContent();
            }catch(AlredyExistException)
            {
                return StatusCode(422, "Role name or isDelete alredy set.");
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
        public IActionResult DeleteRole(int id)
        {
            try
            {
                _deleteRoleCommand.Execute(id);
                return NoContent();
            }catch(NotFoundException)
            {
                return NotFound();
            }catch(AlredyExistException)
            {
                return StatusCode(422, "Role is alredy deleted");
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }
    }
}
