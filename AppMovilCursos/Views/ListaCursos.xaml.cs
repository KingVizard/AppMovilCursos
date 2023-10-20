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
            mostrarCursos();
        }

        public async void mostrarCursos()
        {
            var CursosList = await App.SQLiteDB.GetCursosAsync();
            if (CursosList != null)
            {
                lsCursos.ItemsSource = CursosList;
            }
        }

        private async void btnVolver_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}