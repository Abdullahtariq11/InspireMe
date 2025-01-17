using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using InspireMe.App.Models;

namespace InspireMe.App.Service
{
    // The QuoteService class manages quotes and their favorite status.
    public class QuoteService : IQuoteService
    {
        // A list of all available quotes (initial dataset).
        private readonly List<QuoteModel> _quotes = new List<QuoteModel>()
        {
            new QuoteModel { Text = "The best way to predict the future is to create it.", Author = "Peter Drucker", Favourite = false },
            new QuoteModel { Text = "Life is what happens when you’re busy making other plans.", Author = "John Lennon", Favourite = false },
            new QuoteModel { Text = "Get busy living or get busy dying.", Author = "Stephen King" },
            new QuoteModel { Text = "Success is not final, failure is not fatal: It is the courage to continue that counts.", Author = "Winston Churchill", Favourite = false },
            new QuoteModel { Text = "Believe you can and you're halfway there.", Author = "Theodore Roosevelt", Favourite = false },
            new QuoteModel { Text = "Don't watch the clock; do what it does. Keep going.", Author = "Sam Levenson", Favourite = false },
            new QuoteModel { Text = "The only way to do great work is to love what you do.", Author = "Steve Jobs", Favourite = false },
            new QuoteModel { Text = "You miss 100% of the shots you don’t take.", Author = "Wayne Gretzky" },
            new QuoteModel { Text = "It does not matter how slowly you go as long as you do not stop.", Author = "Confucius", Favourite = false },
            new QuoteModel { Text = "Your time is limited, don’t waste it living someone else’s life.", Author = "Steve Jobs", Favourite = false }
        };

        // An observable collection of favorite quotes to update UI dynamically.
        public ObservableCollection<QuoteModel> Favourites { get; } = new();

        // Event triggered when the Favourites collection changes.
        public event Action OnFavouritesChanged;

        // Retrieves a random quote from the list of all quotes.
        public QuoteModel GetRandomQuote()
        {
            var random = new Random();
            return _quotes[random.Next(_quotes.Count)];
        }

        // Adds or removes a quote from favorites by toggling its Favorite status.
        public void AddToFavourite(QuoteModel quote)
        {
            if (quote == null) throw new Exception("Quote is Null");

            // Toggle the favorite status
            quote.Favourite = !quote.Favourite;

            if (quote.Favourite)
            {
                // Add to favorites if not already in the collection
                if (!Favourites.Contains(quote))
                {
                    Favourites.Add(quote);
                }
            }
            else
            {
                // Remove from favorites if it is in the collection
                Favourites.Remove(quote);
            }

            // Notify listeners about the change
            OnFavouritesChanged?.Invoke();
        }

        // Returns all quotes from the predefined list.
        public List<QuoteModel> GetAllQuotes()
        {
            return _quotes;
        }

        // Removes a quote from favorites and updates its Favorite status to false.
        public void RemoveFavourite(QuoteModel quote)
        {
            if (Favourites.Contains(quote))
            {
                // Remove the quote from the favorites collection
                Favourites.Remove(quote);

                // Set its favorite status to false
                quote.Favourite = false;

                // Notify listeners about the change
                OnFavouritesChanged?.Invoke();
            }
        }
    }
}