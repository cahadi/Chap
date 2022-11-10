using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Chap.Views
{
    
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    [QueryProperty(nameof(TypeId), nameof(TypeId))]
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent(); 
        }
        private Item Item { get; set; }
        private Types Type { get; set; }

        private int id;
        public int ItemId
        {
            get => id;
            set
            {
                id = value;
                Item = App.Database.GetItem(id);
                entryName.Text = Item.Name;
                entryType.Text = Item.TypesID.ToString();
            }
        }

        public int TypeId
        {
            get => id;
            set
            {
                id = value;
                Type = App.Database.GetType(id);
                entryType.Text = Type.Name;
            }
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Item.Name = entryName.Text;
            App.Database.EditItem(Item);
            await Shell.Current.GoToAsync("//Page1");
        }


        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await App.Database.DeleteItem(Item);
            await Shell.Current.GoToAsync("//Page1");
        }

        private async void Button_Clicked_2(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ListTypes" +
                    $"?ItemId=" +
                    $"{id}");
        }
    }
}