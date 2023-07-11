using Contenaire.Web.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Contenaire.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly ConcentrateurContext _dbContext;
        public OrganizationController(ConcentrateurContext dbContext)
        {
            _dbContext = dbContext;

        }
        // GET: api/<OrganizationController>
        [HttpGet]
        public IEnumerable<Organization> Get()
        {
            return _dbContext.Organizations;
        }

        // GET api/<OrganizationController>/5
        [HttpGet("{id}")]
        public Organization Get(String id)
        {
            return _dbContext.Organizations.SingleOrDefault(x => x.IdOrganization == id);
        }

        // POST api/<OrganizationController>
        [HttpPost]
        public void Post([FromBody] Organization organization)
        {

            _dbContext.Organizations.Add(organization);
            _dbContext.SaveChanges();

        }

        // PUT api/<OrganizationController>/5
        [HttpPut("{id}")]
        public void Put(String id, [FromBody] Organization organization)
        {
            _dbContext.Organizations.Update(organization);
            _dbContext.SaveChanges();
        }

        // DELETE api/<OrganizationController>/5
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            var item = _dbContext.Organizations.FirstOrDefault(x => x.IdOrganization == id);
            if (item != null)
            {
                _dbContext.Organizations.Remove(item);
                _dbContext.SaveChanges();
            }
        }
    }
}
