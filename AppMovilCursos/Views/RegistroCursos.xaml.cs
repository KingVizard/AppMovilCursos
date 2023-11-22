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
            if (ValidarCamposVacios())
            {
                if (ValidarCampos())
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
                    PkTipoCurso.SelectedIndex = -1;
                    txtDescCurso.Text = "";
                    txtCantidadHoras.Text = "";

                    await DisplayAlert("AVISO", "Se guardo de manera exitosa", "Ok");
                }

                
            }
            else
            {
                await DisplayAlert("AVISO", "Ingresar los datos requeridos", "Ok");
            }
        }

        public bool ValidarCamposVacios()
        {
            bool respuesta;
            if (string.IsNullOrEmpty(txtNombreCurso.Text))
            {
                respuesta = false;
            }
            else if (int.Parse(PkTipoCurso.SelectedIndex.ToString()) == -1)
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
        
        public bool ValidarCampos()
        {
            bool ans;

            if (txtNombreCurso.Text.Length < 5)
            {
                DisplayAlert("Aviso", "El nombre es demasiado corto", "Ok");
                txtNombreCurso.Focus();
                ans = false;
            }
            else if (txtDescCurso.Text.Length < 5)
            {
                DisplayAlert("Aviso", "La descripcion es demasiado corta", "Ok");
                txtDescCurso.Focus();
                ans = false;
            }
            //else if (txtCantidadHoras.Text.ToCharArray().All(Char.IsDigit))
            //{
            //    DisplayAlert("Aviso", "Ingrese una duracion valida", "Ok");
            //    txtCantidadHoras.Focus();
            //    ans = false;
            //}
            else if (!string.IsNullOrEmpty(txtCantidadHoras.Text)) //si contiene algo
            {
                if (txtCantidadHoras.Text.ToCharArray().All(Char.IsDigit))
                {
                    ans = true;
                }
                else
                {
                    ans = false;
                    DisplayAlert("ERROR", "Este campo solo acepta digitos", "Ok");
                    txtCantidadHoras.Focus();
                }
            }
            else
            {
                ans = true;
            }
            return ans;
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();

        }

    }
}