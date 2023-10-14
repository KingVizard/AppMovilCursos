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
	public partial class Contenedor : MasterDetailPage
	{
		public Contenedor ()
		{
			InitializeComponent ();
            this.Master = new Nav(); //llama al menu
            this.Detail = new NavigationPage(new Inicio()); //llama pantalla principal(inicio )
            App.MasterDet = this;
        }
	}
}