using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.ForEncript;
using Application.Commands.UserCommand;
using Application.DTO;
using Application.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly Encryption _enc;
        private IAuthUserCommand _authUserCommand;

        public AuthController(Encryption enc, IAuthUserCommand authUserCommand)
        {
            _enc = enc;
            _authUserCommand = authUserCommand;
        }
        
        // POST: api/Auth
        [HttpPost]
        public IActionResult Post([FromBody] UserAuthDTO request)
        {
            
            var user = _authUserCommand.Execute(request);

            var stringObjekat = JsonConvert.SerializeObject(user);

            var encrypted = _enc.EncryptString(stringObjekat);

            return Ok(new { token = encrypted });
        }

        [HttpGet("decode")]
        public IActionResult Decode(string value)
        {
            var decodedString = _enc.DecryptString(value);
            decodedString = decodedString.Replace("\t","");
            var user = JsonConvert.DeserializeObject<LoggedUser>(decodedString);

            return null;
        }

    }
}
