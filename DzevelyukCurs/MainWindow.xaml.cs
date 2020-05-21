﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using DzevelyukCurs.Models;
using MahApps.Metro.Controls;

namespace DzevelyukCurs
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            
            //Database.SetInitializer(new DropCreateDatabaseAlways<FarmContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FarmContext>());
            using (FarmContext db = new FarmContext())
            {
                //db.Database.Delete();
            }
        }
    }
}
