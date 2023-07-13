
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Concentrateur.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmvDdolController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public EmvDdolController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<EmvDdolController>
        [HttpGet]
        public IEnumerable<EmvDdol> Get()
        {
            return _dbContext.EmvDdols;
        }

        // GET api/<EmvDdolController>/5
        [HttpGet("{id}")]
        public EmvDdol Get(string id)
        {
            return _dbContext.EmvDdols.SingleOrDefault(x => x.Version == id);
        }


        // POST api/<EmvDdolController>
        [HttpPost]
        public void Post([FromBody] EmvDdol emvDdol)
        {
            _dbContext.EmvDdols.Add(emvDdol);
            _dbContext.SaveChanges();

        }

        // PUT api/<EmvDdolController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] EmvDdol emvDdol)
        {
            _dbContext.EmvDdols.Update(emvDdol);
            _dbContext.SaveChanges();
        }

        // DELETE api/<EmvDdolController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var item = _dbContext.EmvDdols.FirstOrDefault(x => x.Version == id);
            if (item != null)
            {
                _dbContext.EmvDdols.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
