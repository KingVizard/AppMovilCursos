using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMovilCursos.Views;

namespace AppMovilCursos
{
    public partial class App : Application
    {
        public static MasterDetailPage MasterDet { get; set; } //menu hamburguesa
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            //MainPage = new NavigationPage(new Plantilla());
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
