// Required namespaces for services and view models
using InspireMe.App.Service; // Provides access to application services like QuoteService
using InspireMe.App.ViewModels; // Provides access to the FavouritePageViewModel

namespace InspireMe.App.Pages
{
    // Partial class for the FavouritePage, representing the XAML page logic
    public partial class FavouritePage : ContentPage
    {
        // Constructor for FavouritePage
        // Accepts a FavouritePageViewModel instance via dependency injection
        public FavouritePage(FavouritePageViewModel viewModel)
        {
            InitializeComponent(); // Initializes components defined in the XAML file
            BindingContext = viewModel; // Sets the data-binding context to the provided ViewModel
        }
    }
}