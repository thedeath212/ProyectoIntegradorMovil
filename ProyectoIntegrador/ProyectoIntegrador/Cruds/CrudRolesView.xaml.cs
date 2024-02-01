using ProyectoIntegrador.Modelo;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoIntegrador.Cruds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrudRolesView : ContentPage
    {
        private ObservableCollection<Rol> listaRoles;
        public CrudRolesView()
        {
            InitializeComponent();
            listaRoles = ObtenerListaRoles();
            rolesListView.ItemsSource = listaRoles;
        }
        private ObservableCollection<Rol> ObtenerListaRoles()
        {
            return new ObservableCollection<Rol>
            {
                new Rol { Descripcion = "Administrador", Estado = "A" },
                new Rol { Descripcion = "Usuario", Estado = "A" },
                 new Rol { Descripcion = "Doctor", Estado = "A" }
            };
        }


        private async void AgregarRol_Clicked(object sender, EventArgs e)
        {
            string descripcion = await DisplayPromptAsync("Nuevo Rol", "Ingrese la descripción", "Aceptar", "Cancelar", "Descripción", maxLength: 50);
            if (descripcion != null)
            {
                // Siempre establece el estado como "A"
                listaRoles.Add(new Rol { Descripcion = descripcion, Estado = "A" });
            }
        }

        private void EliminarRol_Clicked(object sender, EventArgs e)
        {
            Rol rolSeleccionado = (Rol)rolesListView.SelectedItem;
            if (rolSeleccionado != null)
                listaRoles.Remove(rolSeleccionado);
        }

        private async void ModificarRol_Clicked(object sender, EventArgs e)
        {
            Rol rolSeleccionado = (Rol)rolesListView.SelectedItem;

            if (rolSeleccionado != null)
            {
                string descripcion = await DisplayPromptAsync("Modificar Rol", "Ingrese la nueva descripción", "Aceptar", "Cancelar", "Descripción", maxLength: 50, initialValue: rolSeleccionado.Descripcion);
                if (descripcion != null)
                {
                    
                    rolSeleccionado.Descripcion = descripcion;
                    rolSeleccionado.Estado = "A";
                }
            }
        }
    
    }

}