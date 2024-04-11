using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace Petrol_Station_Libary
{
    /// <summary>
    /// Interaction logic for DeliverModule.xaml
    /// </summary>
    public partial class DeliverModule : UserControl
    {
        
        public DeliverModule()
        {
            InitializeComponent();
        }
        string name = "";
        string mol = "";
        string address = "";
        string bul = "";


        private void BackButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DeliverModule1.Visibility = Visibility.Hidden;
        }

        private void DeliveryButtonAdd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (NameInput.Text != "")
                name = NameInput.Text;
            else
                MessageBox.Show("Моля попълнете полето за име!");
            if (MolInput.Text != "")
                mol = MolInput.Text;
            else
                MessageBox.Show("Моля попълнете полето за МОЛ!");
            if (AddressInput.Text != "")
                address = AddressInput.Text;
            else
                MessageBox.Show("Моля попълнете полето за адрес!");
            if (BulstatInput.Text != "")
                bul = BulstatInput.Text;
            else
                MessageBox.Show("Моля попълнете полето за Булстат!");
            Queries queries = new Queries();
            bool result = queries.InsertDataDelivery(name,mol,address,bul);
            if (!result)
                MessageBox.Show("Грешна заявка!!!");
            else
                MessageBox.Show("Успешно запазено!");
        }
    }
}
