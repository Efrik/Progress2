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

namespace Progress.Models
{
    class TreeGrid : Grid
    {
        public TreeGrid(int n)
        {
            for (int m = 0; m < n + 3; m++)
            {
                ColumnDefinition column = new ColumnDefinition();
                this.ColumnDefinitions.Add(column);
                RowDefinition row = new RowDefinition();
                this.RowDefinitions.Add(row);
            }
            for (int m = 0; m < n + 3; m++)
            { 
                for (int l = 0; l < n + 3; l++)
                {
                    Tree newTree = new Models.Tree(m, l);
                    this.Children.Add(newTree);

                }
            }
        }
    }
}
