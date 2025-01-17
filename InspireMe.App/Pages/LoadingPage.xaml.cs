// Namespace declaration for the LoadingPage class
namespace InspireMe.App.Pages
{
    // The partial class definition for the LoadingPage
    // This class is paired with the corresponding XAML file for the LoadingPage UI
    public partial class LoadingPage : ContentPage
    {
        // Constructor for the LoadingPage class
        public LoadingPage()
        {
            InitializeComponent(); // Initializes the components defined in the associated XAML file
            StartAnimation(); // Starts the animation when the page is loaded
        }

        // Method to configure and start the Lottie animation
        private void StartAnimation()
        {
            // Enables the animation for the LottieAnimation control
            LottieAnimation.IsAnimationEnabled = true;

            // Sets the animation to loop indefinitely
            LottieAnimation.RepeatCount = -1;
        }
    }
}