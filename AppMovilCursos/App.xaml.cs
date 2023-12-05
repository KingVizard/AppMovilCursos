using AppMovilCursos.Data;
using AppMovilCursos.Views;
using System.IO;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMovilCursos.Models;
using System.Threading.Tasks;

namespace AppMovilCursos
{
    public partial class App : Application
    {
        static SQLiteHelper database;
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Inicio());


            //ConsultaDatos();
        }


        public async void ConsultaDatos()
        {
            var user = await App.SQLiteDB.GetEmpleadoIdAsync(5);


            MainPage = new NavigationPage(new EditarEmpleado(user));
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
