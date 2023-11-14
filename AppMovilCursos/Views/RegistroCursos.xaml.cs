using AppMovilCursos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using AppMovilCursos.Views;

namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistroCursos : ContentPage
    {
        public RegistroCursos()
        {
            InitializeComponent();

            PkTipoCurso.Items.Add("Interno");
            PkTipoCurso.Items.Add("Externo");
        }

        private async void btnRegistrarCursos_Clicked(object sender, EventArgs e)
        {
            if (validarDatos())
            {
                Cursos cur = new Cursos
                {
                    NombreCurso = txtNombreCurso.Text,
                    TipoCurso = PkTipoCurso.Items[PkTipoCurso.SelectedIndex].ToString(),
                    //TipoCurso = PkTipoCurso.SelectedItem.ToString(),
                    DescCurso = txtDescCurso.Text,
                    CantidadHoras = int.Parse(txtCantidadHoras.Text),

                };

                await App.SQLiteDB.SaveCursoAsync(cur);

                txtNombreCurso.Text = "";
                //txtTipoCurso.Text = "";
                txtDescCurso.Text = "";
                txtCantidadHoras.Text = "";

                await DisplayAlert("AVISO", "Se guardo de manera exitosa", "Ok");

                
            }
            else
            {
                await DisplayAlert("AVISO", "Ingresar los datos requeridos", "Ok");
            }
        }

        public bool validarDatos()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombreCurso.Text))
            {
                respuesta = false;
            }
            //else if (string.IsNullOrEmpty(txtTipoCurso.Text))
            //{
            //    respuesta = false;
            //}
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

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }

    }
}