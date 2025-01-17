using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InspireMe.App.Models;
using InspireMe.App.Service;

namespace InspireMe.App.ViewModels
{
    // The view model for the QuotePage, managing state and business logic.
    public partial class QuotePageViewModel : ObservableObject
    {
        // Dependencies for managing quotes and background images
        private readonly IBackgroundService _backgroundService;
        private readonly IQuoteService _quoteService;

        // Constructor
        public QuotePageViewModel(IQuoteService quoteService, IBackgroundService backgroundService)
        {
            _quoteService = quoteService;
            _backgroundService = backgroundService;

            // Subscribe to changes in the favorites list
            _quoteService.OnFavouritesChanged += HandleFavouritesChanged;

            // Select a random background image on initialization
            SelectRandomImage();
        }

        // Destructor to unsubscribe from events to avoid memory leaks
        ~QuotePageViewModel()
        {
            _quoteService.OnFavouritesChanged -= HandleFavouritesChanged;
        }

        // The currently selected background image
        [ObservableProperty]
        private string selectedImage;

        // The text of the displayed quote
        [ObservableProperty]
        private string quoteText;

        // The author of the displayed quote
        [ObservableProperty]
        private string quoteAuthor;

        // Tracks whether the current quote is marked as a favorite
        [ObservableProperty]
        private bool favourite;

        // Tracks whether the current quote is a favorite and updates the UI
        [ObservableProperty]
        private bool isFavourite;

        // The text displayed on the favorite button
        [ObservableProperty]
        private string favouriteButtonText;

        // The background color of the favorite button
        [ObservableProperty]
        private string favouriteButtonColor;

        // Command to toggle the favorite status of the current quote
        [RelayCommand]
        private void SetAsFavorite()
        {
            // Find the current quote in the list of all quotes
            var quote = _quoteService.GetAllQuotes()
                .FirstOrDefault(q => q.Text == QuoteText && q.Author == QuoteAuthor);

            if (quote != null)
            {
                // Add or remove the quote from favorites
                _quoteService.AddToFavourite(quote);

                // Update the IsFavourite property to trigger UI updates
                IsFavourite = quote.Favourite;
                UpdateFavouriteButtonText();
                UpdateFavouriteButtonColor();
            }
        }

        // Updates the favorite button text based on the IsFavourite state
        private void UpdateFavouriteButtonText()
        {
            FavouriteButtonText = IsFavourite ? "Remove From Favouite" : "Set As Favourite";
        }

        // Updates the favorite button color based on the IsFavourite state
        private void UpdateFavouriteButtonColor()
        {
            FavouriteButtonColor = IsFavourite ? "#005C6A" : "#E5E86C";
        }

        // Selects a random background image
        private void SelectRandomImage()
        {
            SelectedImage = _backgroundService.GetRandomImage();
        }

        // Initializes the view model with the given quote and author
        public void InitializeQuote(string text, string author)
        {
            QuoteText = text;
            QuoteAuthor = author;

            // Check if the quote is a favorite and update the UI
            var quote = _quoteService.GetAllQuotes()
                .FirstOrDefault(q => q.Text == text && q.Author == author);

            IsFavourite = quote?.Favourite ?? false;
            UpdateFavouriteButtonText();
            UpdateFavouriteButtonColor();
        }

        // Handles updates to the favorites list and refreshes the current quote's state
        private void HandleFavouritesChanged()
        {
            // Find the current quote in the updated favorites list
            var quote = _quoteService.GetAllQuotes()
                .FirstOrDefault(q => q.Text == QuoteText && q.Author == QuoteAuthor);

            if (quote != null)
            {
                // Update IsFavourite and refresh the UI
                IsFavourite = quote.Favourite;
                UpdateFavouriteButtonText();
                UpdateFavouriteButtonColor();
            }
            else
            {
                // If the quote was removed from favorites, ensure IsFavourite is false
                IsFavourite = false;
                UpdateFavouriteButtonText();
                UpdateFavouriteButtonColor();
            }
        }
    }
}