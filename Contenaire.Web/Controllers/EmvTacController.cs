
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Concentrateur.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmvTacController : ControllerBase
    {
       
            private readonly ConcentrateurContext _dbContext;
            public EmvTacController(ConcentrateurContext dbContext)
            {
                _dbContext = dbContext;

            }
            // GET: api/<EmvTacController>
            [HttpGet]
        public IEnumerable<EmvTac> Get()
        {
            return _dbContext.EmvTacs;
        }

        // GET api/<EmvTacController>/5
        [HttpGet("{id}")]
        public EmvTac Get(string id)
        {
            return _dbContext.EmvTacs.SingleOrDefault(x => x.Version == id);
        }

        // POST api/<EmvTacController>
        [HttpPost]
        public void Post([FromBody] EmvTac emvTac)
        {
            _dbContext.EmvTacs.Add(emvTac);
            _dbContext.SaveChanges();

        }

        // PUT api/<EmvTacController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] EmvTac emvTac)
        {
            _dbContext.EmvTacs.Update(emvTac);
            _dbContext.SaveChanges();
        }

        // DELETE api/<EmvTacController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var item = _dbContext.EmvTacs.FirstOrDefault(x => x.Version == id);
            if (item != null)
            {
                _dbContext.EmvTacs.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
