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
    public class InterestLinksController (ApplicationContext dbConnectionContext) : Controller
    {
        public ApplicationContext _dbContext = dbConnectionContext;

        [HttpPost("/add-interest-link")]
        public async Task<IActionResult> CreateInterestLink(InterestLinkDto dto)
        {
            var interest = await _dbContext.Interests
                .FindAsync(dto.InterestsId);
            var user = await _dbContext.Users
                .FindAsync(dto.UsersId);

            if (interest == null || user == null)
            {
                return NotFound("Could not find specified user or interest");
            }

            var interestLink = new InterestLink
            {
                Link = dto.Link,
                Title = dto.Title,
                Interests = interest,
                Users = user
            };

            _dbContext.InterestLinks.Add(interestLink);
            await _dbContext.SaveChangesAsync();

            return Ok(new { message = "Website has been added and connected to desired user and interest." });
        }
    }
}
