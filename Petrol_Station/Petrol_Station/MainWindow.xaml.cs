using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Petrol_Station
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// API key for weather - 8824011ddd180c89d0b73bdaf1d8802b
    public partial class MainWindow : Window
    {
        int Ncount = 0;
        int Pcount = 0;
        bool Fullscreen = false;
        public Dictionary<string, string> dic = new Dictionary<string, string>();
        public MainWindow()
        {
            InitializeComponent();
            this.Icon = new BitmapImage(new Uri("D:\\Downloads\\images for GasStation\\Screenshot_2024-02-14_085013-removebg-preview.png"));

        }
        async Task Weather(HttpClient client)
        {
            try
            {
                var json = await client.GetStringAsync("https://api.openweathermap.org/data/2.5/weather?lat=43.20&lon=27.91&appid=8824011ddd180c89d0b73bdaf1d8802b&units=metric&mode=json");
                char[] chars = new char[2] { '{', '}' };
                string[] res = json.ToString().Split(chars);
                List<string> listRes = new List<string>();
                List<string> finalList = new List<string>();
                string workedInput = "";
                for (int i = 0; i < res.Length; i++)
                {
                    listRes.Add(res[i]);
                }
                for (int i = 0; i < listRes.Count; i++)
                {
                    finalList.Add("");
                    string input = "";
                    for (int y = 0; y < listRes[i].Length; y++)
                    {
                        if (listRes[i][y] != '"' && listRes[i][y] != '[' && listRes[i][y] != ']')
                        {
                            input += listRes[i][y];
                        }
                    }
                    workedInput += input;
                }
                string[] result = workedInput.Split(',');
                for (int i = 0; i < result.Length; i++)
                {
                    string[] structed = result[i].Split(':');
                    for (int y = 0; y < structed.Length; y++)
                    {
                        Console.WriteLine(structed[y]);
                        if (structed[y] == "weather")
                        {
                            dic.Add(structed[y + 1], structed[y + 2]);
                        }
                        else if (structed[y] == "description")
                        {
                            dic.Add("description", structed[y + 1]);
                        }
                        else if (structed[y] == "icon")
                        {
                            dic.Add("icon", structed[y + 1]);
                        }
                        else if (structed[y] == "temp")
                        {
                            dic.Add("temp", structed[y + 1]);
                        }
                        else if (structed[y] == "feels_like")
                        {
                            dic.Add("feels_like", structed[y + 1]);
                        }
                        else if (structed[y] == "temp_min")
                        {
                            dic.Add("temp_min", structed[y + 1]);
                        }
                        else if (structed[y] == "temp_max")
                        {
                            dic.Add("temp_max", structed[y + 1]);
                        }
                        else if (structed[y] == "name")
                        {
                            dic.Add("name", structed[y + 1]);
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Няма интернет и няма информацията за времето.");
            }
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void NameBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Ncount == 0 )
            {
                NameBox.Text = string.Empty;
                Ncount++;
            }
        }

        private void NameBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text.Length == 0)
            {
                NameBox.Text = "Име";
                Ncount = 0;
            }
        }

        private void PassBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Pcount == 0)
            {
                PassBox.Text = string.Empty;
                Pcount++;
            }
        }

        private void PassBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (PassBox.Text.Length == 0)
            {
                PassBox.Text = "Парола";
                Pcount = 0;
            }
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

        private void BorderLogIn_GotMouseCapture(object sender, MouseEventArgs e)
        {

        }

        private void ButtonSignIn_MouseEnter(object sender, MouseEventArgs e)
        {
            //ButtonSignIn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#2fc842"));
        }

        private async void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            
            // WindowStyle = WindowStyle.None;
            this.WindowStyle = WindowStyle.None;
            this.ShowInTaskbar = false;
            this.Height = 0; this.Width = 0;
            this.Hide();
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");

            await Weather(client);

            MainWindowNav mainNav = new MainWindowNav(dic);
            mainNav.Show();
        }
    }
}
