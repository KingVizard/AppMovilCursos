using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;



namespace AppMovilCursos.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ImagePopupPage : Rg.Plugins.Popup.Pages.PopupPage
    {
        public ImagePopupPage(Byte[] img)
        {
            InitializeComponent();

            //if (!img.Any())
            if (img != null)
            {
                //DisplayAlert("Avsos", "TEST", "OG");
                Stream stream = new MemoryStream(img);
                ImgEmpleadoA.Source = ImageSource.FromStream(() => stream);
            } else
            {
                ImgEmpleadoA.Source = ImageSource.FromFile("SinImg.png");
                //DisplayAlert("Avsos", "TEST", "OKKK");
            }




            //Estilos
            var newBackground = Color.FromRgba(0, 0, 0, .5);

            ImgEmpleadoA.BackgroundColor = newBackground;


            //Centrado de texto del boton 

            BtnVolver.HorizontalOptions = LayoutOptions.CenterAndExpand;
            BtnVolver.VerticalOptions = LayoutOptions.CenterAndExpand;
        }

        //public ImagePopupPage()
        //{
        //    InitializeComponent();

        //    ImgEmpleadoA.Source = ImageSource.FromFile("pruebas.png");

        //    var newBackground = Color.FromRgba(0, 0, 0, .5);

        //    ImgEmpleadoA.BackgroundColor = newBackground;

        //    BtnVolver.HorizontalOptions = LayoutOptions.CenterAndExpand;
        //    BtnVolver.VerticalOptions = LayoutOptions.CenterAndExpand;
        //}

        private async void BtnVolver_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.Instance.PopAsync();

        }

 
    }
}