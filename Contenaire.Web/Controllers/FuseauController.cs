
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Concentrateur.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuseauController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public FuseauController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<FuseauController>
        [HttpGet]
        public IEnumerable<Fuseau> Get()
        {
            return _dbContext.Fuseaus;
        }

        // GET api/<FuseauController>/5
        [HttpGet("{id}")]
        public Fuseau Get(string id)
        {
            return _dbContext.Fuseaus.SingleOrDefault(x => x.Countrycode == id);
        }

        // POST api/<FuseauController>
        [HttpPost]
        public void Post([FromBody] Fuseau fuseau)
        {
            _dbContext.Fuseaus.Add(fuseau);
            _dbContext.SaveChanges();
        }

        // PUT api/<FuseauController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Fuseau fuseau)
        {
            _dbContext.Fuseaus.Update(fuseau);
            _dbContext.SaveChanges();
        }

        // DELETE api/<FuseauController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var item = _dbContext.Fuseaus.FirstOrDefault(x => x.Countrycode == id);
            if (item != null)
            {
                _dbContext.Fuseaus.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
