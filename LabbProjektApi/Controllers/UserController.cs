using LabbProjektApi.Data;
using LabbProjektApi.DTOs;
using LabbProjektApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LabbProjektApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController(ApplicationContext dbConnectionContext) : Controller
    {
        public ApplicationContext _dbContext = dbConnectionContext;

        // http://localhost:5003/users
        [HttpGet ("/users")]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            return await _dbContext.Users.ToListAsync();
        }

        // http://localhost:5003/users/1/interests
        [HttpGet("{userId}/interests")]
        public async Task<ActionResult<IEnumerable<Interest>>> GetInterestsByUserId(int userId)
        {
            var userWithInterests = await _dbContext.Users
                .Where(u => u.Id == userId)
                .Include(u => u.Interests)
                .FirstOrDefaultAsync();

            if (userWithInterests == null)
            {
                return NotFound("Could not find specific user based on userID provided");
            }

            return Ok(userWithInterests.Interests);
        }

        // http://localhost:5003/users/1/interestlinks
        [HttpGet("{userId}/interestlinks")]
        public async Task<ActionResult<IEnumerable<InterestLink>>> GetInterestLinksByUserId(int userId)
        {
            var userWithInterestLinks = await _dbContext.Users
                .Where (u => u.Id == userId)
                .Include(u => u.InterestLinks)
                .FirstOrDefaultAsync();

            if (userWithInterestLinks == null)
            {
                return NotFound("Could not find specific user in db to show links");
            }

            return Ok(userWithInterestLinks.InterestLinks);
        }

        // OBS!! ÄNDRA TILL POST I POSTMAN
        // http://localhost:5003/users/link-user-to-interest
        [HttpPost ("link-user-to-interest")] // <--PostFunktion
        public async Task<IActionResult> LinkUserToInterest(LinkUserToInterestDto dto)
        {
            var user = await _dbContext.Users
                .Include(u => u.Interests)
                .FirstOrDefaultAsync(u => u.Id == dto.UsersId);
            if (user == null)
            {
                return NotFound("Could not find user on provided UserId.");
            }

            var interest = await _dbContext.Interests
                .FirstOrDefaultAsync(i => i.Id == dto.InterestsId);
            if (interest == null)
            {
                return NotFound("Could not find interest based on interestId.");
            }

            //Vi kollar om användaren redan är kopplad till intresset
            if (user.Interests.Any(i => i.Id == dto.InterestsId)) 
            {
                return BadRequest("User is already connected to this interest.");
            }

            user.Interests.Add(interest);
            await _dbContext.SaveChangesAsync();

            return Ok("Connected user to desired interest succesfully.");
        }
    }
}
