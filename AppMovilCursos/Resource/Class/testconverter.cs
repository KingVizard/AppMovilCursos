using AppMovilCursos.Views;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using static AppMovilCursos.Views.ListaEmpleados;


namespace AppMovilCursos.Resource.Class
{
    //public class MyValueConverter
    public class MyValueConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                
                if(value is byte[] byteArray)
                {
                    //using (MemoryStream stream = new MemoryStream(byteArray))
                    //{
                    //    //return ImageSource.FromStream(() => stream);
                    //    return stream;
                    //}
                    return ImageSource.FromStream(() => new MemoryStream(byteArray));
                }
                //return null;
                else
                {
                    //return ImageSource.FromFile("IconUser.png");
                    return ImageSource.FromFile("SinImg.png");
                }



                //Stream stream = new MemoryStream(BitConverter.GetBytes(value));

                //byte[] byteArray = BitConverter.GetBytes(stream);




                //Stream stream = new MemoryStream(value);
                //value = stream;
                //return value;

            }
            else 
            {
                //return null;
                return ImageSource.FromFile("usuarioSinFoto.png");
                //return ImageSource.FromFile("IconPerfil.png");


            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Implement the reverse conversion logic here
            throw new NotImplementedException();

        }

        public class ValorImg
        {
            public static Stream ImgStream = Stream.Null;
        }

        public Stream BytesToStreamLL(byte[] bytes)
        {
            Stream stream = new MemoryStream(bytes);
            return stream;
        }
    }
}
