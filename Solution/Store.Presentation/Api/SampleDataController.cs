using Microsoft.AspNetCore.Mvc;
using Store.DataAccess.Entities;
using Store.DataAccess.Initialization;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.Presentation.Api
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        DataBaseContext Context = null;

        public SampleDataController(DataBaseContext context)
        {
            Context = context;
        }

        // GET: api/values
        [HttpGet]
        public User Get()
        {
            return Context.Users.LastOrDefault();
        }


        // POST api/values
        [HttpPost]
        public User Post([FromBody]User value)
        {
            //value.Id = 0;
            var newData = Context.Add(value);
            Context.SaveChanges();

            return newData.Entity as User;
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}