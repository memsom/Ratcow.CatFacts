using CatFacts.Views;
using CatFacts.Services;
using Unity;
using Unity.Registration;
using CatFacts.ViewModels;

namespace CatFacts;

public partial class App : Application
{
	public static readonly IUnityContainer Container = new UnityContainer();

	public App()
	{
		InitializeComponent();

		Container.RegisterType<IJsonResolverService, JsonResolverService>();
		Container.RegisterType<ICatFactsService, CatFactsService>();
		Container.RegisterType<MainPageViewModel>();
		Container.RegisterType<MainPage>();

		MainPage = Container.Resolve<MainPage>();
	}
}
