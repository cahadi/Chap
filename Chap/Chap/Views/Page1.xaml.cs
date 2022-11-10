using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chap.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            InitializeComponent();
            OnAppearing();
        }

        protected override void OnAppearing()
        {
            collectionView.ItemsSource = App.Database.GetItems();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AddPage");
        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (collectionView.SelectedItem != null)
            {
                await Shell.Current.GoToAsync("//ItemDetailPage" +
                    $"?ItemId=" +
                    $"{((Item)collectionView.SelectedItem).Id}");
            }
        }
    }
}