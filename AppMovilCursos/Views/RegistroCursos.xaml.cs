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
    public partial class RegistroCursos : ContentPage
    {
        public RegistroCursos()
        {
            InitializeComponent();
        }

        private async void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Cursos cur = new Cursos
                {
                    NombreCurso = txtNombreCurso.Text,
                    TipoCurso = txtTipoCurso.Text,
                    DescCurso = txtDescCurso.Text,
                    CantidadHoras = int.Parse(txtCantidadHoras.Text),

                };

                await App.SQLiteDB.SaveCursoAsync(cur);

                txtNombreCurso.Text = "";
                txtTipoCurso.Text = "";
                txtDescCurso.Text = "";
                txtCantidadHoras.Text = "";

                await DisplayAlert("AVISO", "Se guardo de manera exitosa", "Ok");
            } else
            {
                await DisplayAlert("AVISO", "Ingresar los datos requeridos", "Ok");
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if(string.IsNullOrEmpty(txtNombreCurso.Text.Trim()))
            {
                respuesta = false;
            }
            else if(string.IsNullOrEmpty(txtTipoCurso.Text.Trim()))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtDescCurso.Text.Trim()))
            {
                respuesta = false;
            }
            else if (string.IsNullOrEmpty(txtCantidadHoras.Text.Trim()))
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
            await Navigation.PopModalAsync();
        }
    }
}