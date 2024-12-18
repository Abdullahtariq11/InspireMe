using System;
using System.Collections.ObjectModel;
using InspireMe.App.Models;

namespace InspireMe.App.Service;

public interface IQuoteService
{

    public ObservableCollection<QuoteModel> Favourites { get; }
    public QuoteModel GetRandomQuote();
    public void AddToFavourite(QuoteModel quote);
    public List<QuoteModel> GetAllQuotes();
 
}
