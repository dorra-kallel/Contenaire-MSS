using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contenaire.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrefixesController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public PrefixesController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<PrefixesController>
        [HttpGet]
        public IEnumerable<Prefix> Get()
        {
            return _dbContext.Prefixes;
        }

        // GET api/<PrefixesController>/5
        [HttpGet("{id}")]
        public Prefix Get(int id)
        {
            return _dbContext.Prefixes.SingleOrDefault(x => x.IdPrefix == id);
        }

        // POST api/<PrefixesController>
        [HttpPost]
        public void Post([FromBody] Prefix prefix)
        {
            _dbContext.Prefixes.Add(prefix);
            _dbContext.SaveChanges();
        }

        // PUT api/<PrefixesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Prefix prefix)
        {
            _dbContext.Prefixes.Update(prefix);
            _dbContext.SaveChanges();
        }

        // DELETE api/<PrefixesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _dbContext.Prefixes.FirstOrDefault(x => x.IdPrefix == id);
            if (item != null)
            {
                _dbContext.Prefixes.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
