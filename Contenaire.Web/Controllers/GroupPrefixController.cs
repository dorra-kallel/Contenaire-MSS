
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Concentrateur.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupPrefixController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public GroupPrefixController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<GroupPrefixController>
        [HttpGet]
        public IEnumerable<GroupPrefix> Get()
        {
            return _dbContext.GroupPrefixes;
        }

        // GET api/<GroupPrefixController>/5
        [HttpGet("{id}")]
        public GroupPrefix Get(int id)
        {
            return _dbContext.GroupPrefixes.SingleOrDefault(x => x.IdPrefixGroup == id);
        }

        // POST api/<GroupPrefixController>
        [HttpPost]
        public void Post([FromBody] GroupPrefix groupPrefix)
        {
            _dbContext.GroupPrefixes.Add(groupPrefix);
            _dbContext.SaveChanges();
        }

        // PUT api/<GroupPrefixController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] GroupPrefix groupPrefix)
        {
            _dbContext.GroupPrefixes.Update(groupPrefix);
            _dbContext.SaveChanges();
        }

        // DELETE api/<GroupPrefixController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _dbContext.GroupPrefixes.FirstOrDefault(x => x.IdPrefixGroup == id);
            if (item != null)
            {
                _dbContext.GroupPrefixes.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
    
}
