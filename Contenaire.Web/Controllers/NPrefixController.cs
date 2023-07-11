using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contenaire.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NPrefixController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public NPrefixController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<NPrefixController>
        [HttpGet]
        public IEnumerable<Nprefix> Get()
        {
            return _dbContext.Nprefixes;
        }

        // GET api/<NPrefixController>/5
        [HttpGet("{id}")]
        public Nprefix Get(int id)
        {
            return _dbContext.Nprefixes.SingleOrDefault(x => x.IdPrefix== id);
        }

        // POST api/<NPrefixController>
        [HttpPost]
        public void Post([FromBody] Nprefix nprefix)
        {
            _dbContext.Nprefixes.Add(nprefix);
            _dbContext.SaveChanges();

        }

        // PUT api/<NPrefixController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Nprefix nprefix)
        {
            _dbContext.Nprefixes.Update(nprefix);
            _dbContext.SaveChanges();
        }

        // DELETE api/<NPrefixController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _dbContext.Nprefixes.FirstOrDefault(x => x.IdPrefix == id);
            if (item != null)
            {
                _dbContext.Nprefixes.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
