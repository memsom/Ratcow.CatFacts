namespace CatFacts.Views;

public partial class MainPage : ContentPage
{
	public MainPage(ViewModels.MainPageViewModel vm)
	{
        if (vm is null)
        {
            throw new ArgumentNullException(nameof(vm));
        }

        InitializeComponent();

        BindingContext = vm;
	}
}