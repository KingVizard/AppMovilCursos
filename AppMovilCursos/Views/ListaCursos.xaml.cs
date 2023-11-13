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
    }
}