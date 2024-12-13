using System;
using InspireMe.App.Models;

namespace InspireMe.App.Service;

public interface IQuoteService
{
    public QuoteModel GetRandomQuote();
}
