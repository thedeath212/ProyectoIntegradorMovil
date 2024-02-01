using ProyectoIntegrador.Admin;
using ProyectoIntegrador.Modelo;
using ProyectoIntegrador.Usuarios;
using System;
using Xamarin.Forms;

namespace ProyectoIntegrador
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            
        }


        private void btn_Login_Clicked(object sender, EventArgs e)
        {
            string usuario = UsuarioEntry.Text;
            string contraseña = ContraseñaEntry.Text;

            if ((usuario == "admin" || usuario == "usuario") && contraseña == "12345")
            {
                string mensajeBienvenida = ObtenerMensajeBienvenida(usuario);
                DisplayAlert("¡Bienvenido!", mensajeBienvenida, "OK");

                if (usuario == "admin")
                {
                    Navigation.PushAsync(new AdminPage());
                }
                else if (usuario == "usuario")
                {
                    Navigation.PushAsync(new UsuariosPage());
                }
            }
            else
            {
                DisplayAlert("Error", "Credenciales incorrectas", "OK");
            }
        }

        private string ObtenerMensajeBienvenida(string tipoUsuario)
        {
            // Puedes personalizar el mensaje de bienvenida según el tipo de usuario
            switch (tipoUsuario)
            {
                case "admin":
                    return "¡Bienvenido Administrador!";
                case "usuario":
                    return "¡Bienvenido Usuario!";
                default:
                    return "¡Bienvenido!";
            }
        }
    }
}
