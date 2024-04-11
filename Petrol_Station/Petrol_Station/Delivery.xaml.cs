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

namespace Petrol_Station
{
    /// <summary>
    /// Interaction logic for Delivery.xaml
    /// </summary>
    public partial class Delivery : Window
    {
        Dictionary<string, string> dic = new Dictionary<string, string>();
        bool Fullscreen = false;
        public Delivery(Dictionary<string, string> dic)
        {
            InitializeComponent();
            this.dic = dic;
        }

        private void MaxButon_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = Fullscreen ? WindowState.Normal : WindowState.Maximized;
            Fullscreen = !Fullscreen;

        }



        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void BackButton_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            MainWindowNav nav = new MainWindowNav(dic);
            nav.Show();
            this.Close();
        }
    }
}
