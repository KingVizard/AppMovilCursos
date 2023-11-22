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
    public partial class EditarSeguimiento : ContentPage
    {
        public EditarSeguimiento(SeguimientoCursos seguimiento)
        {
            InitializeComponent();

            PkEstatus.Items.Add("Programado");
            PkEstatus.Items.Add("En progreso");
            PkEstatus.Items.Add("Completado");

            //var EmpleadosList = App.SQLiteDB.GetEmpleadosAsync();
            //PkNombreEmp.ItemsSource = (System.Collections.IList)EmpleadosList;

            //int match_Tipo = EmpleadosList.First(x => x.Nombre == seguimiento.NombreEmpleado).Id;
            //PkNombreEmp.SelectedIndex = match_Tipo - 1;


            ObtenerValoresPk();

            //DisplayAlert("AVISO", seguimiento.NombreEmpleado.ToString(), "OOK");


            //PkNombreEmp.Items[PkNombreEmp.SelectedIndex] = seguimiento.NombreEmpleado.ToString();
            //PkNombreCur.SelectedItem = seguimiento.NombreCurso;
            //PkNombreEmp.SelectedItem = seguimiento.NombreEmpleado;
            //PkNombreEmp.SelectedItem = "Leandra Anna Malo Alba";
            ////PkNombreEmp.SelectedIndex = 0;
            ///
            txtIdSeg.Text = seguimiento.Id.ToString();

            Va_Global.nomb_emp = seguimiento.NombreEmpleado;
            Va_Global.nomb_cur = seguimiento.NombreCurso;

            txtLugarCur.Text= seguimiento.Lugar;
            PkHora.Time = seguimiento.Horas;
            PkFecha.Date = seguimiento.Fecha;
            PkEstatus.SelectedItem = seguimiento.Estatus;
            //PkEstatus.SelectedItem = "Programado"; 
            txtCalificacionCur.Text = seguimiento.Calificacion.ToString();


            //DisplayAlert("AVISO", seguimiento.NombreEmpleado.ToString()+ " <--> " + PkNombreEmp.SelectedItem.ToString(), "OOK");


            //VALOR PICKER
            
        }

        public class Va_Global
        {
            public static string nomb_emp = "";
            public static string nomb_cur = "";
        }

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

                int match_Tipo = EmpleadosList.First(x => x.Nombre == Va_Global.nomb_emp).IdEmp;
                PkNombreEmp.SelectedIndex = match_Tipo - 1;

                //int match_Tipo = EmpleadosList.First(x => x.Nombre == .TipoEmpleado).Id;
                //PkNombreEmp.SelectedIndex = match_Tipo - 1;
            }

            var CursosList = await App.SQLiteDB.GetCursosAsync();
            if (CursosList != null)
            {
                PkNombreCur.ItemsSource = CursosList;

                int match_Tipo = CursosList.First(x => x.NombreCurso == Va_Global.nomb_cur).IdCur;
                PkNombreCur.SelectedIndex = match_Tipo - 1;
            }

        }

        private async void btnActualizar_Clicked(object sender, EventArgs e)
        {
            if (ValidarCamposVacios())
            {
                var answer = await DisplayAlert("Aviso", "¿Esta seguro de modificar el registro?", "Si", "No");
                if (answer)
                {
                    SeguimientoCursos segui = new SeguimientoCursos()
                    {
                        Id = Convert.ToInt32(txtIdSeg.Text),
                        NombreEmpleado = PkNombreEmp.Items[PkNombreEmp.SelectedIndex].ToString(),
                        NombreCurso = PkNombreCur.Items[PkNombreCur.SelectedIndex].ToString(),
                        Lugar = txtLugarCur.Text,
                        Fecha = PkFecha.Date,
                        //Fecha = fecha.Date,
                        Horas = PkHora.Time,
                        Estatus = PkEstatus.SelectedItem.ToString(),
                        Calificacion = int.Parse(txtCalificacionCur.Text)
                    };

                    //Update Person  
                    await App.SQLiteDB.SaveSeguimientoAsync(segui);


                    await DisplayAlert("Exito", "Los cambios se ralizaron correctamente", "OK");
                    await Navigation.PopModalAsync();
                }
            }
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
            else if (int.Parse(PkEstatus.SelectedIndex.ToString()) == -1)
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

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdSeg.Text))
            {
                //Get Person  
                var segui = await App.SQLiteDB.GetSegIdAsync(Convert.ToInt32(txtIdSeg.Text));
                if (segui != null)
                {
                    var answer = await DisplayAlert("Aviso", "¿Esta seguro de eliminar el registro?", "Si", "No");
                    if (answer)
                    {
                        await App.SQLiteDB.DeleteSeguimientoAsync(segui);
                        await DisplayAlert("Aviso", "Registro eliminado correctamente", "OK");
                        await Navigation.PopModalAsync();
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "No fue posible eliminar el registro", "OK");
            }
        }

        private void swToggle_Toggled(object sender, ToggledEventArgs e)
        {
            if (swToggle.IsToggled)
            {
                btnEliminar.IsVisible = false;
                btnActualizar.IsVisible = true;

                PkNombreEmp.IsEnabled = true;
                PkNombreCur.IsEnabled= true;
                txtLugarCur.IsEnabled = true;
                PkHora.IsEnabled = true;
                PkFecha.IsEnabled = true;
                PkEstatus.IsEnabled = true;
                txtCalificacionCur.IsEnabled = true;

            }
            else
            {
                btnEliminar.IsVisible = true;
                btnActualizar.IsVisible = false;

                PkNombreEmp.IsEnabled = false;
                PkNombreCur.IsEnabled = false;
                txtLugarCur.IsEnabled = false;
                PkHora.IsEnabled = false;
                PkFecha.IsEnabled = false;
                PkEstatus.IsEnabled = false;
                txtCalificacionCur.IsEnabled = false;
            }
        }
    }
}