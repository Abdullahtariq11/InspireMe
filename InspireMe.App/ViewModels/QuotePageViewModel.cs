using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InspireMe.App.Models;
using InspireMe.App.Service;

namespace InspireMe.App.ViewModels;

public partial class QuotePageViewModel : ObservableObject
{
    private readonly IBackgroundService _backgroundService;
    private readonly IQuoteService _quoteService;


    public QuotePageViewModel(IQuoteService quoteService, IBackgroundService backgroundService)
    {
        _quoteService = quoteService;
        _backgroundService = backgroundService;

        // Select a random image on initialization
        SelectRandomImage();
    }

    [ObservableProperty]
    private string selectedImage;

    [ObservableProperty]
    private string quoteText;

    [ObservableProperty]
    private string quoteAuthor;

    [ObservableProperty]
    private bool favourite;
    [ObservableProperty]
    private bool isFavourite;
    [ObservableProperty]
    private string favouriteButtonText;
        [ObservableProperty]
    private string favouriteButtonColor;


    [RelayCommand]
    private void SetAsFavorite()
    {
        var quote = _quoteService.GetAllQuotes()
            .FirstOrDefault(q => q.Text == QuoteText && q.Author == QuoteAuthor);

        if (quote != null)
        {
            _quoteService.AddToFavourite(quote);
            Favourite = quote.Favourite; // Update ViewModel property
            isFavourite=Favourite;
            UpdateFavouriteButtonText();
            UpdateFavouriteButtonColor();
        }
    }
    private void UpdateFavouriteButtonText()
    {
        FavouriteButtonText = IsFavourite ? "Remove From Favouite" : "Set As Favourite";
    }
        private void UpdateFavouriteButtonColor()
    {
        FavouriteButtonColor = IsFavourite ? "#005C6A" : "#E5E86C";
    }

    private void SelectRandomImage()
    {
        SelectedImage = _backgroundService.GetRandomImage();
    }
    // Initialize IsFavourite and button text when navigating to the page
    public void InitializeQuote(string text, string author)
    {
        QuoteText = text;
        QuoteAuthor = author;

        var quote = _quoteService.GetAllQuotes()
            .FirstOrDefault(q => q.Text == text && q.Author == author);

        IsFavourite = quote?.Favourite ?? false;
        UpdateFavouriteButtonText();
        UpdateFavouriteButtonColor();
    }
}