using InspireMe.App.Service;
using InspireMe.App.ViewModels;

namespace InspireMe.App.Pages;

public partial class FavouritePage : ContentPage
{


	public FavouritePage(FavouritePageViewModel viewModel)
	{
		InitializeComponent();
		BindingContext=viewModel;
		
	}
}