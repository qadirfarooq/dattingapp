using API.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    // [ApiController]
    // [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
      private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }
      [AllowAnonymous]
       [HttpGet]
       public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
       {
         return  await _context.Users.ToListAsync();
       }
      [Authorize]
       [HttpGet("{id}")]
       public async Task<ActionResult <AppUser>> GetUsers(int id)
       {
         return await  _context.Users.FindAsync(id);
       }
    }
}