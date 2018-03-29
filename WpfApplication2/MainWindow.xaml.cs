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

namespace Progress.Windows
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        public StartWindow()
        {
            InitializeComponent();
            Mechanics.Mechanics game = new Mechanics.Mechanics();
            DifficultyButton.Content = "Difficulty level: " + Mechanics.Mechanics.difficulty;

        }

        private void Difficulty_Click(object sender, RoutedEventArgs e)
        {
            if (Mechanics.Mechanics.difficulty == "Easy")
            {
                Mechanics.Mechanics.difficulty = "Normal";
                Mechanics.Mechanics.diffNum = 1;
            }
            else if (Mechanics.Mechanics.difficulty == "Normal")
            {
                Mechanics.Mechanics.difficulty = "Hard";
                Mechanics.Mechanics.diffNum = 2;
            }
            else
            {
                Mechanics.Mechanics.difficulty = "Easy";
                Mechanics.Mechanics.diffNum = 0;
            }
            DifficultyButton.Content = "Difficulty level: " + Mechanics.Mechanics.difficulty;
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gaming = new GameWindow();
            this.Close();
        }

        private void DifficultyLabel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
