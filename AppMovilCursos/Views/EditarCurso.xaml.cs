using AppMovilCursos.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarCurso : ContentPage
    {
        ValidarCambiosCursos Datos = new ValidarCambiosCursos();

        public EditarCurso(Cursos cursos)
        {
            InitializeComponent();

            txtIdCurso.Text = cursos.IdCur.ToString();
            txtNombreCurso.Text = cursos.NombreCurso;
            //PkTipoCurso.SelectedItem = cursos.TipoCurso.ToString();
            txtDescCurso.Text = cursos.DescCurso;
            txtCantidadHoras.Text = cursos.CantidadHoras.ToString();


            Datos.Curso = cursos.NombreCurso;
            Datos.TipoCurso = cursos.TipoCurso;
            Datos.DescCurso = cursos.DescCurso;
            Datos.DuracionCurso = cursos.CantidadHoras.ToString();



            PkTipoCurso.Items.Add("Interno");
            PkTipoCurso.Items.Add("Externo");

            PkTipoCurso.SelectedItem = cursos.TipoCurso;

        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            if (ValidarCamposMod() == false)
            {
                var answer = await DisplayAlert("AVISO", "¿Desea salir sin guardar?, se perderán los cambios realizados.", "Si", "No");
                if (answer)
                {
                    await Navigation.PopModalAsync();
                }
            }
            else
            {
                await Navigation.PopModalAsync();
            }


        }
        private void swToggle_Toggled(object sender, ToggledEventArgs e)
        {
            if (swToggle.IsToggled)
            {
                btnEliminarCursos.IsVisible = false;
                btnEditarCursos.IsVisible = true;

                txtNombreCurso.IsEnabled = true;
                PkTipoCurso.IsEnabled = true;
                txtDescCurso.IsEnabled = true;
                txtCantidadHoras.IsEnabled = true;
            }
            else
            {
                btnEliminarCursos.IsVisible = true;
                btnEditarCursos.IsVisible = false;

                txtNombreCurso.IsEnabled = false;
                PkTipoCurso.IsEnabled = false;
                txtDescCurso.IsEnabled = false;
                txtCantidadHoras.IsEnabled = false;
            }
        }

        private async void btnEliminarCursos_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtIdCurso.Text))
            {
                //Get Person  
                var curso = await App.SQLiteDB.GetCursosIdAsync(Convert.ToInt32(txtIdCurso.Text));
                if (curso != null)
                {
                    var answer = await DisplayAlert("Aviso", "¿Esta seguro de eliminar el registro?", "Si", "No");
                    if (answer)
                    {
                        await App.SQLiteDB.DeleteCursoAsync(curso);
                        await DisplayAlert("Aviso", "Curso eliminado correctamente", "OK");
                        await Navigation.PopModalAsync();
                    }
                }
            }
            else
            {
                await DisplayAlert("Error", "No fue posible eliminar al empleado", "OK");
            }
        }

        private async void btnEditarCursos_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                var answer = await DisplayAlert("Aviso", "¿Esta seguro de modificar el registro?", "Si", "No");
                if (answer)
                {
                    Cursos cursos = new Cursos()
                    {
                        IdCur = int.Parse(txtIdCurso.Text),
                        NombreCurso = txtNombreCurso.Text,
                        TipoCurso = PkTipoCurso.SelectedItem.ToString(),
                        DescCurso = txtDescCurso.Text,
                        CantidadHoras = int.Parse(txtCantidadHoras.Text)
                    };

                    await App.SQLiteDB.SaveCursoAsync(cursos);


                    await DisplayAlert("Exito", "Los cambios se ralizaron correctamente", "OK");
                    await Navigation.PopModalAsync();
                }
            }
            else
            {
                await DisplayAlert("Error", "Ocurrio un error al modificar el registro", "OK");
            }
        }
        public bool ValidarCamposMod()
        {
            bool answer;
            if(txtNombreCurso.Text != Datos.Curso)
            {
                answer = false;
            }
            else if (PkTipoCurso.SelectedItem.ToString() != Datos.TipoCurso)
            {
                answer = false;
            }
            else if (txtDescCurso.Text != Datos.DescCurso)
            {
                answer = false;
            }
            else if (txtCantidadHoras.Text != Datos.DuracionCurso)
            {
                answer = false;
            }
            else
            {
                answer = true;
            }
            return answer;
        }

        public class ValidarCambiosCursos
        {
            public string Curso { get; set; }
            public string TipoCurso { get; set; }
            public string DescCurso { get; set; }
            public string DuracionCurso { get; set; }
        }
        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombreCurso.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(PkTipoCurso.SelectedItem.ToString()))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDescCurso.Text))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCantidadHoras.Text))
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