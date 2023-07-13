
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Concentrateur.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmvTdolController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public EmvTdolController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<EmvTdolController>
        [HttpGet]
        public IEnumerable<EmvTdol> Get()
        {
            return _dbContext.EmvTdols;
        }

        // GET api/<EmvTdolController>/5
        [HttpGet("{id}")]
        public EmvTdol Get(string id)
        {
            return _dbContext.EmvTdols.SingleOrDefault(x => x.Version == id);
        }

        // POST api/<EmvTdolController>
        [HttpPost]
        public void Post([FromBody] EmvTdol emvTdol)
        {
            _dbContext.EmvTdols.Add(emvTdol);
            _dbContext.SaveChanges();

        }

        // PUT api/<EmvTdolController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] EmvTdol emvTdol)
        {
            _dbContext.EmvTdols.Update(emvTdol);
            _dbContext.SaveChanges();
        }

        // DELETE api/<EmvTdolController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var item = _dbContext.EmvTdols.FirstOrDefault(x => x.Version == id);
            if (item != null)
            {
                _dbContext.EmvTdols.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}