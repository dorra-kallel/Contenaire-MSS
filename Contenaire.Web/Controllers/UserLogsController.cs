using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contenaire.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogsController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public UserLogsController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<UserLogsController>
        [HttpGet]
        public IEnumerable<UserLog> Get()
        {
            return _dbContext.UserLogs;
        }

        // GET api/<UserLogsController>/5
        [HttpGet("{id}")]
        public UserLog Get(String id)
        {
            return _dbContext.UserLogs.SingleOrDefault(x => x.IdLog == id);
        }

        // POST api/<UserLogsController>
        [HttpPost]
        public void Post([FromBody] UserLog userLogs)
        {
            _dbContext.UserLogs.Add(userLogs);
            _dbContext.SaveChanges();
        }

        // PUT api/<UserLogsController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] UserLog userLogs)
        {
            _dbContext.UserLogs.Update(userLogs);
            _dbContext.SaveChanges();
        }

        // DELETE api/<UserLogsController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            var item = _dbContext.UserLogs.FirstOrDefault(x => x.IdLog == id);
            if (item != null)
            {
                _dbContext.UserLogs.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
