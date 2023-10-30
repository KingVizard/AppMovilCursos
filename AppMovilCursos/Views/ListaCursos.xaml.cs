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

        public async void mostrarCursos()
        {
            var CursosList = await App.SQLiteDB.GetCursosAsync();
            if (CursosList != null)
            {
                lsCursos.ItemsSource = CursosList;
            }
        }



        private async void btnRegistrarCurso_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new RegistroCursos());
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            mostrarCursos();
        }

        


    }
}