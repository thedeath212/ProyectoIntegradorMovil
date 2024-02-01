using ProyectoIntegrador.Modelo;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoIntegrador.Cruds
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrudsUsuariosView : ContentPage
    {
        private ObservableCollection<Usuario> listaUsuarios;

        public CrudsUsuariosView()
        {
            InitializeComponent();
            listaUsuarios = ObtenerListaUsuarios();
            usuariosListView.ItemsSource = listaUsuarios;
        }

        private ObservableCollection<Usuario> ObtenerListaUsuarios()
        {
            return new ObservableCollection<Usuario>
            {
                new Usuario { Nombre = "John", Apellido = "Doe", Cedula = "123456789", Telefono = "555-1234", Correo = "john.doe@example.com" },
                new Usuario { Nombre = "Jane", Apellido = "Smith", Cedula = "987654321", Telefono = "555-5678", Correo = "jane.smith@example.com" }
            };
        }

        private void EliminarUsuario_Clicked(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario)usuariosListView.SelectedItem;
            if (usuarioSeleccionado != null)
            {
                listaUsuarios.Remove(usuarioSeleccionado);
                ActualizarListaUsuarios();
            }
        }

        private async void ModificarUsuario_Clicked(object sender, EventArgs e)
        {
            Usuario usuarioSeleccionado = (Usuario)usuariosListView.SelectedItem;

            if (usuarioSeleccionado != null)
            {
                string nombre = await DisplayPromptAsync("Modificar Usuario", "Ingrese el nuevo nombre", "Aceptar", "Cancelar", "Nombre", maxLength: 50, initialValue: usuarioSeleccionado.Nombre);
                if (nombre != null)
                {
                    string apellido = await DisplayPromptAsync("Modificar Usuario", "Ingrese el nuevo apellido", "Aceptar", "Cancelar", "Apellido", maxLength: 50, initialValue: usuarioSeleccionado.Apellido);
                    string cedula = await DisplayPromptAsync("Modificar Usuario", "Ingrese la nueva cédula", "Aceptar", "Cancelar", "Cédula", maxLength: 10, initialValue: usuarioSeleccionado.Cedula);
                    string telefono = await DisplayPromptAsync("Modificar Usuario", "Ingrese el nuevo teléfono", "Aceptar", "Cancelar", "Teléfono", maxLength: 15, initialValue: usuarioSeleccionado.Telefono);
                    string correo = await DisplayPromptAsync("Modificar Usuario", "Ingrese el nuevo correo", "Aceptar", "Cancelar", "Correo", maxLength: 50, initialValue: usuarioSeleccionado.Correo);

                    if (nombre != null && apellido != null && cedula != null && telefono != null && correo != null)
                    {
                        // Modificar el usuario seleccionado
                        usuarioSeleccionado.Nombre = nombre;
                        usuarioSeleccionado.Apellido = apellido;
                        usuarioSeleccionado.Cedula = cedula;
                        usuarioSeleccionado.Telefono = telefono;
                        usuarioSeleccionado.Correo = correo;
                        ActualizarListaUsuarios();
                    }
                }
            }
        }

        private async void Agregar_Clicked(object sender, EventArgs e)
        {
            string nombre = await DisplayPromptAsync("Nuevo Usuario", "Ingrese el nombre", "Aceptar", "Cancelar", "Nombre", maxLength: 50);
            if (nombre != null)
            {
                string apellido = await DisplayPromptAsync("Nuevo Usuario", "Ingrese el apellido", "Aceptar", "Cancelar", "Apellido", maxLength: 50);
                string cedula = await DisplayPromptAsync("Nuevo Usuario", "Ingrese la cédula", "Aceptar", "Cancelar", "Cédula", maxLength: 10);
                string telefono = await DisplayPromptAsync("Nuevo Usuario", "Ingrese el teléfono", "Aceptar", "Cancelar", "Teléfono", maxLength: 15);
                string correo = await DisplayPromptAsync("Nuevo Usuario", "Ingrese el correo", "Aceptar", "Cancelar", "Correo", maxLength: 50);

                if (nombre != null && apellido != null && cedula != null && telefono != null && correo != null)
                {
                    listaUsuarios.Add(new Usuario { Nombre = nombre, Apellido = apellido, Cedula = cedula, Telefono = telefono, Correo = correo });
                    ActualizarListaUsuarios();
                }
            }
        }

        private void ActualizarListaUsuarios()
        {
            usuariosListView.ItemsSource = null;
            usuariosListView.ItemsSource = listaUsuarios;
        }
    }
}

