using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
using System.Windows.Threading;
using Petrol_Station;
using Petrol_Station_Libary;

namespace Petrol_Station
{
    public partial class MainWindowNav : Window
    {
        public Dictionary<string,string> dic = new Dictionary<string, string>();
        bool Fullscreen = false;
        private DispatcherTimer timer;
        Queries queries = new Queries();
        public MainWindowNav(Dictionary<string, string> dic)
        {
            MainWindow mn = new MainWindow();
            InitializeComponent();
            
            WeatherInfo(dic);
            this.dic = dic;
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Update every second
            timer.Tick += Timer_Tick;

            // Start the timer
            timer.Start();
            this.Icon = new BitmapImage(new Uri("D:\\Downloads\\images for GasStation\\Screenshot_2024-02-14_085013-removebg-preview.png"));
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the TextBlock with the current time
            clockTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void WeatherInfo(Dictionary<string, string> dic)
        {
            try
            {
                string whichImage = dic["icon"][0].ToString() + dic["icon"][1].ToString() + dic["icon"][2].ToString();
                Image weatherImage = new Image();
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri(@$"D:\Downloads\images for GasStation\images for weather\{whichImage}@2x.png");
                bitmapImage.EndInit();
                weatherImage.Source = bitmapImage;
                GridWeatherImage.Children.Add(weatherImage);
                Grid.SetRow(weatherImage, 0);
                double temp1 = double.Parse(dic["temp"]);
                double temp = Math.Round(temp1,0);
                Celsius.Text = temp.ToString()+ "°C";
                double feelsLike = double.Parse( dic["feels_like"]);
                Feels_like.Text = $"Feels: {feelsLike:F1}°C";
                Type.Text = dic["description"];
            }
            catch { }
        }
        
        private void MaxButon_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = Fullscreen ? WindowState.Normal : WindowState.Maximized;
            Fullscreen = !Fullscreen;
            if (this.WindowState == WindowState.Maximized)
            {
                MainGrid.Height = 880;
            }
            else if (this.WindowState == WindowState.Normal)
            {
                MainGrid.Height = 600;
            }

        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MinButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void GridDelivery_MouseEnter(object sender, MouseEventArgs e)
        {
            GridDelivery.Background.Opacity = 0.2;

        }

        private void GridDelivery_MouseLeave(object sender, MouseEventArgs e)
        {
            GridDelivery.Background.Opacity = 0;
        }
        private void GridDelivery_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasColumns.Visibility = Visibility.Hidden;
            DeliveryModule.Visibility = Visibility.Visible;
            CardsModule.Visibility = Visibility.Hidden;
            AccountsModule.Visibility = Visibility.Hidden;
        }

        private void GridSum_MouseEnter(object sender, MouseEventArgs e)
        {
            GridSum.Background.Opacity = 0.2;
        }

        private void GridSum_MouseLeave(object sender, MouseEventArgs e)
        {
            GridSum.Background.Opacity = 0;
        }
        private void GridSum_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DeliveryModule.Visibility = Visibility.Hidden;
            GasColumns.Visibility = Visibility.Hidden;
            CardsModule.Visibility = Visibility.Hidden;
            AccountsModule.Visibility = Visibility.Hidden;
        }
        private void GridGasCol_MouseEnter(object sender, MouseEventArgs e)
        {
            GridGasCol.Background.Opacity = 0.2;
        }

        private void GridGasCol_MouseLeave(object sender, MouseEventArgs e)
        {
            GridGasCol.Background.Opacity = 0;
        }
        private void GridGasCol_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DeliveryModule.Visibility = Visibility.Hidden;
            CardsModule.Visibility = Visibility.Hidden;
            GasColumns.Visibility = Visibility.Visible;
            AccountsModule.Visibility = Visibility.Hidden;
        }
        private void GridAccounts_MouseEnter(object sender, MouseEventArgs e)
        {
            GridAccounts.Background.Opacity = 0.2;
        }

        private void GridAccounts_MouseLeave(object sender, MouseEventArgs e)
        {
            GridAccounts.Background.Opacity = 0;
        }
        private void GridAccounts_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasColumns.Visibility = Visibility.Hidden;
            DeliveryModule.Visibility = Visibility.Hidden;
            AccountsModule.Visibility = Visibility.Visible;
            CardsModule.Visibility = Visibility.Hidden;

            AccountsModule.GetAccountsData();
        }

        private void GridCards_MouseEnter(object sender, MouseEventArgs e)
        {
            GridCards.Background.Opacity = 0.2;
        }

        private void GridCards_MouseLeave(object sender, MouseEventArgs e)
        {
            GridCards.Background.Opacity = 0;
        }
        private void GridCards_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasColumns.Visibility = Visibility.Hidden;
            DeliveryModule.Visibility = Visibility.Hidden;
            AccountsModule.Visibility = Visibility.Hidden;
            CardsModule.Visibility = Visibility.Visible;

        }
        

        
    }
}
