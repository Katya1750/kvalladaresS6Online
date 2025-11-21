using System.Net.Http;
using System.Net.Http.Headers;
using System.Collections.Generic;

namespace kvalladaresS6Online.Vistas
{
    public partial class vistaAgregar : ContentPage
    {
        HttpClient client = new HttpClient();
        string url = "http://127.0.0.1/wsestudiante/restEstudiantes.php";

        public vistaAgregar()
        {
            InitializeComponent();
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                    string.IsNullOrWhiteSpace(txtApellido.Text) ||
                    string.IsNullOrWhiteSpace(txtEdad.Text))
                {
                    await DisplayAlert("Error", "Todos los campos son obligatorios.", "OK");
                    return;
                }

                var datos = new Dictionary<string, string>
                {
                    { "nombre", txtNombre.Text },
                    { "apellido", txtApellido.Text },
                    { "edad", txtEdad.Text }
                };

                var contenido = new FormUrlEncodedContent(datos);
                var respuesta = await client.PostAsync(url, contenido);

                if (respuesta.IsSuccessStatusCode)
                {
                    await DisplayAlert("Correcto", "Estudiante guardado correctamente", "OK");

                    // Regresar a la lista
                    await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert("Error", "No se pudo guardar en el servidor", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Excepción", ex.Message, "OK");
            }
        }
    }
}

