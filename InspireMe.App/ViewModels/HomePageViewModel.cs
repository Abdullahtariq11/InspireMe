using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InspireMe.App.Models;
using InspireMe.App.Service;

namespace InspireMe.App.ViewModels
{
    // ViewModel for the HomePage, managing quotes and interactions
    public partial class HomePageViewModel : ObservableObject
    {
        // Dependency on the QuoteService to manage quotes
        private readonly IQuoteService _quoteService;

        // The text of the current quote displayed on the home page
        [ObservableProperty]
        private string _quoteText;

        // The author of the current quote
        [ObservableProperty]
        private string _quoteAuthor;

        // Indicates whether the current quote is marked as a favorite
        [ObservableProperty]
        private bool favourite;

        // Command for generating a new random quote
        public IRelayCommand GenerateQuoteCommand { get; }

        // Constructor initializes dependencies and sets up commands
        public HomePageViewModel(IQuoteService quoteService)
        {
            _quoteService = quoteService;

            // RelayCommand is bound to the GenerateQuote method
            GenerateQuoteCommand = new RelayCommand(GenerateQuote);
        }

        // Generates a random quote and updates the observable properties
        public void GenerateQuote()
        {
            // Fetch a random quote using the QuoteService
            var quote = _quoteService.GetRandomQuote();

            // Update ViewModel properties to reflect the new quote
            QuoteText = quote.Text;
            QuoteAuthor = quote.Author;
            Favourite = quote.Favourite;
        }
    }
}