using BooksApi.Models;
using BooksApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BooksApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> Get() =>
            await _userService.GetAsync();

        [HttpGet("{id:length(24)}", Name = "GetUser")]
        public async Task<ActionResult<User>> Get(string id)
        {
            var user = await _userService.GetAsync(id).ConfigureAwait(false);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            await _userService.CreateAsync(user);

            return CreatedAtAction("GetUser", new { id = user.Id.ToString() }, user);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User userIn)
        {
            var user = await _userService.GetAsync(id).ConfigureAwait(false);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.UpdateAsync(id, userIn).ConfigureAwait(false);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var user = await _userService.GetAsync(id).ConfigureAwait(false);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.RemoveAsync(user.Id).ConfigureAwait(false);

            return NoContent();
        }
    }
}