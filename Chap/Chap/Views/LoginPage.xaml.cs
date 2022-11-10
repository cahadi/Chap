using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (entryLogin.Text == "l" && entryPassword.Text == "d")
            {
                await Shell.Current.GoToAsync("//SecondPage");
            }
            else
            {
                await DisplayAlert("Error", "Error!", "OK");
            }
        }
    }
}