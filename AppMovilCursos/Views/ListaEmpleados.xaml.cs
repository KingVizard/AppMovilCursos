using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppMovilCursos.Data;
using AppMovilCursos.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static AppMovilCursos.Views.RegistroEmpleados;

namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaEmpleados : ContentPage
    {

        public ListaEmpleados()
        {
            InitializeComponent();

            var user = App.SQLiteDB.GetEmpleadoIdAsync(1);

            if (user.Result == null) 
            {
                EmpleadosDefault();
            }

        }

        public async void mostrar()
        {
            if (string.IsNullOrEmpty(TxtSearch.Text))
            {
                var EmpleadosList = await App.SQLiteDB.GetEmpleadosAsync();
                if (EmpleadosList != null)
                {
                    lsEmpleados.ItemsSource = EmpleadosList;
                }
            } else
            {
                
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
            btnRegistrarEmpleado.IsEnabled = false;
            await Navigation.PushModalAsync(new RegistroEmpleados());
            btnRegistrarEmpleado.IsEnabled = true;

        }

        private async void lsEmpleados_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            lsEmpleados.IsEnabled= false;
            if (e.Item == null)
            {
                return;
            }
            var user = e.Item as Models.Empleados;

            await Navigation.PushModalAsync(new EditarEmpleado(user));
            ((ListView)sender).SelectedItem = null;
            lsEmpleados.IsEnabled = true;

        }
        public void EmpleadosDefault()
        {
            Empleados emple1 = new Empleados
            {
                Nombre = "Leandra Anna Malo Alba",
                Direccion = "7943 S. Fifth Street",
                Telefono = "5984515865",
                Edad = 23,
                Curp = "SKKS840812OEPDRJSI",
                TipoEmpleado = "Planta",
                imgContent = null
            };
            App.SQLiteDB.SaveEmpleadoAsync(emple1);

            Empleados emple2 = new Empleados
            {
                Nombre = "Severo Granados Iglesia",
                Direccion = "77 Lyme Street",
                Telefono = "8697711487",
                Edad = 24,
                Curp = "GRIS861208TDHYETSV",
                TipoEmpleado = "Temporal",
                imgContent = null
            };
            App.SQLiteDB.SaveEmpleadoAsync(emple2);

            //Empleados emple3 = new Empleados
            //{
            //    Nombre = "Lucho Andreu Amat",
            //    Direccion = "9448 Fairfield St.",
            //    Telefono = "2462457306",
            //    Edad = 20,
            //    Curp = "ANLU901604POTYCNKG",
            //    TipoEmpleado = "Planta",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple3);

            //Empleados emple4 = new Empleados
            //{
            //    Nombre = "Matías Mauricio Castillo Barrera",
            //    Direccion = "8143 College St.",
            //    Telefono = "7079332513",
            //    Edad = 23,
            //    Curp = "CBMM960212",
            //    TipoEmpleado = "Planta",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple4);

            //Empleados emple5 = new Empleados
            //{
            //    Nombre = "Mauricio Guijarro Castelló",
            //    Direccion = "9893 W. Vale Ave.",
            //    Telefono = "6123250216",
            //    Edad = 22,
            //    Curp = "GUCM841405IVBFGSQL",
            //    TipoEmpleado = "Temporal",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple5);

            //Empleados emple6 = new Empleados
            //{
            //    Nombre = "Isaura Leyre Avilés Pelayo",
            //    Direccion = "8094 Albany Drive",
            //    Telefono = "9925645230",
            //    Edad = 23,
            //    Curp = "APIL871804HDGXZNM",
            //    TipoEmpleado = "Planta",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple6);

            //Empleados emple7 = new Empleados
            //{
            //    Nombre = "Soraya Morera Lago",
            //    Direccion = "9001 Creek Street",
            //    Telefono = "6515441246",
            //    Edad = 23,
            //    Curp = "MOLS902711JICVTESO",
            //    TipoEmpleado = "Temporal",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple7);

            //Empleados emple8 = new Empleados
            //{
            //    Nombre = "Victoriano Tapia Cabanillas",
            //    Direccion = "57 Green Drive",
            //    Telefono = "8517826044",
            //    Edad = 23,
            //    Curp = "TACV810603OLMNBVCX",
            //    TipoEmpleado = "Planta",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple8);

            //Empleados emple9 = new Empleados
            //{
            //    Nombre = "Nidia Saez Campoy",
            //    Direccion = "86 Surrey St.",
            //    Telefono = "2656096654",
            //    Edad = 23,
            //    Curp = "SACN802804UHBCFRTD",
            //    TipoEmpleado = "Temporal",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple9);

            //Empleados emple10 = new Empleados
            //{
            //    Nombre = "Teófila Villanueva Molina",
            //    Direccion = "8728 Boston Street",
            //    Telefono = "3054914988",
            //    Edad = 25,
            //    Curp = "VIMT870401ZXCVBNMK",
            //    TipoEmpleado = "Temporal",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple10);

            //Empleados emple11 = new Empleados
            //{
            //    Nombre = "Trini de Alberdi",
            //    Direccion = "45 Heritage Ave.",
            //    Telefono = "5616497485",
            //    Edad = 27,
            //    Curp = "ALTR900412ASDFGHJK",
            //    TipoEmpleado = "Temporal",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple11);

            //Empleados emple12 = new Empleados
            //{
            //    Nombre = "Dani Baena",
            //    Direccion = "9334 Hillside Street",
            //    Telefono = "9667359451",
            //    Edad = 23,
            //    Curp = "BADA772010EFBNOJGD",
            //    TipoEmpleado = "Planta",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple12);

            //Empleados emple13 = new Empleados
            //{
            //    Nombre = "Angelina de Arregui",
            //    Direccion = "611 Academy Street",
            //    Telefono = "7112822848",
            //    Edad = 28,
            //    Curp = "ARAN002102QWERTYUI",
            //    TipoEmpleado = "Temporal",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple13);

            //Empleados emple14 = new Empleados
            //{
            //    Nombre = "Samuel de Carranza",
            //    Direccion = "7201 Mill Street",
            //    Telefono = "3373970627",
            //    Edad = 24,
            //    Curp = "CASA991605YGVBHYTR",
            //    TipoEmpleado = "Temporal",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple14);

            //Empleados emple15 = new Empleados
            //{
            //    Nombre = "Teófila Villanueva Molina",
            //    Direccion = "8728 Boston Street",
            //    Telefono = "3054914988",
            //    Edad = 25,
            //    Curp = "VIMT870401ZXCVBNMK",
            //    TipoEmpleado = "Planta",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple15);

            //Empleados emple16 = new Empleados
            //{
            //    Nombre = "Jacinta Montenegro Garcés",
            //    Direccion = "59 Ridgewood Ave.",
            //    Telefono = "9693834277",
            //    Edad = 27,
            //    Curp = "MOGJ941303ASDUIOPQ",
            //    TipoEmpleado = "Temporal",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple16);

            //Empleados emple17 = new Empleados
            //{
            //    Nombre = "Lisandro Delgado Nadal",
            //    Direccion = "270 West Green Lake St.",
            //    Telefono = "7484951748",
            //    Edad = 23,
            //    Curp = "DENL801804PKNBGREH",
            //    TipoEmpleado = "Planta",
            //    imgContent = null
            //};
            //App.SQLiteDB.SaveEmpleadoAsync(emple17);
        }

        private async void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = e.NewTextValue;
            var EmpleadosList = await App.SQLiteDB.GetEmpleadoNameAsync(searchText);
            if (EmpleadosList != null)
            {
                lsEmpleados.ItemsSource = EmpleadosList;
            } else
            {
                await DisplayAlert("AVISO", "NO EXISTE0", "OK");
            }
        }

    }
}