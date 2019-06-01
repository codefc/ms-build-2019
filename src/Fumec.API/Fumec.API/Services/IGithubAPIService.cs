using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fumec.API.Services
{
    public interface IGithubAPIService
    {
        [Get("/users/{user}/repos")]
        Task<List<object>> GetRepositories(string user);
    }
}
