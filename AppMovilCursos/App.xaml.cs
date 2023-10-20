using AppMovilCursos.Data;
using AppMovilCursos.Views;
using System.IO;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilCursos
{
    public partial class App : Application
    {
        static SQLiteHelper database;
        public App()
        {
            InitializeComponent();

            //MainPage = new MainPage();
            //MainPage = new NavigationPage(new RegistroEmpleados());
            MainPage = new NavigationPage(new RegistroCursos());
        }

        public static SQLiteHelper SQLiteDB
        {
            get
            {
                if (database == null)
                {
                    database = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Empresa.db3"));
                }
                return database;
            }
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
