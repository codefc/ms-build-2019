using Fumec.API.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Fumec.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly IGithubAPIService _service;

        public GithubController(IGithubAPIService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<object>> Get()
        {
            return await _service.GetRepositories("SEU_USUARIO");
        }
    }
}