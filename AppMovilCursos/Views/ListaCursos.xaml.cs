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
    public partial class ListaCursos : ContentPage
    {
        public ListaCursos()
        {
            InitializeComponent();

            var curso = App.SQLiteDB.GetCursosIdAsync(1);

            if (curso.Result == null) //No es null
            {
                CursosDefault();
            }
        }

        public async void MostrarCursos()
        {
            var CursosList = await App.SQLiteDB.GetCursosAsync();
            if (CursosList != null)
            {
                lsCursos.ItemsSource = CursosList;
            }
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            MostrarCursos();
        }



        private async void btnRegistrarCurso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistroCursos());
        }

        private async void lsCursos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
            {
                return;
            }
            var curso = e.Item as Models.Cursos;

            await Navigation.PushModalAsync(new EditarCurso(curso));
            ((ListView)sender).SelectedItem = null;
        }

        public void CursosDefault()
        {
            Cursos curso1 = new Cursos
            {
                NombreCurso = "CURSO 1",
                TipoCurso = "Interno",
                DescCurso = "Lorem ipsum odor amet, consectetuer adipiscing elit. Sociosqu lorem interdum.",
                CantidadHoras = 2

            };
            App.SQLiteDB.SaveCursoAsync(curso1);

            Cursos curso2 = new Cursos
            {
                NombreCurso = "CURSO 2",
                TipoCurso = "Externo",
                DescCurso = "Lorem ipsum odor amet, consectetuer adipiscing elit. Sociosqu lorem interdum.",
                CantidadHoras = 1
            };
            App.SQLiteDB.SaveCursoAsync(curso2);

        }
    }
}