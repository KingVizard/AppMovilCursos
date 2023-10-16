using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using AppMovilCursos;


namespace AppMovilCursos.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutPage1Flyout : ContentPage
    {
        public ListView ListView;

        public FlyoutPage1Flyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutPage1FlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class FlyoutPage1FlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutPage1FlyoutMenuItem> MenuItems { get; set; }
            
            public FlyoutPage1FlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutPage1FlyoutMenuItem>(new[]
                {
                    new FlyoutPage1FlyoutMenuItem { Id = 0, Title = "Inicio", TargetType = typeof(FlyoutPage1Detail), Icon = "IconHome.png" },
                    new FlyoutPage1FlyoutMenuItem { Id = 2, Title = "Perfil", TargetType = typeof(PagePerfil), Icon = "IconUser.png" },
                    new FlyoutPage1FlyoutMenuItem { Id = 3, Title = "Cursos", TargetType = typeof(PageCursos), Icon = "IconHome" },
                    new FlyoutPage1FlyoutMenuItem { Id = 4, Title = "Empleados", TargetType = typeof(PageEmpleados), Icon = "IconUser" },
                    new FlyoutPage1FlyoutMenuItem { Id = 1, Title = "Configuración", TargetType = typeof(PageConfiguracion), Icon = "IconSettings" },
                });
            }
            
            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}