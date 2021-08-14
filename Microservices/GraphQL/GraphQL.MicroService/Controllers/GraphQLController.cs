using System.Threading.Tasks;
using GraphQL.Core.Models;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;

namespace GraphQL.MicroService.Controllers
{
    [ApiController]
    [Route("/api/graphQl")]
    public class GraphQLController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _executor;
        public GraphQLController(ISchema schema, IDocumentExecuter executor)
        {
            _schema = schema;
            _executor = executor;
        }

        [HttpPost]
        [Route("graph")]
        public async Task<IActionResult> Post([FromBody] GraphQLQueryBody query)
        {
            var result = await _executor.ExecuteAsync(_ =>
            {
                _.Schema = _schema;
                _.Query = query.Query;
                _.Inputs = query.Variables;
            });

            if (result.Errors?.Count > 0)
            {
                return BadRequest();
            }

            return Ok(result.Data);
        }
    }
}
