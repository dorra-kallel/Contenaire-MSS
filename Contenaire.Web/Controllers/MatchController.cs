using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contenaire.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
       
        private readonly ConcentrateurContext _dbContext;
        public MatchController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<MatchController>
        [HttpGet]
        public IEnumerable<Match> Get()
        {

            return _dbContext.Matches;
        }

        // GET api/<MatchController>/5
        [HttpGet("{id}")]
        public Match Get(String id)
        {
            return _dbContext.Matches.SingleOrDefault(x => x.MatchFieldName == id);
        }

        // POST api/<MatchController>
        [HttpPost]
        public void Post([FromBody] Match match)
        {
            _dbContext.Matches.Add(match);
            _dbContext.SaveChanges();

        }

        // PUT api/<MatchController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] Match match)
        {

            _dbContext.Matches.Update(match);
            _dbContext.SaveChanges();
        }

        // DELETE api/<MatchController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {

            var item = _dbContext.Matches.FirstOrDefault(x => x.MatchFieldName == id);
            if (item != null)
            {
                _dbContext.Matches.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
