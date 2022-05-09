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
using System.Windows.Navigation;
using System.Windows.Shapes;

using LiveCharts;
using LiveCharts.Wpf;

namespace UIL
{
    /// <summary>
    /// Logique d'interaction pour UCEvolutionVentes.xaml
    /// </summary>
    public partial class UCEvolutionVentes : UserControl
    {
        public SeriesCollection SC { get; set; }
        //public string[] Annees;
        public List<string> Annees = new List<string>();

        public UCEvolutionVentes()
        {
            InitializeComponent();

            SC = new SeriesCollection()
            {
                new ColumnSeries
                {
                    Title = "Évolution des ventes",
                    DataLabels = true,
                    //Le values des ventes
                    Values = new ChartValues<double>{ 1, 2},
                }
            };

            DataContext = this;
        }

        //Quand on combo box recoit une demande de changement.
        private void cb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
