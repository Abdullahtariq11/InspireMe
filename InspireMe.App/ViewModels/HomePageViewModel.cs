using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InspireMe.App.Models;
using InspireMe.App.Service;

namespace InspireMe.App.ViewModels;

public partial class HomePageViewModel:ObservableObject
{
    private readonly IQuoteService _quoteService;

    [ObservableProperty]
    private string _quoteText;

    [ObservableProperty]
    public string _quoteAuthor;

    public ObservableCollection<QuoteModel> Favourites { get;  }=new();

    //commands
    public IRelayCommand GenerateQuoteCommand{get;}
    public IRelayCommand SaveToFavouriteCommand{get;}


    public HomePageViewModel(IQuoteService quoteService)
    {
        _quoteService= quoteService;
        GenerateQuoteCommand=new RelayCommand(GenerateQuote);
        SaveToFavouriteCommand=new RelayCommand(SaveToFavourite);

    }

    public void GenerateQuote()
    {
        var quote=_quoteService.GetRandomQuote();
        QuoteText=quote.Text;
        QuoteAuthor=quote.Author;
    }

    public void SaveToFavourite()
    {
        if(!string.IsNullOrWhiteSpace(QuoteText)&& !Favourites.Any(f=>f.Text==QuoteText)){
            Favourites.Add(new QuoteModel{Text=QuoteText,Author=QuoteAuthor});
        }
    }

}
