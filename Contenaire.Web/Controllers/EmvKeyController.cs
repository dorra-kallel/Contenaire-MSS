
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Concentrateur.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmvKeyController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public EmvKeyController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<EmvKeyController>
        [HttpGet]
        public IEnumerable<EmvKey> Get()
        {
            return _dbContext.EmvKeys;
        }

        // GET api/<EmvKeyController>/5
        [HttpGet("{id}")]
        public EmvKey Get(string id)
        {
            return _dbContext.EmvKeys.SingleOrDefault(x => x.Version == id);
        }

        // POST api/<EmvKeyController>
        [HttpPost]
        public void Post([FromBody] EmvKey emvKey)
        {
            _dbContext.EmvKeys.Add(emvKey);
            _dbContext.SaveChanges();

        }

        // PUT api/<EmvKeyController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] EmvKey emvKey)
        {
            _dbContext.EmvKeys.Update(emvKey);
            _dbContext.SaveChanges();
        }

        // DELETE api/<EmvKeyController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var item = _dbContext.EmvKeys.FirstOrDefault(x => x.Version == id);
            if (item != null)
            {
                _dbContext.EmvKeys.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
