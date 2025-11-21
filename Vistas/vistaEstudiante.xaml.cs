using kvalladaresS6Online.Modelos;
using Newtonsoft.Json;

namespace kvalladaresS6Online.Vistas
{
    public partial class vistaEstudiante : ContentPage
    {
        public vistaEstudiante()
        {
            InitializeComponent();
            CargarDatos();
        }

        // ============================================
        // 🔥 CARGA DE DATOS DESDE EL SERVICIO WEB
        // ============================================
        private async void CargarDatos()
        {
            try
            {
                string url = "http://127.0.0.1/wsestudiante/restEstudiantes.php";
                var client = new HttpClient();
                var json = await client.GetStringAsync(url);

                var lista = JsonConvert.DeserializeObject<List<Estudiante>>(json);

                listaEstudiantes.ItemsSource = lista;
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "No se pudo cargar los datos.\n" + ex.Message, "OK");
            }
        }

        // ============================================
        // 🔥 BOTÓN AGREGAR
        // ============================================
        private async void btnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new vistaAgregar());
        }

        // ============================================
        // 🔥 SELECCIÓN DE ELEMENTO → ACTUALIZAR/ELIMINAR
        // ============================================
        private async void listaEstudiantes_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                if (e.Item == null)
                    return;

                var estudiante = (Estudiante)e.Item;

                await Navigation.PushAsync(new vistaActualizarEliminar(
                    estudiante.codigo.ToString(),
                    estudiante.nombre,
                    estudiante.apellido,
                    estudiante.edad.ToString()
                ));

                ((ListView)sender).SelectedItem = null; // deseleccionar
            }
            catch (Exception ex)
            {
                await DisplayAlert("ERROR", "No se pudo abrir la vista.\n" + ex.Message, "OK");
            }
        }

        // ============================================
        // 🔥 CUANDO REGRESA A ESTA PANTALLA → REFRESCAR
        // ============================================
        protected override void OnAppearing()
        {
            base.OnAppearing();
            CargarDatos();
        }
    }
}
