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
    [QueryProperty(nameof(TypeId), nameof(TypeId))]
    public partial class TypesDetailPage : ContentPage
    {
        public TypesDetailPage()
        {
            InitializeComponent();
        }
        private int typeId;
        public int TypeId
        {
            get => typeId;
            set
            {
                typeId = value;
                Type = App.Database.GetType(typeId);
                entryType.Text = Type.Name;
            }
        }

        private Types Type { get; set; }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Type.Name = entryType.Text;

            App.Database.EditTypes(Type);
            await Shell.Current.GoToAsync("//SecondPage");
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await App.Database.DeleteTypes(Type);
            await Shell.Current.GoToAsync("//SecondPage");
        }
    }
}