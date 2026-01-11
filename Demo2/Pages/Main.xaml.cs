using Demo2.Models;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;

namespace Demo2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Page
    {
        public Main()
        {
            InitializeComponent();
            List<Number> Numbers = MainWindow.connection.Numbers.ToList();
            spItems.Children.Clear();
            foreach (Number number in Numbers)
                spItems.Children.Add(new Elements.Item(number, this));
        }

        private void Add(object sender, RoutedEventArgs e) =>         
            MainWindow.Init.frame.Navigate(new Pages.Add());    
    }
}
