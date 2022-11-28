using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //GET /api/users //update test 20221128 zzz
    public class UsersController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
                var users = await _context.Users.ToListAsync();

                return users;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
                var users = await _context.Users.FindAsync(id);

                return users;
        }

        //Loading data from stored procedure - 10248
        [HttpPost("GetUsernameByID")]
        public async Task<IEnumerable<GetUsernameByID>> GetUsernameByID(int Id)
        {
            return await _context.GetProcedures().GetUsernameByID(Id);
        }

  
    }
}