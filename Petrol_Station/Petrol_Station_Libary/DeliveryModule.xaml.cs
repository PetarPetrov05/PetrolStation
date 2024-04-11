using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Interaction logic for DeliveryModule.xaml
    /// </summary>
    public partial class DeliveryModule : UserControl
    {
  

        List<string> listOfTypeGas = new List<string>();
        List<string> leftWords = new List<string>();
        List<string> leftNames = new List<string>();
        Dictionary<int,string> idAndName= new Dictionary<int,string>();
        int keyOfSelectedName;
        Queries queries= new Queries();
        public DeliveryModule()
        {
           
            InitializeComponent();

            for (int i = 0; i < TypeGasInputComboBox.Items.Count; i++)
            {
                string[] res = TypeGasInputComboBox.Items[i].ToString().Split(':');
                listOfTypeGas.Add(res[0].Trim());

            }
            idAndName = queries.GetNamesForDelivery();
        }

        private void deliverButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           
            DeliveryModule1.Visibility = Visibility.Hidden;
            DeliverModule.Visibility = Visibility.Visible;
            BackButton.Visibility = Visibility.Visible;

        }
        public void MakeItVisible()
        {
            DeliveryModule1.Visibility = Visibility.Visible;
        }

        private void BackButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MakeItVisible();
            DeliverModule.Visibility=Visibility.Hidden;
            BackButton.Visibility = Visibility.Hidden;
            idAndName = queries.GetNamesForDelivery();
        }

        private void TypeGasInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*string input = TypeGasInput.Text;
            leftWords.Clear();
            if (!string.IsNullOrEmpty(input)) 
            {
                for (int i = 0; i < listOfTypeGas.Count;i++)
                {
                    if (listOfTypeGas[i].ToLower().Contains(input.ToLower().Trim()))
                    {
                        leftWords.Add(listOfTypeGas[i]);
                    }
                }
                TypeGasInputComboBox.Items.Clear();
                for (int i = 0; i< leftWords.Count;i++)
                {
                    TypeGasInputComboBox.Items.Add(leftWords[i]);
                }
                TypeGasInputComboBox.IsDropDownOpen= true;

            }*/
            
        }



        private void TypeGasInputComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = TypeGasInputComboBox.SelectedValue.ToString(); 
            TypeGasInput.Text = selectedItem;
            TypeGasInput.Text = selectedItem;
            /*string selectedItem = (string)DeliveryNameInputComboBox.SelectedItem;
            DeliveryNameInput.Text = selectedItem;
            DeliveryNameInput.Text = selectedItem;*/

        }

        private void DeliveryNameInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            string input = DeliveryNameInput.Text;
            if (!string.IsNullOrEmpty(input))
            {
                leftNames.Clear();
                List<int> keys = new List<int>();
                foreach (int key in idAndName.Keys)
                {
                    keys.Add(key);
                }
                for (int i = 0; i < idAndName.Count; i++)
                {
                    if (idAndName[keys[i]].ToLower().Contains(input.ToLower().Trim()))
                    {
                        if (!leftNames.Contains(idAndName[keys[i]]))
                        {
                            leftNames.Add(idAndName[keys[i]]);
                        }
                    }
                }
                DeliveryNameInputComboBox.Items.Clear();
                for (int i = 0; i < leftNames.Count; i++)
                {
                    DeliveryNameInputComboBox.Items.Add(leftNames[i]);
                }
                DeliveryNameInputComboBox.IsDropDownOpen = true;
            }
        }

        
        private void DeliveryNameInputComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedItem = (string)DeliveryNameInputComboBox.SelectedValue;
            if (selectedItem == null)
                return;
            DeliveryNameInput.Text = selectedItem;
            foreach (var value in idAndName)
            {
                if (value.Value.Equals(selectedItem))
                {
                    keyOfSelectedName = value.Key;
                }
            }
            
        }
        private void ToWhereInputComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string[] selectedItem = ToWhereInputComboBox.SelectedItem.ToString().Split(':',StringSplitOptions.RemoveEmptyEntries);
            string res = selectedItem[1].Trim();
            ToWhereInput.Text = res;
            ToWhereInput.Text = res;
        }
        private void DeliveryButtonAdd_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string typeGas = TypeGasInput.Text;
            string deliver = DeliveryNameInput.Text;
            string quantity = QuantityInput.Text;
            string deliveryPrice = PriceInput.Text;
            string where = ToWhereInput.Text[0].ToString();
            string registerPlate = RegisterPlateInput.Text;
            string driver = DriverNameInput.Text;


            typeGas = queries.WhichIdIsThisGas(typeGas);
            if (typeGas != where)
            {
                MessageBox.Show("Въвели сте грешна цистерна!");
                return;
            }
            deliver = keyOfSelectedName.ToString();
            try
            {
                queries.InsertDeliveredGasData(typeGas, deliver, quantity, deliveryPrice, where, registerPlate, driver);
                MessageBox.Show("Успешно приемане на гориво");
            }
            catch
            {
                MessageBox.Show("Неуспешно приемане на гориво");
            }
            
        }

        private void DeliveryNameInputComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            TypeGasInputComboBox.Items.Add("Бензин");
            TypeGasInputComboBox.Items.Add("Дизел");
            TypeGasInputComboBox.Items.Add("Газ");
        }
    }
}
