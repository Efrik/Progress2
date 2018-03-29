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
using Progress.Windows;

namespace Progress.Windows
{
    /// <summary>
    /// Lógica de interacción para GameEnd.xaml
    /// </summary>
    public partial class GameEnd : Window
    {
        public GameEnd()
        {
            InitializeComponent();
            int p = Mechanics.Mechanics.GetPoints();
            string t = p.ToString();
            PointsLabel.Content = t+" trees";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
