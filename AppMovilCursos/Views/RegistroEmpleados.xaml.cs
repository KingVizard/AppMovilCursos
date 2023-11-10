  using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMovilCursos.Models;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using SQLite;
using Xamarin.Forms.PlatformConfiguration.TizenSpecific;

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
            var ImgByte = GetImageBytes(ValorImg.ImgStream);
            
            //if(ImgByte == null)
            //{
                
            //    ImgByte
            //}

            if (ValidarDatos())
            {
                Empleados emple = new Empleados
                {
                    Nombre = txtNombre.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim(),
                    Telefono = (txtTelefono.Text),
                    Edad = int.Parse(txtEdad.Text),
                    Curp = txtCurp.Text.Trim(),
                    TipoEmpleado = UserPickerEmpleado.Items[UserPickerEmpleado.SelectedIndex].ToString(),
                    imgContent = ImgByte
                };

                await App.SQLiteDB.SaveEmpleadoAsync(emple);

                txtNombre.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                txtEdad.Text = "";
                txtCurp.Text = "";
                UserPickerEmpleado.SelectedIndex = -1;


                await DisplayAlert("AVISO", "Se guardo de manera exitosa", "Ok");

            }
            else
            {
                await DisplayAlert("AVISO", "Ingresar los datos requeridos", "Ok");
            }
        }

        public bool ValidarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtTelefono.Text))
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
            else if (int.Parse(UserPickerEmpleado.SelectedIndex.ToString()) == -1)
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }


        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void AddImg_Clicked(object sender, EventArgs e)
        {
            try
            {
                var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    Name = "Usuario "+DateTime.Now.ToString(),
                    Directory = "FotosXamarin",
                    SaveToAlbum = true
                });

                if (foto != null)
                {
                    ImgEmpleado.Source = ImageSource.FromStream(() =>
                    {
                        ValorImg.ImgStream = foto.GetStream();
                        return foto.GetStream();
                    });
                }
            }
            catch (Exception ex) 
            {
                await DisplayAlert("Error", ex.Message.ToString(), "Ok");
            }
        }

        public class ValorImg
        {
            public static Stream ImgStream;
        }

        private byte[] GetImageBytes(Stream stream)
        {
            byte[] ImageBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                stream.CopyTo(memoryStream);
                ImageBytes = memoryStream.ToArray();
            }
            return ImageBytes;
        }

        public Stream BytesToStream(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}