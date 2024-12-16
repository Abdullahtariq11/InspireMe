using System;
using InspireMe.App.Models;

namespace InspireMe.App.Service;

public interface IQuoteService
{
    public QuoteModel GetRandomQuote();
    public void AddToFavourite(QuoteModel quote);
     public List<QuoteModel> GetFavourites();
}
