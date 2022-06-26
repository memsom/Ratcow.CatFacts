using System;
using System.Linq;
using System.Threading.Tasks;
using CatFacts.Models;

namespace CatFacts.Services
{
    public class CatFactsService : ICatFactsService
    {
        private readonly IJsonResolverService jsonResolver;

        public CatFactsService(IJsonResolverService jsonResolver)
        {
            this.jsonResolver = jsonResolver ?? throw new ArgumentNullException(nameof(jsonResolver));
        }

        public async Task<CatFact> GetFact()
        {
            var stringData = await jsonResolver.GetJsonResponse("https://catfact.ninja/fact");
            if (stringData.Deserialize<CatFact>() is CatFact data)
            {
                return data;
            }

            return default;
        }

        // this API seems to be broken at the moment.
        public async Task<CatImage> GetImage()
        {
            var stringData = await jsonResolver.GetJsonResponse("https://cataas.com/cat?width=100&json=true");
            if (stringData.Deserialize<CatImage>() is CatImage image)
            {
                // for caas, we need to fix up the url
                image.Url = "https://cataas.com" + image.Url;

                return image;
            }

            return default;
        }

        // this API requires a key.
        // the key below is "borrowed off the internet" from here:
        // https://github.com/CassieSloan/Random-Cat-Picture-Generator-API/blob/master/BCS_API_PROJECT.rb
        // it may stop working at some point I guess...
        public async Task<CatImage> GetAltImage()
        {
            var stringData = await jsonResolver.GetJsonResponse(
                "https://api.thecatapi.com/v1/images/search",
                "6f7aa6c9-0f1a-4afb-8412-a15036fa6f93"); 
            // this returns an array....
            if (stringData.Deserialize<CatImage[]>() is CatImage[] a && a.FirstOrDefault() is CatImage image)
            {
                return image;
            }

            return default;
        }
    }
}