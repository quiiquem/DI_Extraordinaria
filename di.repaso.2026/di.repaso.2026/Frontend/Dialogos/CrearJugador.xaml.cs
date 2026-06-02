using di.repaso._2026.MVVM;
using MahApps.Metro.Controls;
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

namespace di.repaso._2026.Frontend.Dialogos
{
    /// <summary>
    /// Lógica de interacción para CrearJugador.xaml
    /// </summary>
    public partial class CrearJugador : MetroWindow
    {

        private readonly VMNba _vmNba;
        public CrearJugador(VMNba vmNba)
        {
            InitializeComponent();
            _vmNba = vmNba;
        }


        private async void Jugadores_Loaded(object sender, RoutedEventArgs e)
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

        //Solo permitir poner numeros
        private void SoloNumeros(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !int.TryParse(e.Text, out _);
        }

        //Solo permitir poner nums y decimales
        private void SoloDecimales(object sender, TextCompositionEventArgs e)
        {
            TextBox tb = sender as TextBox;
            bool esDigito = char.IsDigit(e.Text[0]);
            bool esDecimal = (e.Text == "." || e.Text == ",") && !tb.Text.Contains('.');

            e.Handled = !(esDigito || esDecimal);
        }


        //Guardar Jugador en la BD
        private async void anyadir_Jugador(object sender, RoutedEventArgs e)
        {
            if (!_vmNba.HasErrors)
            {
                try
                {
                    bool guardado = await _vmNba.GuardarJugador();

                    if (guardado)
                    {
                        MessageBox.Show("Jugador guardado correctamente", "Éxito");
                        DialogResult = true;

                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el jugador", "Error");
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.ToString()); //gg hasta aqui 2º DAM
                    MessageBox.Show("Ha habido problemas con el servidor", "Error");
                }
            }
        }
    }
}