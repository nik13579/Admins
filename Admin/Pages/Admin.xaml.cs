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
    /// Логика взаимодействия для Admin.xaml
    /// </summary>
    public partial class Admin : Page
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void Btn_DoMen(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new DobavSotr(null));
        }

        private void Btn_DoMat(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Spravochnik());
        }

        private void Btn_ProsM(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new SpisokSotr());
        }

        private void Btn_Viti(object sender, RoutedEventArgs e)
        {
            FrameApp.frmObj.Navigate(new Auth());
        }
    }
}
