using System.Threading.Tasks;

namespace CatFacts.Services
{
    public interface IJsonResolverService
    {
        Task<string> GetJsonResponse(string url, string key = null);
    }
}