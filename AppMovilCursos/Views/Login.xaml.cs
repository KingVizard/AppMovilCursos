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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new Inicio());
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                await DisplayAlert("AVISO", "El campo de correo no puede quedar vacio", "OK");
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("AVISO", "El campo de contraseña no puede quedar vacio", "OK");
            }
            else
            {
                var validacion = App.SQLiteDB.GetUsuariosAsyncValidate(txtEmail.Text.Trim().ToString(), txtPassword.Text.ToString());
                //await DisplayAlert("AVISO", "LA CONSULTA REGRESA: "+validacion.Count(), "OK");

                if(validacion.Count() == 0)
                {
                    await DisplayAlert("Aviso", "Los datos ingresado son incorrectos", "OK");
                } 
                else if(validacion.Count() == 1)
                {
                    await Navigation.PushModalAsync(new Inicio());
                } 
                //else if(validacion.Count()>=1)
                //{
                //    await DisplayAlert("Aviso", "Ya Existe una ciien", "OK");
                //}
                //await Navigation.PushModalAsync(new Inicio());
            }
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