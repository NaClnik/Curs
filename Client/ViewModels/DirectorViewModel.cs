using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Client.Other;
using Client.Views;
using DataBaseAccess;
using DataBaseModels;

namespace Client.ViewModels
{
    public class DirectorViewModel
    {
        // Поля класса.
        private FarmContext _farmContext;
        private Person _director;

        // Поля команд класса.
        private RelayCommand _dragWindowCommand;
        private RelayCommand _closeWindowCommand;
        private RelayCommand _exitCommand;
        private RelayCommand _fillDockPanelCommand;

        // Свойства класса.
        public Person Director => _director;

        // Свойства команд класса.
        public RelayCommand CloseWindowCommand =>
            _closeWindowCommand ?? new RelayCommand(obj =>
            {
                var window = obj as Window;
                window?.Close();
            });

        public RelayCommand ExitCommand =>
            _exitCommand ?? new RelayCommand(obj =>
            {
                new MainWindow(_farmContext).Show();

                (obj as Window)?.Close();
            });

        public RelayCommand DragWindowCommand =>
            _dragWindowCommand ?? new RelayCommand(obj =>
            {
                var window = obj as Window;
                window?.DragMove();
            });

        public RelayCommand FillDockPanelCommand =>
            _fillDockPanelCommand ?? new RelayCommand(obj =>
            {
                WrapPanel panel = obj as WrapPanel;

                void FillPanel()
                {
                    panel?.Children.Clear();

                    foreach (var item in _farmContext.Shops)
                    {
                        Button button = new Button()
                        {
                            Content = $"Цех №{item.Id}",
                            HorizontalAlignment = HorizontalAlignment.Left,
                            VerticalAlignment = VerticalAlignment.Top,
                            Width = 200,
                            Height = 200,
                            Margin = new Thickness(5)
                        };
                        button.Click += (sender, e) => { new ShopWindow(item, _farmContext).ShowDialog(); };
                        panel?.Children.Add(button);
                    } // foreach.

                    Button addButton = new Button()
                    {
                        Content = "Добавить цех",
                        HorizontalAlignment = HorizontalAlignment.Left,
                        VerticalAlignment = VerticalAlignment.Top,
                        Width = 200,
                        Height = 200,
                        Margin = new Thickness(5)
                    };

                    addButton.Click += (sender, e) =>
                    {
                        _farmContext.Shops.Add(new Shop());
                        _farmContext.SaveChanges();
                        FillPanel();
                    };

                    panel?.Children.Add(addButton);
                }

                FillPanel();
            });


        #region Ансамбль конструкторов
        // Ансамбль конструкторов.
        // Конструктор по умолчанию.
        public DirectorViewModel() { }

        // Конструктор с параметрами.
        public DirectorViewModel(FarmContext context, Person director)
        {
            _farmContext = context;
            _director = director;
        } // ctorf.
        #endregion
    } // DirectorViewModel.
}
