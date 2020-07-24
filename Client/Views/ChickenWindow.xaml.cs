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
using Client.ViewModels;
using DataBaseAccess;
using DataBaseModels;

namespace Client.Views
{
    /// <summary>
    /// Логика взаимодействия для ChickenWindow.xaml
    /// </summary>
    public partial class ChickenWindow : Window
    {
        public ChickenWindow()
        {
            InitializeComponent();
        }

        public ChickenWindow(Chicken chicken, FarmContext context):this()
        {
            DataContext = new ChickenViewModel(chicken, context);
        } // ctorf.
    }
}
