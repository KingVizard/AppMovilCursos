using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppMovilCursos.Views;

namespace AppMovilCursos
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Inicio());
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistroUsuarios());
        }

        private bool _canClose = true;

        protected override bool OnBackButtonPressed()
        {
            if (_canClose)
            {

                ShowExitDialog();
            }
            return _canClose;
        }

        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert("Salir", "¿Deseas salir de la app?", "Si", "No");

            if (answer)
            {
                _canClose = false;
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
        }
    }
}
