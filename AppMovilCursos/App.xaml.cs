using AppMovilCursos.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilCursos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new MainPage());
            //MainPage = new NavigationPage(new Ayuda());
            //INICIO, PERFIL, CERRAR SESION, PERFIL, CONFIGURACIÓN
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
