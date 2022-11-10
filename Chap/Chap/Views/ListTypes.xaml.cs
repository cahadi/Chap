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
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public partial class ListTypes : ContentPage
    {
        public ListTypes()
        {
            InitializeComponent();
        }

        private int id;
        public int TypeId
        {
            get => id;
            set
            {
                id = value;
                Type = App.Database.GetType(id);
            }
        }
        public int ItemId
        {
            get => id;
            set
            {
                id = value;
                Item = App.Database.GetItem(id);
            }
        }

        private Types Type { get; set; }
        private Item Item { get; set; }

        protected override void OnAppearing()
        {
            collectionView.ItemsSource = App.Database.GetTypes();
            collectionView.SelectedItem = null;
            base.OnAppearing();
        }

        private async void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var type= $"{((Types)collectionView.SelectedItem).Id}";
            TypeId = Int32.Parse(type);
            Item.TypesID = TypeId;
            App.Database.EditItem(Item);
            await Shell.Current.GoToAsync("//Page1");
            //if (collectionView.SelectedItem != null)
            //{
            //    await Shell.Current.GoToAsync("//ItemDetailPage"+
            //        $"?ItemId=" +
            //        $"{Item.Id}" +
            //        $"?TypeId=" +
            //        $"{((Types)collectionView.SelectedItem).Id}");
            //}
        }
    }
}