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

namespace Progress.Models
{
    class Tree : Button
    {

        public Tree(int a, int b)
        {
            Grid.SetColumn(this, a);
            Grid.SetRow(this, b);
            this.Background = Mechanics.Mechanics.brushYoung;
            Mechanics.Mechanics.treeList.Add(this);
        }

        public void Reverse()
        {
            if (this.Background == Mechanics.Mechanics.brushYoung)
            {
                this.Background = Mechanics.Mechanics.brushAdult;
            }
            else
            {
                this.Background = Mechanics.Mechanics.brushYoung;
            }
        }
        protected override void OnClick()
        {
            base.OnClick();
            if (this.Background == Mechanics.Mechanics.brushAdult)
            {
                Mechanics.Mechanics.AddPoints(1);
                Reverse();
                Mechanics.Mechanics.GrowRandomTree();
                int p = Mechanics.Mechanics.GetPoints();
                GameWindow.pointCount.Text = p.ToString();
            }
        }

    }
}
