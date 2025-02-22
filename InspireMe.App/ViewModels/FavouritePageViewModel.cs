using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InspireMe.App.Models;
using InspireMe.App.Service;

namespace InspireMe.App.ViewModels
{
    // ViewModel for the FavouritePage, responsible for managing favorite quotes
    public partial class FavouritePageViewModel : ObservableObject
    {
        // Dependency on the QuoteService for managing favorite quotes
        private readonly IQuoteService _quoteService;
        //Dependency on the Navigation
        private readonly INavigation _navigation;

        // Observable collection to hold the list of favorite quotes, bound to the UI
        public ObservableCollection<QuoteModel> Favourites { get; }

        // Command for removing a quote from favorites
        public IRelayCommand<QuoteModel> RemoveFavouriteCommand { get; }
        public IRelayCommand NavigateToHomePageCommand { get; }

        // Constructor initializes the ViewModel with the QuoteService and sets up the command
        public FavouritePageViewModel(IQuoteService quoteService, INavigation navigation)
        {
            _quoteService = quoteService;
            _navigation = navigation;

            // Initialize the collection of favorite quotes from the QuoteService
            Favourites = quoteService.Favourites;

            // Initialize the RemoveFavouriteCommand with the method to remove quotes
            RemoveFavouriteCommand = new RelayCommand<QuoteModel>(RemoveFavourite);
            NavigateToHomePageCommand = new RelayCommand(NavigateToHomePage);
        }
        private async void NavigateToHomePage()
        {
            try
            {
                // Use the route defined in AppShell.xaml
                await Shell.Current.GoToAsync("//HomePage");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Navigation Error: {ex.Message}");
            }
        }
        // Method to remove a favorite quote from the collection
        private void RemoveFavourite(QuoteModel quoteModel)
        {
            // Ensure the quote is not null before attempting to remove it
            if (quoteModel == null) return;

            // Delegate the removal process to the QuoteService
            _quoteService.RemoveFavourite(quoteModel);
        }
    }
}