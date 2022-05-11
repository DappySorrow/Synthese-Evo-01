//Jean-Simon Barbeau --- 1446326
using System.Windows;
using System.Windows.Controls;

namespace UIL
{
    /// <summary>
    /// Logique d'interaction pour UCAccueil.xaml
    /// </summary>
    public partial class UCAccueil : UserControl
    {
        public UCAccueil()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Lors que la grille est loadée, changer le titre de la fenêtre
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Window window = Window.GetWindow(this);
            window.Title = "Acceuil";
        }
    }
}
