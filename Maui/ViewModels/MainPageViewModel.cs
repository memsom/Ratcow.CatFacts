using System;

namespace CatFacts.ViewModels
{
	public class MainPageViewModel: MainPageViewModelBase
	{
		public MainPageViewModel(CatFacts.Services.ICatFactsService catFactsService) : base(catFactsService)
		{
            RefreshCommand = new Command(Refresh);
        }
	}
}

