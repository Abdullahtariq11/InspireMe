using InspireMe.App.ViewModels;

namespace InspireMe.App.Pages;

public partial class HomePage : ContentPage
{

	public HomePage(HomePageViewModel viewModel)
	{
		
		InitializeComponent();
		BindingContext=viewModel;
	}
}