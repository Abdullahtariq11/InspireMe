using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InspireMe.App.Models;
using InspireMe.App.Service;

namespace InspireMe.App.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    private readonly IQuoteService _quoteService;

    [ObservableProperty]
    private string _quoteText;

    [ObservableProperty]
    private string _quoteAuthor;

    [ObservableProperty]
    private bool favourite;



    //commands
    public IRelayCommand GenerateQuoteCommand { get; }

    public HomePageViewModel(IQuoteService quoteService)
    {
        _quoteService = quoteService;
        GenerateQuoteCommand = new RelayCommand(GenerateQuote);
    }

    public void GenerateQuote()
    {
        var quote = _quoteService.GetRandomQuote();
        QuoteText = quote.Text;
        QuoteAuthor = quote.Author;
        Favourite = quote.Favourite;
    }

}
