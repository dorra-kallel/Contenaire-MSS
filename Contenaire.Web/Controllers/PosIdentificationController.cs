using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contenaire.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosIdentificationsController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public PosIdentificationsController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<PosIdentificationsController>
        [HttpGet]
        public IEnumerable<PosIdentification> Get()
        {
            return _dbContext.PosIdentifications;
        }

        // GET api/<PosIdentificationsController>/5
        [HttpGet("{id}")]
        public PosIdentification Get(String id)
        {
            return _dbContext.PosIdentifications.SingleOrDefault(x => x.IdTerminal == id);
        }

        // POST api/<PosIdentificationsController>
        [HttpPost]
        public void Post([FromBody] PosIdentification posIdentification)
        {
            _dbContext.PosIdentifications.Add(posIdentification);
            _dbContext.SaveChanges();
        }

        // PUT api/<PosIdentificationsController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] PosIdentification posIdentification)
        {
            _dbContext.PosIdentifications.Update(posIdentification);
            _dbContext.SaveChanges();
        }

        // DELETE api/<PosIdentificationsController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            var item = _dbContext.PosIdentifications.FirstOrDefault(x => x.IdTerminal == id);
            if (item != null)
            {
                _dbContext.PosIdentifications.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
