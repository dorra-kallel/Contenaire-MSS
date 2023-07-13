
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Concentrateur.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmvRandCallController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public EmvRandCallController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<EmvRandCallController>
        [HttpGet]
        public IEnumerable<EmvRandCall> Get()
        {
            return _dbContext.EmvRandCalls;
        }

        // GET api/<EmvRandCallController>/5
        [HttpGet("{id}")]
        public EmvRandCall Get(string id)
        {
            return _dbContext.EmvRandCalls.SingleOrDefault(x => x.Version == id);
        }

        // POST api/<EmvRandCallController>
        [HttpPost]
        public void Post([FromBody] EmvRandCall emvRandCall)
        {

            _dbContext.EmvRandCalls.Add(emvRandCall);
            _dbContext.SaveChanges();
        }


        // PUT api/<EmvRandCallController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmvRandCall emvRandCall)
        {

            _dbContext.EmvRandCalls.Update(emvRandCall);
            _dbContext.SaveChanges();
        }

        // DELETE api/<EmvRandCallController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var item = _dbContext.EmvRandCalls.FirstOrDefault(x => x.Version == id);
            if (item != null)
            {
                _dbContext.EmvRandCalls.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
