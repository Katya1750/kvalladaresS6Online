using Newtonsoft.Json;
using System.Text;

namespace kvalladaresS6Online.Vistas;

public partial class vistaActualizarEliminar : ContentPage
{
    string codigoEstudiante;

    public vistaActualizarEliminar(string codigo, string nombre, string apellido, string edad)
    {
        InitializeComponent();

        codigoEstudiante = codigo;

        txtCodigo.Text = codigo;
        txtNombre.Text = nombre;
        txtApellido.Text = apellido;
        txtEdad.Text = edad;
    }

    // ================================
    // 🔥 ACTUALIZAR (PUT)
    // ================================
    private async void btnActualizar_Clicked(object sender, EventArgs e)
    {
        string url = $"http://127.0.0.1/wsestudiante/restEstudiantes.php?codigo={codigoEstudiante}";

        var datos = new
        {
            codigo = codigoEstudiante,
            nombre = txtNombre.Text,
            apellido = txtApellido.Text,
            edad = txtEdad.Text
        };

        var json = JsonConvert.SerializeObject(datos);
        var contenido = new StringContent(json, Encoding.UTF8, "application/json");

        var client = new HttpClient();
        var respuesta = await client.PutAsync(url, contenido);

        if (respuesta.IsSuccessStatusCode)
        {
            await DisplayAlert("OK", "Estudiante ACTUALIZADO correctamente.", "Cerrar");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "No se pudo actualizar el estudiante", "OK");
        }
    }

   
    //  ELIMINAR (DELETE)
    
    private async void btnEliminar_Clicked(object sender, EventArgs e)
    {
        string url = $"http://127.0.0.1/wsestudiante/restEstudiantes.php?codigo={codigoEstudiante}";

        var client = new HttpClient();
        var respuesta = await client.DeleteAsync(url);

        if (respuesta.IsSuccessStatusCode)
        {
            await DisplayAlert("OK", "Estudiante ELIMINADO correctamente.", "Cerrar");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "No se pudo eliminar", "OK");
        }
    }
}
