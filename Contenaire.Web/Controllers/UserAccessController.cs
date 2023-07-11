using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contenaire.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAccessController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public UserAccessController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<UserAccessController>
        [HttpGet]
        public IEnumerable<UserAccess> Get()
        {
            return _dbContext.UserAccesses;
        }

        // GET api/<UserAccessController>/5
        [HttpGet("{id}")]
        public UserAccess Get(String id)
        {
            return _dbContext.UserAccesses.SingleOrDefault(x => x.IdUserAccess == id);
        }

        // POST api/<UserAccessController>
        [HttpPost]
        public void Post([FromBody] UserAccess userAccess)
        {
            _dbContext.UserAccesses.Add(userAccess);
            _dbContext.SaveChanges();
        }

        // PUT api/<UserAccessController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] UserAccess userAccess)
        {
            _dbContext.UserAccesses.Update(userAccess);
            _dbContext.SaveChanges();
        }

        // DELETE api/<UserAccessController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            var item = _dbContext.UserAccesses.FirstOrDefault(x => x.IdUserAccess == id);
            if (item != null)
            {
                _dbContext.UserAccesses.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
