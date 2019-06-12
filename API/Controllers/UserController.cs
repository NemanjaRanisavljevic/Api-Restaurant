using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Commands.UserCommand;
using Application.DTO;
using Application.Exceptions;
using Application.Searches;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IAddUserCommand _addUserCommand;
        private IDeleteUserCommand _deleteUserCommand;
        private IGetUserCommand _getUserCommand;
        private IEditUserCommand _editUserCommand;
        private IGetUsersCommand _getUsersCommand;
        

        public UserController(IAddUserCommand addUserCommand, 
            IDeleteUserCommand deleteUserCommand, 
            IGetUserCommand getUserCommand, 
            IEditUserCommand editUserCommand, 
            IGetUsersCommand getUsersCommand)
        {
            _addUserCommand = addUserCommand;
            _deleteUserCommand = deleteUserCommand;
            _getUserCommand = getUserCommand;
            _editUserCommand = editUserCommand;
            _getUsersCommand = getUsersCommand;
        }





        // GET: api/User
        [HttpGet]
        public IActionResult Get([FromQuery] UserSearch request)
        {
            try
            {
                var users = _getUsersCommand.Execute(request);
                return Ok(users);
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _getUserCommand.Execute(id);
                return Ok(user);
            }catch(NotFoundException)
            {
                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }

        // POST: api/User
        [HttpPost]
        public IActionResult Post([FromBody] UserDTO request)
        {
            try
            {
                _addUserCommand.Execute(request);
                return StatusCode(201, "User is succefuly create.");
            }catch(NotFoundException)
            {
                return StatusCode(404, "Role id Not Found");
            }catch(AlredyExistException)
            {
                return StatusCode(422, "Email alredy exist");
            }catch(Exception)
            {
                return StatusCode(500, "Server error, try later");
            }
        }
        

        // PUT: api/User/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserSearchDTO value)
        {
            try
            {
                _editUserCommand.Execute(value);
                return NoContent();
            }catch(AlredyExistException)
            {
                return StatusCode(422, "Email or Name or Surname or Rolle or Password alredy exist");
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch(Exception)
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
                _deleteUserCommand.Execute(id);
                return StatusCode(204,"User is deleted");
            }catch(AlredyExistException)
            {
                return Conflict("User is alredy deleted");
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
