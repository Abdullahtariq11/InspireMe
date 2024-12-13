using InspireMe.App.Service;
using InspireMe.App.ViewModels;

namespace InspireMe.App.Pages;

public partial class HomePage : ContentPage
{
	private readonly IQuoteService _quoteService;
	public HomePage(HomePageViewModel viewModel,IQuoteService quoteService)
	{
		
		InitializeComponent();
		BindingContext=viewModel;
		_quoteService=quoteService;
	}

    private async void OnGeneratedClicked(object sender, EventArgs e)
    {
		var randomQuote=_quoteService.GetRandomQuote();
		var quotePage=new QuotePage
		{

		};
		await Navigation.PushAsync(quotePage);
    }


}