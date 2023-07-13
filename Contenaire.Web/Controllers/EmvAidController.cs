
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmvAidController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public EmvAidController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<UseController>
        [HttpGet]
        public IEnumerable<EmvAid> Get()
        {
            return _dbContext.EmvAids;
        }

        // GET api/<UseController>/5
        [HttpGet("{id}")]
        public EmvAid Get(string id)
        {
            return _dbContext.EmvAids.SingleOrDefault(x => x.Version == id);
        }

        // POST api/<UseController>
        [HttpPost]
        public void Post([FromBody] EmvAid emvAid)
        {
            _dbContext.EmvAids.Add(emvAid);
            _dbContext.SaveChanges();

        }

        // PUT api/<UseController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] EmvAid emvAid)
        {
            _dbContext.EmvAids.Update(emvAid);
            _dbContext.SaveChanges();
        }

        // DELETE api/<UseController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var item = _dbContext.EmvAids.FirstOrDefault(x => x.Version == id);
            if (item != null)
            {
                _dbContext.EmvAids.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
