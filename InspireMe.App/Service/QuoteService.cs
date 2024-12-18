using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using InspireMe.App.Models;

namespace InspireMe.App.Service;

public class QuoteService : IQuoteService
{
    private readonly List<QuoteModel> _quotes = new List<QuoteModel>(){
        new QuoteModel { Text = "The best way to predict the future is to create it.", Author = "Peter Drucker",Favourite=false },
        new QuoteModel { Text = "Life is what happens when you’re busy making other plans.", Author = "John Lennon",Favourite=false },
        new QuoteModel { Text = "Get busy living or get busy dying.", Author = "Stephen King" },
        new QuoteModel { Text = "Success is not final, failure is not fatal: It is the courage to continue that counts.", Author = "Winston Churchill",Favourite=false },
        new QuoteModel { Text = "Believe you can and you're halfway there.", Author = "Theodore Roosevelt",Favourite=false },
        new QuoteModel { Text = "Don't watch the clock; do what it does. Keep going.", Author = "Sam Levenson",Favourite=false },
        new QuoteModel { Text = "The only way to do great work is to love what you do.", Author = "Steve Jobs",Favourite=false },
        new QuoteModel { Text = "You miss 100% of the shots you don’t take.", Author = "Wayne Gretzky" },
        new QuoteModel { Text = "It does not matter how slowly you go as long as you do not stop.", Author = "Confucius",Favourite=false },
        new QuoteModel { Text = "Your time is limited, don’t waste it living someone else’s life.", Author = "Steve Jobs",Favourite=false }
    };


    // Changed to ObservableCollection for better UI updates
    public ObservableCollection<QuoteModel> Favourites { get; } = new();


    public QuoteModel GetRandomQuote()
    {
        var random = new Random();
        return _quotes[random.Next(_quotes.Count)];
    }


    public void AddToFavourite(QuoteModel quote)
    {
        if (quote == null) throw new Exception("Quote is Null");

        quote.Favourite = !quote.Favourite;
    

        if (quote.Favourite)
        {
            if (!Favourites.Contains(quote))
            {
                Favourites.Add(quote);
            }
        }
        else
        {
            Favourites.Remove(quote);

        }
    }
    public List<QuoteModel> GetAllQuotes()
    {
        return _quotes;
    }


}
