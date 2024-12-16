using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InspireMe.App.Models;
using InspireMe.App.Service;

namespace InspireMe.App.ViewModels;

public partial class QuotePageViewModel : ObservableObject
{
    private readonly IBackgroundService _backgroundService;
    private readonly IQuoteService _quoteService;
    private readonly INavigation _navigation;

    public QuotePageViewModel(IQuoteService quoteService, INavigation navigation, IBackgroundService backgroundService)
    {
        _quoteService = quoteService;
        _navigation = navigation;
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

    [RelayCommand]
    private void SetAsFavorite()
    {
        _quoteService.AddToFavourite(new QuoteModel { Author = QuoteAuthor, Text = QuoteText });
        _navigation.PopAsync();
    }

    private void SelectRandomImage()
    {
        SelectedImage = _backgroundService.GetRandomImage();
    }
}