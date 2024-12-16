namespace InspireMe.App.Pages;

public partial class LoadingPage : ContentPage
{
	public LoadingPage()
	{
		InitializeComponent();
		 StartAnimation();
	}
	private void StartAnimation(){
		LottieAnimation.IsAnimationEnabled = true;
		LottieAnimation.RepeatCount=-1;
		
	}
}