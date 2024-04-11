using System;
using System.Collections.Generic;
using System.Drawing;
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
using IronBarCode;

namespace Petrol_Station_Libary
{
    /// <summary>
    /// Interaction logic for CardsComponent.xaml
    /// </summary>
    public partial class CardsComponent : UserControl
    {
        Queries queries = new Queries();
        public CardsComponent()
        {
            InitializeComponent();
        }
        string barcodePath = "";
        
        private void GenerateCode1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void GenerateBarcode_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Random rnd = new Random();
            int random = rnd.Next();
            string generateCode = random.ToString();
            GenerateCode.Text = generateCode;
            barcodePath = "D:\\VisualStudio\\Projects\\Petrol_Station\\Petrol_Station\\bin\\Debug\\net6.0-windows\\";
            GeneratedBarcode myBarcode = IronBarCode.BarcodeWriter.CreateBarcode($"{generateCode}", BarcodeWriterEncoding.Code128);
            myBarcode.SaveAsPng($"{generateCode}.png");
            barcodePath = barcodePath + generateCode + ".png";
            BarcodeImage.Source = new BitmapImage(new Uri(barcodePath));
            GenerateBarcode.Visibility = Visibility.Hidden;
            GridBarcodeImage.Visibility = Visibility.Visible;
        }

        private void ButtonInsertCardInfo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string name = "";
            string phoneNumber = "";
            string generateCode = "";
            if (Name.Text != "")
                name = Name.Text;
            else
                MessageBox.Show("Моля попълнете полето за имена!");
            if (PhoneNumber.Text != "")
                phoneNumber = PhoneNumber.Text;
            else
                MessageBox.Show("Моля попълнете полето за номера!");
            generateCode = GenerateCode.Text;
            try
            {
                queries.InsertCardInfo(name, phoneNumber, generateCode, barcodePath);
                MessageBox.Show("Успешно добавена карта");

            }
            catch
            {
                MessageBox.Show("Неуспешно добавена карта");
            }
            GenerateBarcode.Visibility = Visibility.Visible;
            GridBarcodeImage.Visibility = Visibility.Hidden;

        }
    }
}
