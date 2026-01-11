using Demo2.Models;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
namespace Demo2.Pages
{
    /// <summary>
    /// Логика взаимодействия для Add.xaml
    /// </summary>
    public partial class Add : Page
    {
        public Number Number = null;
        public Add(Number number = null)
        {
            InitializeComponent();
            this.Number = number;

            foreach (Hostel hostel in MainWindow.connection.Hostels.ToList())
            {
                tbHostel.Items.Add(hostel.Name);
            }
            if(this.Number != null)
            {
                tbDate.SelectedDate = this.Number.Date;
                tbTime.Text = this.Number.Date.ToString("hh:mm");
                tbFIO.Text = this.Number.FIO;
                tbPhone.Text = this.Number.Phone;
                tbSerialNumber.Text = this.Number.SerialNumber;
                tbDuration.Text = this.Number.Duration.ToString();
                tbHostel.SelectedIndex = MainWindow.connection.Hostels.ToList().FindIndex(x=> x.Id == this.Number.IdHostel);
            }
        }

        private void Save(object sender, System.Windows.RoutedEventArgs e)
        {
            try {
                if (tbDate.SelectedDate == null)
                {
                    MessageBox.Show("Не указана дата");
                    return;
                }

                if (!IsRegular(tbTime.Text, @"^\d{2}:\d{2}$"))
                {
                    MessageBox.Show("Неправильно указано время: [hh:mm]");
                    return;
                }

                if (!IsRegular(tbFIO.Text, @"^[а-яА-ЯёЁ]+[а-яА-ЯёЁ]+[а-яА-ЯёЁ]$"))
                {
                    MessageBox.Show("Неправильно указано ФИО: Фамилия Имя Отчество");
                    return;
                }

                if (!IsRegular(tbPhone.Text, @"^\+7\(9\d{2}\)\-\d{3}\-\d{2}\-\d{2}$"))
                {
                    MessageBox.Show("Неправильно указан телефон: +7(9XX)-XXX-XX-XX");
                    return;
                }


                if (!IsRegular(tbSerialNumber.Text, @"^\d{4} \d{6}$"))
                {
                    MessageBox.Show("Неправильно указан паспорт: XXXX XXXXXX");
                    return;
                }

                if (!IsRegular(tbDuration.Text, @"^\d{0,7}$"))
                {
                    MessageBox.Show("Неправильно указан паспорт: XXXX XXXXXX");
                    return;
                }

                if (tbHostel.SelectedIndex == -1)
                {
                    MessageBox.Show("Необходимо выбрать отель");
                    return;
                }

                if (this.Number == null)
                {
                    this.Number = new Number();
                    MainWindow.connection.Numbers.Add(Number);
                }

                string[] Time = tbTime.Text.Split(':');
                DateTime Date = (DateTime)tbDate.SelectedDate;
                Date = Date.Add(new TimeSpan(
                    Convert.ToInt32(Time[0]), Convert.ToInt32(Time[1]), 0));
                this.Number.Date = Date;
                this.Number.FIO = tbFIO.Text;
                this.Number.Phone = tbPhone.Text;
                this.Number.SerialNumber = tbSerialNumber.Text;
                this.Number.Duration = Convert.ToInt32(tbDuration.Text);
                this.Number.IdHostel =
                    MainWindow.connection.Hostels.ToList()[tbHostel.SelectedIndex].Id;

                MainWindow.connection.SaveChanges();
                MessageBox.Show("Все данные сохранены!");
                Back(null, e: null);
            }
            catch(Exception ex) { 
                MessageBox.Show(ex.Message);
            }  
            
        }

        public bool IsRegular(string value, string pattern)
        {
            if(string.IsNullOrEmpty(value)) return false;

            Regex regex = new Regex(pattern);
            return regex.IsMatch(value);
        }

        private void Back(object sender, System.Windows.RoutedEventArgs e)=>
            MainWindow.Init.frame.Navigate(new Pages.Main());
    
    }
}
