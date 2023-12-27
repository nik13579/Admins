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
    /// Логика взаимодействия для SpisokSotr.xaml
    /// </summary>
    public partial class SpisokSotr : Page
    {
        public SpisokSotr()
        {
            InitializeComponent();
        }

       

         private void button3_Click(object sender, RoutedEventArgs e)
         {
             FrameApp.frmObj.Navigate(new Admin());
         }

         private void Button2_Click(object sender, RoutedEventArgs e)
         {
             var SotrForRemoving = DgrSotr.SelectedItems.Cast<Personal>().ToList();
             try
             {
                 DbConnect.entObj.Personal.RemoveRange(SotrForRemoving);
                 DbConnect.entObj.SaveChanges();
                 MessageBox.Show("Данные удалены.");

                 DgrSotr.ItemsSource = DbConnect.entObj.Personal.ToList();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Подтвердите удаление " + ex.Message.ToString(),
                     "Уведомление",
                     MessageBoxButton.OK,
                     MessageBoxImage.Warning);

             }
         }

         private void button1_Click(object sender, RoutedEventArgs e)
         {
             FrameApp.frmObj.Navigate(new DobavSotr(null));
         }

        

        private void DgrSotr_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                DbConnect.entObj.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
                DgrSotr.ItemsSource = DbConnect.entObj.Personal.ToList();
            }
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DgrSotr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DgrSotr_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
