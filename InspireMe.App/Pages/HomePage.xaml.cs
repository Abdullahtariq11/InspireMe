// Required namespaces for services and view models
using InspireMe.App.Service;
using InspireMe.App.ViewModels;

namespace InspireMe.App.Pages
{
    // Partial class for the HomePage, responsible for displaying the home screen
    public partial class HomePage : ContentPage
    {
        // Services used for generating quotes and background images
        private readonly IQuoteService _quoteService;
        private readonly IBackgroundService _backgroundService;

        // Constructor for HomePage, injecting dependencies and setting the BindingContext
        public HomePage(HomePageViewModel viewModel, IQuoteService quoteService, IBackgroundService backgroundService)
        {
            InitializeComponent(); // Initializes components defined in the XAML file
            BindingContext = viewModel; // Sets the BindingContext to the provided ViewModel
            _quoteService = quoteService; // Assigns the injected QuoteService
            _backgroundService = backgroundService; // Assigns the injected BackgroundService
        }

        // Event handler for when the "Generate" button is clicked
        private async void OnGeneratedClicked(object sender, EventArgs e)
        {
            // Navigate to the LoadingPage while fetching a random quote
            await Navigation.PushAsync(new LoadingPage());

            // Simulate a delay to allow the animation on the LoadingPage to play
            await Task.Delay(3000);

            // Retrieve a random quote from the QuoteService
            var randomQuote = _quoteService.GetRandomQuote();

            // Create a new QuotePageViewModel and initialize it with the random quote
            var quotePageViewModel = new QuotePageViewModel(_quoteService, _backgroundService);
            quotePageViewModel.InitializeQuote(randomQuote.Text, randomQuote.Author);

            // Create a new QuotePage and set its BindingContext to the initialized ViewModel
            var quotePage = new QuotePage
            {
                BindingContext = quotePageViewModel
            };

            // Navigate to the QuotePage
            await Navigation.PushAsync(quotePage);

            // Optionally remove the LoadingPage from the navigation stack to prevent back navigation
            Navigation.RemovePage(Navigation.NavigationStack[Navigation.NavigationStack.Count - 2]);
        }
    }
}