using Demo2.Models;
using Demo2.Pages;
using System.Windows;
using System.Windows.Controls;

namespace Demo2.Elements
{
    /// <summary>
    /// Логика взаимодействия для Item.xaml
    /// </summary>
    public partial class Item : UserControl
    {
        public Number Number;
        public Main Main;
        public Item(Number number, Main main)
        {
            InitializeComponent();
            this.Main = main;
            this.Number = number;
            lDateAndDuration.Content = $"Дата:{this.Number.Date.ToString("dd.MM.yyyy")} (Продолжительность: {this.Number.Duration})";
            lFIO.Content = "ФИО: "+this.Number.FIO;
            lPhone.Content = "Номер: " + this.Number.Phone;
            lSerialNumber.Content = "Паспорт: " + this.Number.SerialNumber;
            lHostel.Content = "Отель: " + MainWindow.connection.Hostels.Where(x => x.Id == this.Number.IdHostel).First().Name;
        }

        private void Update(object sender, RoutedEventArgs e) =>
            MainWindow.Init.frame.Navigate(new Pages.Add(Number));
        

        private void Delete(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены что хотите удалить элемент?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) ==
                    MessageBoxResult.Yes)
            {
                MainWindow.connection.Numbers.Remove(Number);
                MainWindow.connection.SaveChanges();

                Main.spItems.Children.Remove(this);
            }
        }
    }
}
