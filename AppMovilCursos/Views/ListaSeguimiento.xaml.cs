using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaSeguimiento : ContentPage
    {
        public ListaSeguimiento()
        {
            InitializeComponent();
            mostrar();
        }

        public async void mostrar()
        {
            var SeguimientoList = await App.SQLiteDB.GetSeguimientoAsync();
            if (SeguimientoList != null)
            {
                lsSeguimiento.ItemsSource = SeguimientoList;
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            mostrar();
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}