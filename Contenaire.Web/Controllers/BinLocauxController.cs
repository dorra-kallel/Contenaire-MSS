
using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JwtApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BinLocauxController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public BinLocauxController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<UseController>
        [HttpGet]
        public IEnumerable<BinLocaux> Get()
        {
            return _dbContext.BinLocauxes;
        }

        // GET api/<UseController>/5
        [HttpGet("{id}")]
        public BinLocaux Get(int id)
        {
            return _dbContext.BinLocauxes.SingleOrDefault(x => x.IdBinLocaux == id);
        }

        // POST api/<UseController>
        [HttpPost]
        public void Post([FromBody] BinLocaux binLocaux)
        {
            _dbContext.BinLocauxes.Add(binLocaux);
            _dbContext.SaveChanges();

        }

        // PUT api/<UseController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] BinLocaux binLocaux)
        {
            _dbContext.BinLocauxes.Update(binLocaux);
            _dbContext.SaveChanges();
        }

        // DELETE api/<UseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _dbContext.BinLocauxes.FirstOrDefault(x => x.IdBinLocaux == id);
            if (item != null)
            {
                _dbContext.BinLocauxes.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
