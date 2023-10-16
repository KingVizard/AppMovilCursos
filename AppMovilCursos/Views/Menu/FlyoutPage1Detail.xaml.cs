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
    public partial class FlyoutPage1Detail : ContentPage
    {
        public FlyoutPage1Detail()
        {
            InitializeComponent();
        }

        private async void btnNavTask_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PageCursos());
        }

        private async void btnNavEmployee_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new PageEmpleados());
        }
    }
}