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
using static AppMovilCursos.Views.Perfil;

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
            ImgEmpleado.Padding = 100;
            ImgEmpleado.Source = ImageSource.FromFile("SinImg.png");

            //Valores Para pruebas
            //txtNombre.Text = "Jose Perez";
            //txtDireccion.Text = "Cañon Ballesteros #113";
            //txtTelefono.Text = "8131723963";
            //txtEdad.Text = "18";

            //string imagePath = ImageSource.FromFile("SinImg.png").ToString();

            //DisplayAlert("AViso", imagePath, "OK");

            btnVolver.BackgroundColor = Color.FromRgba(0, 0, 255, 0.1);

            /////
            
        string filePath = "C:\\Users\\pablo\\source\\repos\\AppMovilCursos\\AppMovilCursos.Android\\Resources\\drawable\\IconBackW.png"; // Reemplaza con la ruta de tu archivo de imagen


            // Convierte la imagen a un stream
            GetStreamFromFile(filePath);

        // Asigna el stream a la fuente de la imagen en tu aplicación Xamarin.Forms
        //Image image = new Image();
        //image.Source = ImageSource.FromStream(() => imageStream);
            ///


        }
        //


// Método para obtener el stream desde el archivo
public Stream GetStreamFromFile(string filePath)
        {
            // Verifica si el archivo existe
            if (File.Exists(filePath))
            {
                // Lee el archivo como un arreglo de bytes
                byte[] fileBytes = File.ReadAllBytes(filePath);

                // Crea un MemoryStream a partir del arreglo de bytes
                MemoryStream stream = new MemoryStream(fileBytes);

                // Devuelve el MemoryStream
                return stream;
            }
            else
            {
                // Manejo de error: el archivo no existe
                DisplayAlert("Alerta", "No existe", "OK");

                return null;
            }
        }

        //

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            ////if(ValorImg.ImgStream != Stream.Null)
            ////{
            ////    ImgByte.Img = GetImageBytes(ValorImg.ImgStream);
            ////} 
            //    string filePath = "edit.png";

            //    ImageSource imageSource = ImageSource.FromFile(filePath);

            //ImgEmpleado.Source = ImageSource.FromFile("edit.png");

            ////if(File.Exists(imageSource.ToString()))
            //if(File.Exists(filePath))
            //    {

            //await DisplayAlert("AViso", "si EXISTEEEE: "+imageSource, "OK");


            //string imagePath = ImageSource.FromFile("SinImg.png").ToString();
            //////using (var stream = File.Open(imagePath, FileMode.Open, FileAccess.Read));

            //var a = (File.Open(ImgEmpleado.Source.ToString(), FileMode.Open, FileAccess.Read));

            //var s = GetImageBytes(a);

            ////byte[] imageBytes = File.ReadAllBytes();
            //ImgByte.Img = s;


            //}
            //else
            //{
            //    await DisplayAlert("AViso", "NOOO EXISTE", "OK");

            //}

            if (ValidarCamposVacios())
            {
                if (ValidarCampos())
                {
                    Empleados emple = new Empleados
                    {
                        Nombre = txtNombre.Text.Trim(),
                        Direccion = txtDireccion.Text.Trim(),
                        Telefono = (txtTelefono.Text),
                        Edad = int.Parse(txtEdad.Text),
                        Curp = txtCurp.Text.Trim(),
                        TipoEmpleado = UserPickerEmpleado.Items[UserPickerEmpleado.SelectedIndex].ToString(),
                        imgContent = ImgByte.Img
                    };

                    await App.SQLiteDB.SaveEmpleadoAsync(emple);

            txtNombre.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtEdad.Text = "";
            txtCurp.Text = "";
            UserPickerEmpleado.SelectedIndex = -1;
            ImgEmpleado.Padding = 20;
            ImgEmpleado.Source = ImageSource.FromFile("SinImg.png");


            await DisplayAlert("AVISO", "Se guardo de manera exitosa", "Ok");
        }

    }
                    else
                    {
                        await DisplayAlert("AVISO", "Ingresar los datos requeridos", "Ok");
}

                }

        public bool ValidarCamposVacios()
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

        public bool ValidarCampos()
        {
            bool ans;

            if (!txtNombre.Text.Replace(" ", String.Empty).ToCharArray().All(Char.IsLetter))
            {
                DisplayAlert("Aviso", "El nombre solo debe contener letras", "Ok");
                txtNombre.Focus();
                ans = false;
            }
            else if (txtDireccion.Text.Length < 10)
            {
                DisplayAlert("Aviso", "Ingrese un domicilio correcto", "Ok");
                txtDireccion.Focus();
                ans = false;
            }
            else if (txtCurp.Text.Length < 18)
            {
                DisplayAlert("Aviso", "Ingrese un curp valido", "Ok");
                txtCurp.Focus();
                ans = false;
            }
            else if(txtTelefono.Text.Length != 10)
            {
                DisplayAlert("Aviso", "Favor de ingresar un numero de telefono de 10 digitos", "Ok");
                txtTelefono.Focus();
                ans = false;
            }
            else if (!string.IsNullOrEmpty(txtEdad.Text)) //si contiene algo
            {
                if (txtEdad.Text.ToCharArray().All(Char.IsDigit))
                {
                    if (int.Parse(txtEdad.Text) >= 18)
                    {
                        ans = true;
                        //DisplayAlert("Exito", "Edad Correcta ", "Ok");
                    }
                    else
                    {
                        ans = false;
                        DisplayAlert("AVISO", "Solo se admiten mayores de edad", "Ok");
                        txtEdad.Focus();
                    }
                }
                else
                {
                    ans = false;
                    DisplayAlert("ERROR", "Este campo solo acepta digitos", "Ok");
                    txtEdad.Focus();
                }
            }
            else
            {
                ans = true;
            }

            return ans;
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            btnVolver.IsEnabled = false;
            await Navigation.PopModalAsync();
            btnVolver.IsEnabled = true;
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
                        ImgEmpleado.Padding = 0;
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
            public static Stream ImgStream = Stream.Null;
        }

        public class ImgByte
        {
            public static Byte[] Img = null;
        }

        //public byte[] ConverirImgSourceBytes(string filePath)
        //{
        //    // Cargar la imagen como ImageSource desde el archivo
        //    ImageSource imageSource = ImageSource.FromFile(filePath);

        //    // Convertir ImageSource a bytes
        //    byte[] imageBytes = ConvertirImageSourceABytes(imageSource);


        //    return imageBytes;
        //}

        //public byte[] ConvertirImageSourceABytes(ImageSource imageSource)
        //{
        //    // Convertir ImageSource a Stream
        //    StreamImageSource streamImageSource = (StreamImageSource)imageSource;
        //    Stream stream = (Stream)streamImageSource.Stream.Invoke(new object[] { });

        //    // Leer los bytes desde el Stream
        //    using (MemoryStream memoryStream = new MemoryStream())
        //    {
        //        stream.CopyTo(memoryStream);
        //        return memoryStream.ToArray();
        //    }
        //}

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