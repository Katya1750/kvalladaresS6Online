using kvalladaresS6Online.Vistas;

namespace kvalladaresS6Online
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            // Cargar directamente la página principal
            return new Window(new vistaEstudiante());
        }
    }
}