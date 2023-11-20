using AppMovilCursos.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Perfil : ContentPage
    {
        SQLiteAsyncConnection db;

        public Perfil()
        {
            InitializeComponent();

            //SINOImg.Source = ImageSource.FromFile("SinImg");
        }

        //private async void AgregarImg_Clicked(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions()
        //        {
        //            Name = "Usuario " + DateTime.Now.ToString(),
        //            Directory = "FotosXamarin",
        //            SaveToAlbum = true
        //        });

        //        if (foto != null)
        //        {
        //            AgregarImg.Source = ImageSource.FromStream(() =>
        //            {
        //                MyGlobals.MyVariable = foto.GetStream();
        //                return foto.GetStream();
        //            });

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        await DisplayAlert("Error", ex.Message.ToString(), "Ok");
        //    }
        //}

        //public class MyGlobals
        //{
        //    public static Stream MyVariable;
        //}

        //private void CargarImagen_Clicked(object sender, EventArgs e)
        //{

        //    if(MyGlobals.MyVariable == null)
        //    {
        //        string imagePath = "avatar.png"; // Reemplaza con la ruta de tu imagen

        //        using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        //        {
        //            MemoryStream memoryStream = new MemoryStream();
        //            fileStream.CopyTo(memoryStream);
        //            memoryStream.Position = 0;

        //            // Ahora puedes utilizar memoryStream como un Stream en Xamarin
        //            // Por ejemplo, puedes asignarlo a la propiedad Source de un objeto Image

        //            // Ejemplo:
        //            //Image image = new Image();
        //            MostrarImg.Source = ImageSource.FromStream(() => memoryStream);
        //        }
        //    }
        //    else
        //    {
        //        var imgByte = GetImageBytes(MyGlobals.MyVariable);
        //        Stream stream = new MemoryStream(imgByte);
        //        MostrarImg.Source = ImageSource.FromStream(() => stream);
        //    }

        //}

        //private byte[] GetImageBytes(Stream stream)
        //{
        //    byte[] ImageBytes;
        //    using (var memoryStream = new System.IO.MemoryStream())
        //    {
        //        stream.CopyTo(memoryStream);
        //        ImageBytes = memoryStream.ToArray();
        //    }
        //    return ImageBytes;
        //}

        //public Stream BytesToStream(byte[] bytes)
        //{
        //    Stream stream = new MemoryStream(bytes);
        //    return stream;
        //}
    }
}