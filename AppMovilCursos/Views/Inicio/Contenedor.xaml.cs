using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMovilCursos.Views.Inicio
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Contenedor : MasterDetailPage
	{
		public Contenedor ()
		{
			InitializeComponent ();
			this.Master = new Nav();
			this.Detail = new Inicio();
			App.MasterDet = this;
		}
	}
}