using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiRepoTest.Data;
using WebApiRepoTest.Models;

namespace WebApiRepoTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VictimController : ControllerBase
    {
        private readonly VictimDbContext _dbContext;
        public VictimController(VictimDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var vict = _dbContext.victims.ToList();
            return Ok(vict);
        }
        

        [HttpPost]
        public ActionResult AddVictim([FromBody] Victim victim)
        {
            _dbContext.victims.Add(victim);
            _dbContext.SaveChanges();
            return Ok(victim);
        }
    }
}
