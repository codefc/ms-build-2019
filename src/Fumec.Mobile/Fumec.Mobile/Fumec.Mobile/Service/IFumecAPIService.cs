using Fumec.Mobile.Model;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fumec.Mobile.Service
{
    public interface IFumecAPIService
    {
        [Get("api/github")]
        Task<List<Repository>> GetRepositories();
    }
}
