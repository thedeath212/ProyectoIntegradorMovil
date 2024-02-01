using ProyectoIntegrador.Cruds;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoIntegrador.Admin

{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AdminPage : FlyoutPage
    {
        public AdminPage()
        {
            InitializeComponent();

        }
        private void OnOption1Clicked(object sender, EventArgs e)
        {
            var crudDoctoresView = new CrudDoctoresView();
            Detail = new NavigationPage(crudDoctoresView);
            IsPresented = false;
        }

        private void OnOption2Clicked(object sender, EventArgs e)
        {
           
            var crudUsuariosView = new CrudsUsuariosView();
            Detail = new NavigationPage(crudUsuariosView);
            IsPresented = false;
        }

        private void OnOption3Clicked(object sender, EventArgs e)
        {
            var crudRolesView = new CrudRolesView();
            Detail = new NavigationPage(crudRolesView);
            IsPresented = false;
        }

        private void OnOption4Clicked(object sender, EventArgs e)
        {
            var mostrarHorariosView = new CrudHorariosView();
            Detail = new NavigationPage(mostrarHorariosView);
            IsPresented = false;
        }

        private void OnOption5Clicked(object sender, EventArgs e)
        {
            var mostrarEspecialidadesView = new CrudEspecialidadesView();
            Detail = new NavigationPage(mostrarEspecialidadesView);
            IsPresented = false;
        }

    }
}