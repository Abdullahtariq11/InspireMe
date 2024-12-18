using InspireMe.App.Service;
using InspireMe.App.ViewModels;

namespace InspireMe.App.Pages;

public partial class HomePage : ContentPage
{
	private readonly IQuoteService _quoteService;
	private readonly IBackgroundService _backgroundService;
	public HomePage(HomePageViewModel viewModel, IQuoteService quoteService, IBackgroundService backgroundService)
	{

		InitializeComponent();
		BindingContext = viewModel;
		_quoteService = quoteService;
		_backgroundService = backgroundService;
	}

	private async void OnGeneratedClicked(object sender, EventArgs e)
	{
		await Navigation.PushAsync(new LoadingPage());
		await Task.Delay(3000);
		var randomQuote = _quoteService.GetRandomQuote();
		var quotePageViewModel = new QuotePageViewModel(_quoteService, _backgroundService);
		quotePageViewModel.InitializeQuote(randomQuote.Text, randomQuote.Author);
		var quotePage = new QuotePage
		{
			BindingContext = quotePageViewModel
		};
		await Navigation.PushAsync(quotePage);
		// Remove the LoadingPage from the navigation stack (optional)
		Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
	}


}