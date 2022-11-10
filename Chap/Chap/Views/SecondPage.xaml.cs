using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage : ContentPage
    {
        public SecondPage()
        {
            InitializeComponent();
            OnAppearing();
        }

        protected override void OnAppearing()
        {
            collectionView.ItemsSource = App.Database.GetTypes();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
            {
                await Shell.Current.GoToAsync("//TypesDetailPage" +
                    $"?TypeId=" +
                    $"{((Types)collectionView.SelectedItem).Id}");
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AppType");
        }

    }
}