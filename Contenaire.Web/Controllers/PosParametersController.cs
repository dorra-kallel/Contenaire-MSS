using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contenaire.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PosParametersController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public PosParametersController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<PosParametersController>
        [HttpGet]
        public IEnumerable<PosParameter> Get()
        {
            return _dbContext.PosParameters;
        }

        // GET api/<PosParametersController>/5
        [HttpGet("{id}")]
        public PosParameter Get(String id)
        {
            return _dbContext.PosParameters.SingleOrDefault(x => x.P1IdTerminal == id);
        }

        // POST api/<PosParametersController>
        [HttpPost]
        public void Post([FromBody] PosParameter posParameter)
        {
            _dbContext.PosParameters.Add(posParameter);
            _dbContext.SaveChanges();
        }

        // PUT api/<PosParametersController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] PosParameter posParameter)
        {
            _dbContext.PosParameters.Update(posParameter);
            _dbContext.SaveChanges();
        }

        // DELETE api/<PosParametersController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            var item = _dbContext.PosParameters.FirstOrDefault(x => x.P1IdTerminal == id);
            if (item != null)
            {
                _dbContext.PosParameters.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
