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

            await Navigation.PopModalAsync();
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

            if(ValidarCamposVacios())
            {
                SeguimientoCursos seguimiento = new SeguimientoCursos
                {
                    //NombreEmpleado = PkNombreEmp.SelectedItem.ToString(),
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

                PkNombreEmp.SelectedIndex = -1;
                PkNombreCur.SelectedIndex = -1;
                txtLugarCur.Text = string.Empty;
                PkFecha.Date = DateTime.Today;
                PkHora.Time = new TimeSpan(12,0,0);
                PkEstatus.SelectedIndex = -1;
                txtCalificacionCur.Text = string.Empty;

                await DisplayAlert("AVISO", "Se guardo de manera exitosa", "Ok");



            }
            //else
            //{
            //    await DisplayAlert("AVISO", "Es necesario llenar todos lo campos", "Ok");

            //}
        }

        public bool ValidarCamposVacios()
        {
            bool respuesta;
            if (int.Parse(PkNombreEmp.SelectedIndex.ToString()) == -1)
            {
                respuesta = false;
                PkNombreEmp.Focus();
                DisplayAlert("AVISO", "Nombre vacio", "Ok");
            }
            else if (int.Parse(PkNombreCur.SelectedIndex.ToString()) == -1)
            {
                respuesta = false;
                PkNombreCur.Focus();
                DisplayAlert("AVISO", "Curso Vacio", "Ok");
            }
            else if (string.IsNullOrEmpty(txtLugarCur.Text))
            {
                respuesta = false;
                txtLugarCur.Focus();
                DisplayAlert("AVISO", "Lugar Vacio", "Ok");
            }
            else if (PkFecha.Date < DateTime.Today)
            {
                respuesta = false;
                PkFecha.Focus();
                DisplayAlert("AVISO", "Fecha Incorrecta", "Ok");
            }
            else if (int.Parse(PkEstatus.SelectedIndex.ToString()) == -1 )
            {
                respuesta = false;
                PkEstatus.Focus();
                DisplayAlert("AVISO", "Estatus Vacio", "Ok");
            }
            //else if (string.IsNullOrEmpty(txtCalificacionCur.Text))
            //{
            //    respuesta = false;
            //    txtCalificacionCur.Focus();
            //    DisplayAlert("AVISO", "Calificacion Vacio", "Ok");
            //}
            else if (string.IsNullOrEmpty(txtCalificacionCur.Text))
            {
                respuesta = false;
                txtCalificacionCur.Focus();
                DisplayAlert("AVISO", "Calificacion Vacio", "Ok");
            }

            else if (!string.IsNullOrEmpty(txtCalificacionCur.Text))
            {
                //respuesta = false;
                //txtCalificacionCur.Focus();
                //DisplayAlert("AVISO", "Calificacion Vacio", "Ok");
                if (txtCalificacionCur.Text.ToCharArray().All(Char.IsDigit))
                {
                    if (int.Parse(txtCalificacionCur.Text) <= 10)
                    {
                        respuesta = true;
                        //DisplayAlert("Exito", "Edad Correcta ", "Ok");
                    }
                    else
                    {
                        respuesta = false;
                        DisplayAlert("AVISO", "Solo se puede calificar del 1 a 10", "Ok");
                        txtCalificacionCur.Focus();
                    }
                }
                else
                {
                    respuesta = false;
                    DisplayAlert("ERROR", "Este campo solo acepta digitos", "Ok");
                    txtCalificacionCur.Focus();
                }
            }
            else
            {
                respuesta = true;
            }
            return respuesta;
        }

        private async void btnLista_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ListaSeguimiento());
        }
    }
}