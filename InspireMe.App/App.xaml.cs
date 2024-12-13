using InspireMe.App.Pages;

namespace InspireMe.App;

public partial class App : Application
{
	public App(AppShell appShell)
	{
		InitializeComponent();

		MainPage = appShell;
	}
}
