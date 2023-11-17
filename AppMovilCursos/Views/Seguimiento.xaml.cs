using AppMovilCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using static AppMovilCursos.Views.RegistroEmpleados;

namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Seguimiento : ContentPage
    {
        public Seguimiento()
        {
            InitializeComponent();


            ObtenerValoresPk();


            PkHora.Time = new TimeSpan(13, 15, 26);
            //string selectedTimeString = selectedTime.ToString();

            //TimePicker timePicker = new TimePicker
            //{
            //    Time = new TimeSpan(4, 15, 26) // Time set to "04:15:26"
            //};

            PkEstatus.Items.Add("Programado");
            PkEstatus.Items.Add("En progreso");
            PkEstatus.Items.Add("Completado");
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PopModalAsync();
            //var test = PkNombreEmp.SelectedItem;
            //await DisplayAlert("AVISO", PkNombreEmp.Items[PkNombreEmp.SelectedIndex].ToString(), "Ok");

            //await DisplayAlert("AVISO", PkTime.Time.ToString(), "Ok");


            //DatePicker datePicker = new DatePicker();
            //DateTime selectedDate = PkFecha.Date;
            //var datePicker = PkFecha.Format("D");
            //await DisplayAlert("AVISO", selectedDate.Date.ToString("dd/MM/yyyy"), "Ok");
            //await DisplayAlert("AVISO", datePicker, "Ok");
            //DatePicker datePicker = PkFecha {
            //    Format = "D"
            //};

            //DatePicker datePicker = PkFecha.Format();
            //datePicker.Format = "dd/MM/yyyy";

            //mostrar();
        }

        //public async void mostrar()
        //{
        //    var SeguimientoList = await App.SQLiteDB.GetSeguimientoAsync();
        //    if (SeguimientoList != null)
        //    {
        //        lsSeguimiento.ItemsSource = SeguimientoList;
        //    }
        //}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            ObtenerValoresPk();
        }

        public async void ObtenerValoresPk()
        {
            var EmpleadosList = await App.SQLiteDB.GetEmpleadosAsync();
            if (EmpleadosList != null)
            {
                PkNombreEmp.ItemsSource = EmpleadosList;
            }

            var CursosList = await App.SQLiteDB.GetCursosAsync();
            if (CursosList != null)
            {
                PkNombreCur.ItemsSource = CursosList;
            }

        }


        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            //var test = PkTime selectedTime = ;
            //TimeSpan selectedTime = PkTime.Time; //se toma el valor del picker
            //selectedTimeString = selectedTime.ToString();

            //await DisplayAlert("AVISO", PkNombreCur.SelectedItem.ToString(), "Ok");



            //Formato fecha
            //DatePicker fecha = PkFecha;
            //fecha.Format = "dd/MM/yyyy";

            SeguimientoCursos seguimiento = new SeguimientoCursos
            {
                 NombreEmpleado = PkNombreEmp.Items[PkNombreEmp.SelectedIndex].ToString(),
                 NombreCurso = PkNombreCur.Items[PkNombreCur.SelectedIndex].ToString(),
                 Lugar = txtLugarCur.Text,
                Fecha = PkFecha.Date,
                //Fecha = fecha.Date,
                Horas = PkHora.Time,
                Estatus = PkEstatus.SelectedItem.ToString(),
                Calificacion = int.Parse(txtCalificacionCur.Text)
            };

            await App.SQLiteDB.SaveSeguimientoAsync(seguimiento);



        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaSeguimiento());
        }
    }
}