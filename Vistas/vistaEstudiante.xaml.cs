using kvalladaresS6Online.Modelos;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace kvalladaresS6Online.Vistas;

public partial class vistaEstudiante : ContentPage
{
	private const string Url = "http://192.168.100.176/wsestudiante/restEstudiantes.php";

	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Estudiante> _estudiante;


	public async void Mostrar()
	{
		var content = await cliente.GetStringAsync(Url);
		List <Estudiante> mostrarEst = JsonConvert.DeserializeObject<List <Estudiante>>(content);
		_estudiante = new ObservableCollection<Estudiante>(mostrarEst);
		listaEstudiantes.ItemsSource = _estudiante;

	}
	
    public vistaEstudiante()
	{
		InitializeComponent();
		Mostrar();
	}
}