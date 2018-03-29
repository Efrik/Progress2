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
using Progress.Models;
using System.Threading;

namespace Progress.Windows
{
    /// <summary>
    /// Lógica de interacción para GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window

        
    {
        public static Grid mainDivision = new Grid();
        public static Grid counters = new Grid();
        public static TextBlock pointCount = new TextBlock();
        public static TextBlock timeCount = new TextBlock();
        private int time = Mechanics.Mechanics.GetTime();

        public GameWindow()
        {
            
            InitializeComponent();

            Application.Current.MainWindow = this;
            Application.Current.MainWindow.Width = 800;
            Application.Current.MainWindow.Height = 900;

            RowDefinition mainrow1 = new RowDefinition();
            RowDefinition mainrow2 = new RowDefinition();
            ColumnDefinition maincolumn = new ColumnDefinition();
            mainDivision.RowDefinitions.Add(mainrow1);
            mainDivision.RowDefinitions.Add(mainrow2);
            mainrow1.MaxHeight = 50;
            mainrow1.MinHeight = 50;
            maincolumn.MinWidth = 5000;


            //Creating the grid in the upper part of the Dockpanel;

            Grid.SetRow(counters, 0);
            Grid.SetColumn(counters, 0);
            counters.Background = Brushes.Black;

            ColumnDefinition counterColumn1 = new ColumnDefinition();
            ColumnDefinition counterColumn2 = new ColumnDefinition();
            ColumnDefinition counterColumn3 = new ColumnDefinition();
            ColumnDefinition counterColumn4 = new ColumnDefinition();
            ColumnDefinition counterColumn5 = new ColumnDefinition();
            counters.ColumnDefinitions.Add(counterColumn1);
            counters.ColumnDefinitions.Add(counterColumn2);
            counters.ColumnDefinitions.Add(counterColumn3);
            counters.ColumnDefinitions.Add(counterColumn4);
            counters.ColumnDefinitions.Add(counterColumn5);

            //Creating the texts to be shown in the upper grid;
            TextBlock timeText = new TextBlock();
            timeText.Text = "Time";
            timeText.FontSize = 24;
            timeText.Foreground = Brushes.DarkGreen;
            timeText.Width = 300;
            Grid.SetColumn(timeText, 0);
            Grid.SetRow(timeText, 0);


            int timeRemaining = Mechanics.Mechanics.GetTime();
            timeCount.Text = timeRemaining.ToString();
            timeCount.FontSize = 24;
            timeCount.Foreground = Brushes.DarkGreen;
            timeCount.Width = 100;
            Grid.SetColumn(timeCount, 1);
            Grid.SetRow(timeCount, 0);

            TextBlock pointText = new TextBlock();
            pointText.Text = "Points";
            pointText.FontSize = 24;
            pointText.Foreground = Brushes.DarkGreen;
            pointText.Width = 300;
            Grid.SetColumn(pointText, 2);
            Grid.SetRow(pointText, 0);


            int pointsEarned = Mechanics.Mechanics.GetPoints();
            pointCount.Text = pointsEarned.ToString();
            pointCount.FontSize = 24;
            pointCount.Foreground = Brushes.DarkGreen;
            pointCount.Width = 100;
            Grid.SetColumn(pointCount, 3);
            Grid.SetRow(pointCount, 0);

            ExitButton exit = new ExitButton();
            Grid.SetColumn(exit, 4);
            exit.Foreground = Brushes.Black;
            exit.Background = Brushes.DarkGreen;
            exit.Content = "X";

            //Adding the created filling into the upper grid;
            counters.Children.Add(timeText);
            counters.Children.Add(timeCount);
            counters.Children.Add(pointText);
            counters.Children.Add(pointCount);
            counters.Children.Add(exit);

            //Adding the upper grid tot he upper Dockpanel
            mainDivision.Children.Add(counters);
            this.Content = mainDivision;

            //Creating the grid to the lower part, together with the buttons
            TreeGrid treeGrid = new TreeGrid(Mechanics.Mechanics.diffNum);
            Grid.SetRow(treeGrid, 1);
            mainDivision.Children.Add(treeGrid);

            this.Show();

            //Start the game
            Mechanics.Mechanics.GrowRandomTree();

            Console.WriteLine("Creating a timer?");
            //Create the timer
            //Create the Timer
            // 1) Create a class that contains what to do once the timer reaches one click
            TimeUp tu = new TimeUp(this);
            // 2) Create an autoresetevent that makes somethig to reset the timer and things like that. I dont get it yet...
            AutoResetEvent autoReset = new AutoResetEvent(false);
            // 3) Create the timer with the thing to do and the autoresetevent
            // 3.2) it also includes how many milisecs for the timer to start, and how many milisecs between clicks
            Timer gameTimer = new Timer(tu.Timer_Tick, autoReset, 1000, 1000);
            // Is this what to do once the timer should end?
            Console.WriteLine("And now we wait for the timer to end");
            autoReset.WaitOne();
            GameEnd end = new GameEnd();
            end.Show();
            this.Close();
            Console.WriteLine("Timer should have started");
        }

        public void Time1 ()
        {
                time -= 1;
        }
        public int GetTime()
        {
            return time;
        }
        public void Update()
        {
            mainDivision.UpdateLayout();
        }
    }

    class TimeUp
    {
        GameWindow gameWin;

        public TimeUp (GameWindow gameW)
        {
            gameWin = gameW;
        }

        public void Timer_Tick(object Event)
        {
            AutoResetEvent autoReset = (AutoResetEvent)Event;
            Console.WriteLine("something, something, something");
            if (gameWin.GetTime() > 0)
            {
                gameWin.Time1();
                //gameWin.Update();               
            }
            else
            {
                autoReset.Set();
            }
        }
    }
}
