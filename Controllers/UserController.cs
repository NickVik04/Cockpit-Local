using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Cockpit_Local.Data;
using Cockpit_Local.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Cockpit_Local.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpPost]
        public async Task<IActionResult> PostUsers([FromBody] Users users)
        {
            if (users == null)
            {
                return BadRequest("User data is null.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _context.Users.AddAsync(users);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetUsers", new { id = users.ID }, users);

            }

            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, [FromBody] Users user)
        {
            if (user == null)
            {
                return BadRequest("User data is null.");
            }

            if (id != user.ID)
            {
                return BadRequest("User ID mismatch.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            // Update the existing user with the new values
            existingUser.UserName = user.UserName;
            existingUser.EmailID = user.EmailID;
            existingUser.PhoneNumber = user.PhoneNumber;
            existingUser.Address1 = user.Address1;
            existingUser.Address2 = user.Address2;
            existingUser.Country = user.Country;
            existingUser.State = user.State;
            existingUser.PinCode = user.PinCode;
            existingUser.Brand = user.Brand;
            existingUser.Stores = user.Stores;
            existingUser.CockpitRoles = user.CockpitRoles;

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            _context.Users.Remove(user);

            try
            {
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }




    }
}
