using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using InspireMe.App.Models;
using InspireMe.App.Service;

namespace InspireMe.App.ViewModels;

public partial class FavouritePageViewModel : ObservableObject
{
    private readonly IQuoteService _quoteService;
    public ObservableCollection<QuoteModel> Favourites { get; }
    

    public FavouritePageViewModel(IQuoteService quoteService)
    {
        _quoteService = quoteService;
        Favourites = quoteService.Favourites;
    }

}
