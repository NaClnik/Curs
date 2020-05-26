using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using DzevelyukCurs.Other;

namespace DzevelyukCurs.ViewModels
{
    public class ApplicationViewModel
    {
        public UIElementCollection Collection { get; set; }
        // Команды класса.
        private RelayCommand _command;

        public RelayCommand Command => _command ?? new RelayCommand(obj =>
        {
            var a = obj as WrapPanel;
            a.Children.Add(new Button()
            {
                Width = 100, Height = 100
            });
        });
    } // ApplicationViewModel.
}
