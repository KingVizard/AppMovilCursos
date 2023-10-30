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
        public EditarEmpleado(Empleados user)
        {
            InitializeComponent();

            txtNombre.Text = user.Nombre;
            txtDireccion.Text = user.Direccion;
            txtTelefono.Text = user.Telefono;
            txtEdad.Text = user.Edad.ToString();
            txtCurp.Text = user.Curp;
            txtTipoEmpleado.Text = user.TipoEmpleado;
        }

        //private void btnRegistrar_Clicked(object sender, EventArgs e)
        //{

        //}

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}