
using Demo2.Classes;
using Demo2.Pages;
using System.Windows;

namespace Demo2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow Init;
        public static DbConnection connection = new DbConnection();
        public MainWindow()
        {
            InitializeComponent();
            connection.Numbers.ToList();
            Init = this;
            frame.Navigate(new Pages.Main());
        }
    }
}