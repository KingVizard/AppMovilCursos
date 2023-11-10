using AppMovilCursos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

            
            Stream stream = new MemoryStream(user.imgContent);
            

            txtNombre.Text = user.Nombre;
            txtDireccion.Text = user.Direccion;
            txtTelefono.Text = user.Telefono;
            txtEdad.Text = user.Edad.ToString();
            txtCurp.Text = user.Curp;
            txtIdEmp.Text = user.IdEmp.ToString();

            if(user.imgContent == null)
            {
                ImgEmpleado.Source = ImageSource.FromFile("SinImg.png");
            } else
            {
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

        private void btnActiveEdit_Clicked(object sender, EventArgs e)
        {


            txtNombre.IsEnabled = true;
            txtDireccion.IsEnabled= true;
            txtEdad.IsEnabled= true;
            txtCurp.IsEnabled= true;
            txtTelefono.IsEnabled= true;
            UserPickerEmpleado.IsEnabled= true;
        }

        private void AddImg_Clicked(object sender, EventArgs e)
        {

        }

        private void swToggle_Toggled(object sender, ToggledEventArgs e)
        {
            if(swToggle.IsToggled)
            {
                btnEliminar.IsVisible = false;
                btnEditar.IsVisible = true;

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