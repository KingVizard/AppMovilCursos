using AppMovilCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            if (validarCamposVacios())
            {
                if (ValidarCampos())
                {
                    //await DisplayAlert("Info", "TODOS LOS CAMPOS VALIDOS", "Ok");
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

            }
            else
            {
                await DisplayAlert("AVISO", "Ingresar los datos requeridos", "Ok");
            }
        }

        public bool validarCamposVacios()
        {
            bool answer;
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                answer = false;
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                answer = false;
            }
            else if (string.IsNullOrEmpty(txtNombre.Text))
            {
                answer = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                answer = false;
            }
            else
            {
                answer = true;
            }
            return answer;
        }

        public bool ValidarCampos()
        {
            bool ans;
            //bool edad = true;
            //if (txtEmail.Text.Length < 10)
            //{
            //    DisplayAlert("Error", "Ingrese un nombre valido", "Ok");
            //    ans = false;
            //}

            //--
            bool isEmail = Regex.IsMatch(txtEmail.Text.Trim(), @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
            if (!isEmail)
            {
                this.DisplayAlert("Aviso", "El formato del correo electrónico es incorrecto, revíselo e intente de nuevo.", "OK");
                ans = false;
            }

            //else 
            //if (txtPassword.Text.Length < 5)
            //{
            //    DisplayAlert("Error", "La contraseña debe contener como minimo 5 caracteres", "Ok");
            //}


            else if (!txtNombre.Text.Replace(" ", String.Empty).ToCharArray().All(Char.IsLetter))
            {
                DisplayAlert("Aviso", "El nombre solo debe contener letras", "Ok");
                ans = false;
            }

            //if (!(txtEdad.Text.ToCharArray().All(Char.IsDigit)) && !(int.Parse(txtEdad.Text) <= 99) && !(int.Parse(txtEdad.Text) >= 18))
            //if (!txtEdad.Text.ToCharArray().All(Char.IsDigit)) //si no es numero
            //{
            //    edad = false;
            //    ans = false;
            //    DisplayAlert("ERROR", "ERROR, SOLO SE ADMITEN NUMEROS ENTEROS" + ans.ToString(), "Ok");
            //}
            //else if (edad != false) //si es numero
            //{
            //    if (int.Parse(txtEdad.Text) <= 99 && int.Parse(txtEdad.Text) >= 18)
            //    {
            //        DisplayAlert("Exito", "Edad Correcta ", "Ok");
            //        return ans = true;
            //    }
            //    else
            //    {
            //        DisplayAlert("Exito", "ERROR, EL USUARIO NO PUEDE SER MENOR DE 18 NI MAYOR DE 99", "Ok");
            //        return ans = false;
            //    }
            //}

            else if(txtPassword.Text.Length < 5)
            {
                DisplayAlert("Advertencia", "La contraseña debe contener como minimo 5 caracteres", "Ok");
                ans = false;
            }

            else if (!string.IsNullOrEmpty(txtEdad.Text)) //si contiene algo
            {
                if (txtEdad.Text.ToCharArray().All(Char.IsDigit))
                {
                    if(int.Parse(txtEdad.Text) >= 18)
                    {
                        ans = true;
                        //DisplayAlert("Exito", "Edad Correcta ", "Ok");
                    }
                    else
                    {
                        ans = false;
                        DisplayAlert("AVISO", "Solo se adminten mayores de edad", "Ok");
                    }
                }
                else
                {
                    ans = false;
                    DisplayAlert("ERROR", "Este campo solo acepta digitos", "Ok"); 
                }
            }
            else
            {
                ans = true;
            }

            return ans;
        }
        
        private async void btnIniciarSesion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
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