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
using System.Windows.Shapes;

namespace Monopoly
{
    /// <summary>
    /// Interaction logic for RailRoadCard.xaml
    /// </summary>
    public partial class RailRoadCard : Window
    {
        public RailRoadCard()
        {
            InitializeComponent();
        }

        private void BtnDone_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnPay_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            w.BtnPay_Click(sender, e);
            this.Close();
        }

        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            MainWindow w = (MainWindow)Application.Current.MainWindow;
            w.BtnBuy_Click(sender, e);
            this.Close();
        }
    }
}
