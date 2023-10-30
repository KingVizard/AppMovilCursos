using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMovilCursos.Data;
using AppMovilCursos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaEmpleados : ContentPage
    {
          //Empleados test = new Empleados();

        public ListaEmpleados()
        {
            InitializeComponent();
        }

        public async void mostrar()
        {
            var EmpleadosList = await App.SQLiteDB.GetEmpleadosAsync();
            if (EmpleadosList != null)
            {
                lsEmpleados.ItemsSource = EmpleadosList;
            }
            
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            mostrar();
        }
        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void btnRegistrarEmpleado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistroEmpleados());
        }

        /**/
        private async void EditTap_Tapped(object sender, EventArgs e)
        {
            
        }


        private async void DeleteTap_Tapped(object sender, EventArgs e)
        {

            
        }

        private async void lsEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            if (e.Item == null)
            {
                return;
            }
            var user = e.Item as Models.Empleados;
            //*

            //*
            Navigation.PushModalAsync(new EditarEmpleado(user)); //Manda los datos
            ((ListView)sender).SelectedItem = null;
        }
    }
}