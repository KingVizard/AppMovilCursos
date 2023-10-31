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
    public partial class EditarEmpleado : ContentPage
    {
        
        PickerTipoEmp pickerTipos = new PickerTipoEmp();

        public EditarEmpleado(Empleados user)
        {
            InitializeComponent();

            txtNombre.Text = user.Nombre;
            txtDireccion.Text = user.Direccion;
            txtTelefono.Text = user.Telefono;
            txtEdad.Text = user.Edad.ToString();
            txtCurp.Text = user.Curp;
            txtTipoEmpleado.Text = user.TipoEmpleado;
            txtIdEmp.Text = user.IdEmp.ToString();

            UserPickerEmpleado.ItemsSource = pickerTipos.GetTipos();
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdEmp.Text))
            {
                //Get Person  
                var emple = await App.SQLiteDB.GetEmpleadoIdAsync(Convert.ToInt32(txtIdEmp.Text));
                if (emple != null)
                {
                    //Delete Person  
                    await App.SQLiteDB.DeleteEmpleadoAsync(emple);

                    await DisplayAlert("Aviso", "Empleado eliminado correctamente", "OK");
                    await Navigation.PopModalAsync();

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
                Empleados emple = new Empleados()
                {
                    IdEmp = Convert.ToInt32(txtIdEmp.Text),
                    Nombre = txtNombre.Text,

                    Direccion = txtDireccion.Text,
                    Telefono = txtTelefono.Text,
                    Edad = int.Parse(txtEdad.Text),
                    Curp = txtCurp.Text,
                    TipoEmpleado = txtTipoEmpleado.Text,

                };

                //Update Person  
                await App.SQLiteDB.SaveEmpleadoAsync(emple);

    
                await DisplayAlert("Success", "Person Updated Successfully", "OK");
 

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
            else if (string.IsNullOrEmpty(txtTipoEmpleado.Text))
            {
                respuesta = false;
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        

    }
}