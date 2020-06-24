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
    /// Interaction logic for ChanceCard.xaml
    /// </summary>
    public partial class ChanceCard : Window
    {
        public ChanceCard()
        {
            InitializeComponent();
        }

        private void BtnCardAction_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
