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
    public partial class AppType : ContentPage
    {
        public AppType()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Types type = new Types()
            {
                Name = entryType.Text
            };
            await App.Database.AddType(type);
            await Shell.Current.GoToAsync("//SecondPage");
        }
    }
}