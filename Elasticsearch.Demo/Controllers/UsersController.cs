using Microsoft.AspNetCore.Mvc;
using Nest;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Elasticsearch.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IElasticClient elasticClient;

        public UsersController(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(string id)
        {
            /*var response = await elasticClient.SearchAsync<User>(s => s
                .Index("users")
                .Query(q => q.Match(m => m.Field(f => f.Name).Query(id))));*/

            var response = await elasticClient.GetAsync<User>(new DocumentPath<User>(
                new Id(id)), x => x.Index("users"));

            return response?.Source;
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task<string> Post([FromBody] User value)
        {
            var response = await elasticClient.IndexAsync<User>(value, x => x.Index("users"));
            return response.Id;
        }
    }
}
