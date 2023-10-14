using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppMovilCursos.Views;

namespace AppMovilCursos
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAyuda_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushModalAsync(new Ayuda());
        }

        private void btnIngresar_Clicked(object sender, EventArgs e)
        {

        }
    }
}
