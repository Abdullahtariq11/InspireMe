using System;

namespace InspireMe.App.Service;

public class BackgroundService : IBackgroundService
{
    private static readonly Random _random = new Random();
    private static readonly IReadOnlyList<string> Backgrounds = new List<string>
    {
        "background_first.jpg",
        "background_second.jpg",
        "background_third.jpg",
        "background_fourth.jpg",
        "background_fifth.jpg",
        "background_sixth.jpg"
    };

    public string GetRandomImage()
    {
        return Backgrounds[_random.Next(Backgrounds.Count)];
    }
}
