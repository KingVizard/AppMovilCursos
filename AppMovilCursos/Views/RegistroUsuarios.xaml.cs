using AppMovilCursos.Models;
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
	public partial class RegistroUsuarios : ContentPage
	{
		public RegistroUsuarios ()
		{
			InitializeComponent ();
		}

        private async void btnRegistrarUsuario_Clicked(object sender, EventArgs e)
        {
            if(validarCampos())
            {
                Usuarios registrar = new Usuarios
                {
                    Email = txtEmail.Text,
                    Clave = txtPassword.Text,
                    Nombre = txtNombre.Text,
                    Edad = int.Parse(txtEdad.Text),
                };

                await App.SQLiteDB.SaveUsuario(registrar);
                await DisplayAlert("AVISO", "Registro guardado de forma exitosa", "Ok");
                await Navigation.PushModalAsync(new Login());

            }
            else
            {
                await DisplayAlert("AVISO", "Ingresar los datos requeridos", "Ok");
            }
        }

        public bool validarCampos()
        {
            bool answer;
            if(string.IsNullOrEmpty(txtEmail.Text)) 
            {
                answer = false;
            } 
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                answer= false;
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                answer = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                answer = false;
            } else
            {
                answer = true;
            }
            return answer;
        }

        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Login());
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