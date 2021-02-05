using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using comp2001asp.Models;

namespace comp2001asp.Controllers
{
    [Route("API/user")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataAccess _context;

        public UsersController(DataAccess context)
        {
            _context = context;
        }

        [NonAction]
        public void Register(User user, out string NewUser)
        {
            _context.Register(user, out NewUser);
        }

        [NonAction]
        public bool getValidateUser(User user)
        {
            return _context.Validate(user);
        }



        // GET: api/Users
        [HttpGet]
        public async Task<IActionResult> Get(User user)
        {

            bool v1 = getValidateUser(user);

            if (v1)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(208);
            }
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, User user)
        {
            _context.Update(user, id);

            return StatusCode(200);
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> Post(User user)
        {
            string Response;

            Register(user, out Response);

            if (Response.Contains("200"))
            {
                return Ok(user);
            }
            else
            {
                return StatusCode(208);
            }
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _context.Delete(id);
            return StatusCode(200);
        }


        [NonAction]
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Users_ID == id);
        }
    }
}
