using System;
using InspireMe.App.Models;

namespace InspireMe.App.Service;

public class QuoteService:IQuoteService
{
    private readonly List<QuoteModel> _quotes = new List<QuoteModel>(){
        new QuoteModel { Text = "The best way to predict the future is to create it.", Author = "Peter Drucker" },
        new QuoteModel { Text = "Life is what happens when you’re busy making other plans.", Author = "John Lennon" },
        new QuoteModel { Text = "Get busy living or get busy dying.", Author = "Stephen King" },
        new QuoteModel { Text = "Success is not final, failure is not fatal: It is the courage to continue that counts.", Author = "Winston Churchill" },
        new QuoteModel { Text = "Believe you can and you're halfway there.", Author = "Theodore Roosevelt" },
        new QuoteModel { Text = "Don't watch the clock; do what it does. Keep going.", Author = "Sam Levenson" },
        new QuoteModel { Text = "The only way to do great work is to love what you do.", Author = "Steve Jobs" },
        new QuoteModel { Text = "You miss 100% of the shots you don’t take.", Author = "Wayne Gretzky" },
        new QuoteModel { Text = "It does not matter how slowly you go as long as you do not stop.", Author = "Confucius" },
        new QuoteModel { Text = "Your time is limited, don’t waste it living someone else’s life.", Author = "Steve Jobs" }
    };

    private readonly List<QuoteModel> _favourites=new();

    public QuoteModel GetRandomQuote()
    {
        var random=new Random();
        return _quotes[random.Next(_quotes.Count)];
    }

    public void AddToFavourite(QuoteModel quote)
    {
        if(!_favourites.Contains(quote))
        {
            _favourites.Add(quote);
        }
    }

    public List<QuoteModel> GetFavourites()=> _favourites;


}
