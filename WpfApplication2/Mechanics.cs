using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Progress.Models;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace Progress.Mechanics
{
    class Mechanics
    {
        public static string difficulty = "Easy";
        public static int diffNum = 0;
        private static int time = 10;
        private static int points = 0;
        public static List<Tree> treeList = new List<Tree>();
        public static ImageBrush brushYoung = new ImageBrush();
        public static ImageBrush brushAdult = new ImageBrush();
        public static Random rnd = new Random();

        //CONSTRUCTOR
        public Mechanics()
        {
            brushYoung.ImageSource = new BitmapImage(new Uri("D:/Efrik/Documents/Visual Studio 2015/Projects/Progress/Progress/Images/YoungTree.png", UriKind.Relative));
            brushAdult.ImageSource = new BitmapImage(new Uri("D:/Efrik/Documents/Visual Studio 2015/Projects/Progress/Progress/Images/AdultTree.png", UriKind.Relative));
        }

        //GAME METHODS
        public static void SetTime(int n)
        {
            time = n;
        }

        public static int GetTime()
        {
            return time;
        }

        public static int GetPoints()
        {
            return points;
        }

        public static void SetPoints(int n)
        {
            points = n;
        }

        public static void AddPoints(int n)
        {
            points += n;
        }

        public static Tree RandomTree()
        {
            int r = rnd.Next(treeList.Count);
            Tree t = treeList[r];
            return t;
        }
        public static void GrowTree(Tree t)
        {
            t.Reverse();
        }
        public static void GrowRandomTree()
        {
            Tree r = RandomTree();
            r.Reverse();
        }
    }
}
