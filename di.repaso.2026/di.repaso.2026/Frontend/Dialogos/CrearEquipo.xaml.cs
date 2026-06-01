using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using di.repaso._2026.MVVM;
using MahApps.Metro.Controls;

namespace di.repaso._2026.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para CrearEquipo.xaml
    /// </summary>
    public partial class CrearEquipo : MetroWindow
    {

        private readonly VMNba _vmNba;

        public CrearEquipo(VMNba vmNba)
        {
            InitializeComponent();
            _vmNba = vmNba;
        }

        private async void Equipos_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.AddHandler(Validation.ErrorEvent, new RoutedEventHandler(_vmNba.OnErrorEvent));

                await _vmNba.Inicializar();
                DataContext = _vmNba;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        //Guardar en la BD
        private async void crear_equipo(object sender, RoutedEventArgs e)
        {
            if (!_vmNba.HasErrors)
            {
                try
                {

                    bool guardado = await _vmNba.GuardarEquipo();

                    if (guardado)
                    {
                        MessageBox.Show("Equipo guardado correctamente", "Éxito");
                        DialogResult = true;

                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el empleado", "Error");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString());//gg hasta aqui 2º DAM
                    MessageBox.Show("Ha habido problemas con el servidor", "Error");
                }
            }
        }
    }
}
