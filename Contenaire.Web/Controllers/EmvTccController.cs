
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Concentrateur.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmvTccController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public EmvTccController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<EmvTccController>
        [HttpGet]
        public IEnumerable<EmvTcc> Get()
        {
            return _dbContext.EmvTccs;
        }

        // GET api/<EmvTccController>/5
        [HttpGet("{id}")]
        public EmvTcc Get(string id)
        {
            return _dbContext.EmvTccs.SingleOrDefault(x => x.Version == id);
        }

        // POST api/<EmvTccController>
        [HttpPost]
        public void Post([FromBody] EmvTcc emvTcc)
        {
            _dbContext.EmvTccs.Add(emvTcc);
            _dbContext.SaveChanges();

        }

        // PUT api/<EmvTccController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] EmvTcc emvTcc)
        {
            _dbContext.EmvTccs.Update(emvTcc);
            _dbContext.SaveChanges();
        }

        // DELETE api/<EmvTccController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var item = _dbContext.EmvTccs.FirstOrDefault(x => x.Version == id);
            if (item != null)
            {
                _dbContext.EmvTccs.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
