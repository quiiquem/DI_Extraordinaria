using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using di.repaso._2026.Frontend.Dialogos;
using di.repaso._2026.MVVM;
using MahApps.Metro.Controls;

namespace di.repaso._2026
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {

        private readonly VMNba _vmNba;

        public MainWindow(VMNba vmNba)
        {
            InitializeComponent();
            _vmNba = vmNba;
            DataContext = _vmNba;
        }

        private void add_equipo(object sender, RoutedEventArgs e) {
            var dialogo = new CrearEquipo(_vmNba);
            dialogo.ShowDialog();
        }

        private void listar_equipo(object sender, RoutedEventArgs e) { }
        private void arbol_equipo(object sender, RoutedEventArgs e) { }

        private void add_jugador(object sender, RoutedEventArgs e)
        {
            var dialogo = new CrearJugador(_vmNba);
            dialogo.ShowDialog();
        }
        private void listar_jugadores(object sender, RoutedEventArgs e) { }
        private void arbol_jugador(object sender, RoutedEventArgs e) { }
    }
}