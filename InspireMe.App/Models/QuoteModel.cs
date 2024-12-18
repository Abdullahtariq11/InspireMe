using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace InspireMe.App.Models;

public partial class QuoteModel : ObservableObject
{
    [ObservableProperty]
    private string text;
    [ObservableProperty]
    public string author;
    [ObservableProperty]
    public bool favourite;
}
