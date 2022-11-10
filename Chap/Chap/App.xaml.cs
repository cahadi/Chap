using System;
using System.IO;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Chap
{
    public partial class App : Application
    {
        public static Database database;
        public static Database Database
        {
            get
            {
                if (database == null)
                {
                    database = new Database();
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
