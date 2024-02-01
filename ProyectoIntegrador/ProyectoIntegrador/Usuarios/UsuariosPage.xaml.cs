using ProyectoIntegrador.Cruds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoIntegrador.Usuarios
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsuariosPage : FlyoutPage
    {
        public UsuariosPage()
        {
            InitializeComponent();
           
        }
        private void OnOption1Clicked(object sender, EventArgs e)
        {
            var HOME = new VistasP.Home();
            Detail = new NavigationPage(HOME);
            IsPresented = false;
        }

        private void OnOption2Clicked(object sender, EventArgs e)
        {

            var Horarios = new VistasP.VerEspecialidades();
            Detail = new NavigationPage(Horarios);
            IsPresented = false;
        }

        private void OnOption3Clicked(object sender, EventArgs e)
        {
            var Facturas = new VistasP.Facturas();
            Detail = new NavigationPage(Facturas);
            IsPresented = false;
        }

        private void OnOption4Clicked(object sender, EventArgs e)
        {
            var CitasMédicas = new VistasP.CitasMedicas();
            Detail = new NavigationPage(CitasMédicas);
            IsPresented = false;
        }

        private void OnOption5Clicked(object sender, EventArgs e)
        {
            var Perfil = new VistasP.Perfil();
            Detail = new NavigationPage(Perfil);
            IsPresented = false;
        }

    }
}