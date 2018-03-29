using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Progress.Windows;

namespace Progress.Models
{
    class ExitButton: Button
    {
        protected override void OnClick()
        {
            base.OnClick();
            Window win = Application.Current.MainWindow;
            StartWindow main = new StartWindow();
            main.Show();
            win.Close();
        }
    }
}
