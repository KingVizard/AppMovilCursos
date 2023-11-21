using AppMovilCursos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AppMovilCursos.Views.RegistroEmpleados;

namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarEmpleado : ContentPage
    {
        
        PickerTipoEmp pickerTipos = new PickerTipoEmp();

        ValidarCambios Datos = new ValidarCambios();

        public EditarEmpleado(Empleados user)
        {
            InitializeComponent();

            txtNombre.Text = user.Nombre;
            txtDireccion.Text = user.Direccion;
            txtTelefono.Text = user.Telefono;
            txtEdad.Text = user.Edad.ToString();
            txtCurp.Text = user.Curp;
            txtIdEmp.Text = user.IdEmp.ToString();

            if(user.imgContent == null)
            {
                ImgEmpleado.Padding = 20;
                ImgEmpleado.Source = ImageSource.FromFile("SinImg.png");
            } else
            {
                Stream stream = new MemoryStream(user.imgContent);
                ImgEmpleado.Padding = 0;
                ImgEmpleado.Source = ImageSource.FromStream(() => stream);
            }

            //VALOR PICKER
            UserPickerEmpleado.ItemsSource = pickerTipos.GetTipos();

            int match_Tipo = pickerTipos.GetTipos().First(x => x.Tipo == user.TipoEmpleado).Id;
            UserPickerEmpleado.SelectedIndex = match_Tipo - 1;

            //VALORES PICKER
            Tipos_Selected.Tipo_Selected = user.Nombre.ToString();

            //VALORES PARA COMPRARACION DE CAMBIOS
            Datos.Nombre = user.Nombre.ToString();
            Datos.Direccion = user.Direccion.ToString();
            Datos.Edad = user.Edad.ToString();
            Datos.Curp = user.Curp.ToString();
            Datos.Telefono = user.Telefono.ToString();
            Datos.ImgContentByte = user.imgContent;
        }


        public bool ValidarDatosMod()
        {

            bool respuesta;
            if (txtNombre.Text != Datos.Nombre)
            {
                respuesta = false;
            }
            else if (txtTelefono.Text != Datos.Telefono)
            {
                respuesta = false;
            }
            else if (txtDireccion.Text != Datos.Direccion)
            {
                respuesta = false;
            }
            else if (txtEdad.Text != Datos.Edad)
            {
                respuesta = false;
            }
            else if (txtCurp.Text != Datos.Curp)
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
            else if (txtTelefono.Text.Length != 10)
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
            if (ValidarDatosMod() == false)
            {
                var answer = await DisplayAlert("AVISO", "¿Desea salir sin guardar?, se perderán los cambios realizados.", "Si", "No");
                if(answer)
                {
                    await Navigation.PopModalAsync();
                }
            } else
            {
                await Navigation.PopModalAsync();
            }
        }

        public class ValidarCambios
        {
            public string Nombre { get; set; }
            public string Telefono { get; set; }
            public string Direccion { get; set; }
            public string Edad { get; set; }
            public string Curp { get; set; }
            public byte[] ImgContentByte { get; set; }
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdEmp.Text))
            {
                //Get Person  
                var emple = await App.SQLiteDB.GetEmpleadoIdAsync(Convert.ToInt32(txtIdEmp.Text));
                if (emple != null)
                {
                    var answer = await DisplayAlert("Aviso", "¿Esta seguro de eliminar el registro?", "Si", "No");
                    if (answer)
                    {
                        await App.SQLiteDB.DeleteEmpleadoAsync(emple);
                        await DisplayAlert("Aviso", "Empleado eliminado correctamente", "OK");
                        await Navigation.PopModalAsync();
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "No fue posible eliminar al empleado", "OK");
            }
        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            if (ValorImg.ImgStream != Stream.Null)
            {
                ImgByte.Img = GetImageBytes(ValorImg.ImgStream);
            }

            if (validarDatos())
            {
                var answer = await DisplayAlert("Aviso", "¿Esta seguro de modificar el registro?", "Si", "No");
                if (answer)
                {
                    Empleados emple = new Empleados()
                    {
                        IdEmp = Convert.ToInt32(txtIdEmp.Text),
                        Nombre = txtNombre.Text,

                        Direccion = txtDireccion.Text,
                        Telefono = txtTelefono.Text,
                        Edad = int.Parse(txtEdad.Text),
                        Curp = txtCurp.Text,
                        TipoEmpleado = UserPickerEmpleado.Items[UserPickerEmpleado.SelectedIndex].ToString(),
                        imgContent = ImgByte.Img
                    };

                    //Update Person  
                    await App.SQLiteDB.SaveEmpleadoAsync(emple);


                    await DisplayAlert("Exito", "Los cambios se ralizaron correctamente", "OK");
                    await Navigation.PopModalAsync();
                }
            }
            else
            {
                await DisplayAlert("Required", "Please Enter PersonID", "OK");
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

        public static class Tipos_Selected
        {
            public static string Tipo_Selected = "";
        }

        private void UserPickerEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserPickerEmpleado.SelectedIndex != -1)
            {
                string Tipo = UserPickerEmpleado.Items[UserPickerEmpleado.SelectedIndex].ToString();
                Tipos_Selected.Tipo_Selected = Tipo;
            }
        }

        //private void btnActiveEdit_Clicked(object sender, EventArgs e)
        //{
        //    txtNombre.IsEnabled = true;
        //    txtDireccion.IsEnabled = true;
        //    txtEdad.IsEnabled = true;
        //    txtCurp.IsEnabled = true;
        //    txtTelefono.IsEnabled = true;
        //    UserPickerEmpleado.IsEnabled = true;
        //}

        private async void AddImg_Clicked(object sender, EventArgs e)
        {
            try
            {
                var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
                {
                    Name = "Usuario " + DateTime.Now.ToString(),
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

        private void swToggle_Toggled(object sender, ToggledEventArgs e)
        {
            if(swToggle.IsToggled)
            {
                btnEliminar.IsVisible = false;
                btnEditar.IsVisible = true;

                ImgEmpleado.IsEnabled= true;
                AddImg.IsEnabled = true;
                txtNombre.IsEnabled = true;
                txtDireccion.IsEnabled = true;
                txtEdad.IsEnabled = true;
                txtCurp.IsEnabled = true;
                txtTelefono.IsEnabled = true;
                UserPickerEmpleado.IsEnabled = true;
            }
            else
            {
                btnEliminar.IsVisible = true;
                btnEditar.IsVisible = false;

                ImgEmpleado.IsEnabled = false;
                AddImg.IsEnabled = false;
                txtNombre.IsEnabled = false;
                txtDireccion.IsEnabled = false;
                txtEdad.IsEnabled = false;
                txtCurp.IsEnabled = false;
                txtTelefono.IsEnabled = false;
                UserPickerEmpleado.IsEnabled = false;
            }
        }
    }
}