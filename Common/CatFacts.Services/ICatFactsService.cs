using System;
using System.Text.Json;
using System.Threading.Tasks;
using CatFacts.Models;

namespace CatFacts.Services
{
    public interface ICatFactsService
	{
		public Task<CatFact> GetFact();
		public Task<CatImage> GetImage();
		public Task<CatImage> GetAltImage();
	}
}