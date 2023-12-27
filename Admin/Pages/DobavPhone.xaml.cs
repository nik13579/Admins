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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Admin.Pages
{
    /// <summary>
    /// Логика взаимодействия для DobavPhone.xaml
    /// </summary>
    public partial class DobavPhone : Page
    {
        public DobavPhone()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PhoneSprav SpravochnikObj = new PhoneSprav()
                {
                    FIO = TxbLogin12.Text,
                    IdPost = Convert.ToInt32(Job12.Text),
                    Phone = TxbLogin_Copy3.Text,

                };

                DbConnect.entObj.PhoneSprav.Add(SpravochnikObj);
                DbConnect.entObj.SaveChanges();

                MessageBox.Show("Результат добавлен в базу данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка работы приложения: " + ex.Message.ToString(), "Критический сбой работы приложения", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Spravochnik());
        }
    }
}
