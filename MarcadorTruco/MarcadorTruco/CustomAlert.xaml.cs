// CustomAlert.xaml.cs
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace MarcadorTruco
{
    public partial class CustomAlert : ContentPage
    {
        public CustomAlert(string title, string message, string gifSource)
        {
            InitializeComponent();

            var gifImage = new Image { Source = gifSource, Aspect = Aspect.AspectFit, IsAnimationPlaying = true, HorizontalOptions = LayoutOptions.CenterAndExpand ,VerticalOptions = LayoutOptions.Center, WidthRequest = 300, HeightRequest = 300};
            var messageLabel = new Label { Text = message, HorizontalOptions = LayoutOptions.CenterAndExpand, VerticalOptions = LayoutOptions.Center, FontSize = 30, FontAttributes = FontAttributes.Bold, TextColor = Color.Black};
            var closeButton = new Button { Text = "Fechar", Command = new Command(ClosePage) };

            Content = new StackLayout
            {
                Children = { messageLabel, gifImage, closeButton },
                Padding = new Thickness(20),
                BackgroundColor = Color.White
            };

            Title = title; // Define o título da página
        }

        private void ClosePage()
        {
            Navigation.PopModalAsync();
        }
    }
}
