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
using Server.ViewModels;

namespace Server.Views
{
    /// <summary>
    /// Логика взаимодействия для ShowTableWindow.xaml
    /// </summary>
    public partial class ShowShopsWindow : Window
    {
        public ShowShopsWindow()
        {
            InitializeComponent();

            DataContext = new ShowTableViewModel();
        }
    }
}
