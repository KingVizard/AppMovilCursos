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
    public partial class ListaEmpleados : ContentPage
    {
        public ListaEmpleados()
        {
            InitializeComponent();
            mostrar();
        }

        public async void mostrar()
        {
            var EmpleadosList = await App.SQLiteDB.GetEmpleadosAsync();
            if (EmpleadosList != null)
            {
                lsEmpleados.ItemsSource = EmpleadosList;
            }
        }
        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}