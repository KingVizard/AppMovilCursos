using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMovilCursos.Models;

namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroEmpleados : ContentPage
    {
        PickerTipoEmp pickerTipos = new PickerTipoEmp();

        public RegistroEmpleados()
        {
            InitializeComponent();
            UserPickerEmpleado.ItemsSource = pickerTipos.GetTipos();
            ImgEmpleado.Source = ImageSource.FromFile("SinImg.png");
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Empleados emple = new Empleados
                {
                    Nombre = txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = (txtTelefono.Text),
                    Edad = int.Parse(txtEdad.Text),
                    Curp = txtCurp.Text.Trim(),
                    TipoEmpleado = UserPickerEmpleado.Items[UserPickerEmpleado.SelectedIndex].ToString()
                //TipoEmpleado = txtTipoEmpleado.Text.Trim(),
            };

                await App.SQLiteDB.SaveEmpleadoAsync(emple);

                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEdad.Text = "";
                txtCurp.Text = "";
                //txtTipoEmpleado.Text = "";

                await DisplayAlert("AVISO", "Se guardo de manera exitosa", "Ok");

            } else
            {
                await DisplayAlert("AVISO", "Ingresar los datos requeridos", "Ok");
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDireccion.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtEdad.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCurp.Text))
            {
                respuesta = false;
            }
            //else if (string.IsNullOrEmpty(txtTipoEmpleado.Text))
            //{
            //    respuesta = false;
            //}
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnListaEmpleados_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaEmpleados());
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private void UserPickerEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void AddImg_Clicked(object sender, EventArgs e)
        {
            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions());

            if(foto != null)
            {
                ImgEmpleado.Source = ImageSource.FromStream(() =>
                {
                    return foto.GetStream();
                });
            }
        }
    }
}