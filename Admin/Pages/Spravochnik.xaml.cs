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
    /// Логика взаимодействия для Spravochnik.xaml
    /// </summary>
    public partial class Spravochnik : Page
    {
        public Spravochnik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new DobavPhone());
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            var SpravForRemoving = DgrSprav.SelectedItems.Cast<PhoneSprav>().ToList();
            try
            {
                DbConnect.entObj.PhoneSprav.RemoveRange(SpravForRemoving);
                DbConnect.entObj.SaveChanges();
                MessageBox.Show("Данные удалены.");

                DgrSprav.ItemsSource = DbConnect.entObj.PhoneSprav.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Подтвердите удаление " + ex.Message.ToString(),
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Admin());
        }

        private void DgrSprav_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DgrSprav_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DgrSprav.ItemsSource = DbConnect.entObj.PhoneSprav.ToList();
            }
        }
    }
}
