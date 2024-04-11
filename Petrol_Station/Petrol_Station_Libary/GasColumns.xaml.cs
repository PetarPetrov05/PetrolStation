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

namespace Petrol_Station_Libary
{
    /// <summary>
    /// Interaction logic for GasColumns.xaml
    /// </summary>
    public partial class GasColumns : UserControl
    {
        public GasColumns()
        {
            InitializeComponent();
            RefreshPetrol();
        }
        public bool inCard4 = false;
        public bool inCard3 = false;
        public bool inCard2 = false;
        public bool inCard1 = false;
        Queries queries = new Queries();
        private void GridProgress1_MouseEnter(object sender, MouseEventArgs e)
        {
            ProgressPercents1.Visibility= Visibility.Visible;
        }

        private void GridProgress1_MouseLeave(object sender, MouseEventArgs e)
        {
            ProgressPercents1.Visibility = Visibility.Collapsed;
        }

        private void GridProgress2_MouseEnter(object sender, MouseEventArgs e)
        {
            ProgressPercents2.Visibility= Visibility.Visible;
        }

        private void GridProgress2_MouseLeave(object sender, MouseEventArgs e)
        {
            ProgressPercents2.Visibility= Visibility.Collapsed;
        }

        private void GridProgress3_MouseEnter(object sender, MouseEventArgs e)
        {
            ProgressPercents3.Visibility= Visibility.Visible;
        }

        private void GridProgress3_MouseLeave(object sender, MouseEventArgs e)
        {
            ProgressPercents3.Visibility = Visibility.Collapsed;
        }

        //---------------------------------------------------
        //4th
        //---------------------------------------------------
        private void CardButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SellingComp.Visibility = Visibility.Collapsed;
            BorderAfterCardClicked.Visibility = Visibility.Visible;
            inCard4=true;
        }

        private void BackButton_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inCard4 == true)
            {
                BorderAfterCardClicked.Visibility= Visibility.Collapsed;
                SellingComp.Visibility = Visibility.Visible;
                inCard4 = false;
            }else
            {
                AfterSellingPetrol.Visibility = Visibility.Collapsed;
                BeforeBuyingPetrol.Visibility= Visibility.Visible;
            }
        }

        private void Benzin4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel.Text = "Бензин";
            BeforeBuyingPetrol.Visibility = Visibility.Collapsed;
            AfterSellingPetrol.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("бензин");
            double sum = 0;
            for (int i = 0; i < listPrices.Count;i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum/listPrices.Count,2);
            PriceTextBlock4.Text = avg.ToString()+"лв";


        }

        private void Diesel4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel.Text = "Дизел";
            BeforeBuyingPetrol.Visibility = Visibility.Collapsed;
            AfterSellingPetrol.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("дизел");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock4.Text = avg.ToString() + "лв";
        }

        private void Gas4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel.Text = "Газ";
            BeforeBuyingPetrol.Visibility = Visibility.Collapsed;
            AfterSellingPetrol.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("газ");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock4.Text = avg.ToString() + "лв";
        }

        //---------------------------------------------------------------
        //3rd
        //---------------------------------------------------------------
        private void BackButton3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inCard3 == true)
            {
                BorderAfterCardClicked3.Visibility = Visibility.Collapsed;
                SellingComp3.Visibility = Visibility.Visible;
                inCard3 = false;
            }
            else
            {
                AfterSellingPetrol3.Visibility = Visibility.Collapsed;
                BeforeBuyingPetrol3.Visibility = Visibility.Visible;
            }
        }
        private void CardButton3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SellingComp3.Visibility = Visibility.Collapsed;
            BorderAfterCardClicked3.Visibility = Visibility.Visible;
            inCard3 = true;
        }

        private void Benzin3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel3.Text = "Бензин";
            BeforeBuyingPetrol3.Visibility = Visibility.Collapsed;
            AfterSellingPetrol3.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("бензин");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock3.Text = avg.ToString() + "лв";
        }

        private void Diesel3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel3.Text = "Дизел";
            BeforeBuyingPetrol3.Visibility = Visibility.Collapsed;
            AfterSellingPetrol3.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("дизел");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock3.Text = avg.ToString() + "лв";
        }

        private void Gas3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel3.Text = "Газ";
            BeforeBuyingPetrol3.Visibility = Visibility.Collapsed;
            AfterSellingPetrol3.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("газ");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock3.Text = avg.ToString() + "лв";
        }
        //---------------------------------------------------------------
        //1st
        //---------------------------------------------------------------
        private void BackButton1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inCard1 == true)
            {
                BorderAfterCardClicked1.Visibility = Visibility.Collapsed;
                SellingComp1.Visibility = Visibility.Visible;
                inCard1 = false;
            }
            else
            {
                AfterSellingPetrol1.Visibility = Visibility.Collapsed;
                BeforeBuyingPetrol1.Visibility = Visibility.Visible;
                MoneyImage1.Visibility = Visibility.Collapsed;
                arrow1.Visibility = Visibility.Visible;
            }
        }

        private void CardButton1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SellingComp1.Visibility = Visibility.Collapsed;
            BorderAfterCardClicked1.Visibility = Visibility.Visible;
            inCard1 = true;
        }

        private void Benzin1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel1.Text = "Бензин";
            BeforeBuyingPetrol1.Visibility = Visibility.Collapsed;
            AfterSellingPetrol1.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("бензин");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock1.Text = avg.ToString() + "лв";
        }

        private void Diesel1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel1.Text = "Дизел";
            BeforeBuyingPetrol1.Visibility = Visibility.Collapsed;
            AfterSellingPetrol1.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("дизел");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock1.Text = avg.ToString() + "лв";
        }

        private void Gas1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel1.Text = "Газ";
            BeforeBuyingPetrol1.Visibility = Visibility.Collapsed;
            AfterSellingPetrol1.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("газ");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock1.Text = avg.ToString() + "лв";
        }

        //---------------------------------------------------------------
        //2nd
        //---------------------------------------------------------------
        private void BackButton2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (inCard2 == true)
            {
                BorderAfterCardClicked2.Visibility = Visibility.Collapsed;
                SellingComp2.Visibility = Visibility.Visible;
                inCard2 = false;
            }
            else
            {
                AfterSellingPetrol2.Visibility = Visibility.Collapsed;
                BeforeBuyingPetrol2.Visibility = Visibility.Visible;
            }
        }

        private void CardButton2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            SellingComp2.Visibility = Visibility.Collapsed;
            BorderAfterCardClicked2.Visibility = Visibility.Visible;
            inCard2 = true;
        }

        private void Benzin2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel2.Text = "Бензин";
            BeforeBuyingPetrol2.Visibility = Visibility.Collapsed;
            AfterSellingPetrol2.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("бензин");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock2.Text = avg.ToString() + "лв";
        }

        private void Diesel2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel2.Text = "Дизел";
            BeforeBuyingPetrol2.Visibility = Visibility.Collapsed;
            AfterSellingPetrol2.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("дизел");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock2.Text = avg.ToString() + "лв";
        }

        private void Gas2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            GasTypeLabel2.Text = "Газ";
            BeforeBuyingPetrol2.Visibility = Visibility.Collapsed;
            AfterSellingPetrol2.Visibility = Visibility.Visible;
            List<string> listPrices = new List<string>();
            listPrices = queries.GetPricesForFuel("газ");
            double sum = 0;
            for (int i = 0; i < listPrices.Count; i++)
            {
                sum += double.Parse(listPrices[i]);
            }
            double avg = Math.Round(sum / listPrices.Count, 2);
            PriceTextBlock2.Text = avg.ToString() + "лв";
        }

        

        private void litriInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            //4
            if (litriInput.Text != null)
            {
                double input = 0;
                try
                {
                    input = double.Parse(litriInput.Text);
                    string price = "";
                    for (int i = 0; i < PriceTextBlock4.Text.Length - 2; i++)
                    {
                        price += PriceTextBlock4.Text[i];
                    }
                    double sum = input * double.Parse(price);
                    fuelPrice4.Text = Math.Round(sum,2).ToString();
                }
                catch
                {
                    //MessageBox.Show("Може да има само числа");
                }

            }
        }
        private void litriInput3_TextChanged(object sender, TextChangedEventArgs e)
        {
            //3
            if (litriInput3.Text != null)
            {
                double input = 0;
                try
                {
                    input = double.Parse(litriInput3.Text);
                    string price = "";
                    for (int i = 0; i < PriceTextBlock3.Text.Length - 2; i++)
                    {
                        price += PriceTextBlock3.Text[i];
                    }
                    double sum = input * double.Parse(price);
                    fuelPrice3.Text = Math.Round(sum, 2).ToString();
                }
                catch
                {
                    //MessageBox.Show("Може да има само числа");
                }

            }
        }
        
        private void litriInput2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (litriInput2.Text != null)
            {
                double input = 0;
                try
                {
                    input = double.Parse(litriInput2.Text);
                    string price = "";
                    for (int i = 0; i < PriceTextBlock2.Text.Length - 2; i++)
                    {
                        price += PriceTextBlock2.Text[i];
                    }
                    double sum = input * double.Parse(price);
                    fuelPrice2.Text = Math.Round(sum, 2).ToString();
                }
                catch
                {
                    //MessageBox.Show("Може да има само числа");
                }

            }
        }
        private void litriInput1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (litriInput1.Text != null)
            {
                double input = 0;
                try
                {
                    input = double.Parse(litriInput1.Text);
                    string price = "";
                    for (int i = 0; i < PriceTextBlock1.Text.Length - 2; i++)
                    {
                        price += PriceTextBlock1.Text[i];
                    }
                    double sum = input * double.Parse(price);
                    fuelPrice1.Text = Math.Round(sum, 2).ToString();
                }
                catch
                {
                    //MessageBox.Show("Може да има само числа");
                }

            }
        }
        //====================================================================================
        //check card
        //====================================================================================
      
        private void addDiscount1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<string> allCardNums = new List<string>();
            try
            {
                allCardNums = queries.GetAllCardNums();
                for (int i = 0; i < allCardNums.Count; i++)
                {
                    if (CardInput1.Text == allCardNums[i])
                    {
                        if (double.Parse(fuelPrice1.Text) != 0)
                        {
                            double num = (double.Parse(fuelPrice1.Text) / 100) * 5;
                            DiscountCard1.Text = Math.Round(num, 2).ToString();
                            MessageBox.Show("Успешно добавена отстъпка от 5%.");
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Моля заредете първо.");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неуспешно взимане на нформацията\nза всички карти");
            }
        }

        private void addDiscount2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<string> allCardNums = new List<string>();
            try
            {
                allCardNums = queries.GetAllCardNums();
                for (int i = 0; i < allCardNums.Count; i++)
                {
                    if (CardInput2.Text == allCardNums[i])
                    {
                        if (double.Parse(fuelPrice2.Text) != 0)
                        {
                            double num = (double.Parse(fuelPrice2.Text) / 100) * 5;
                            DiscountCard2.Text = Math.Round(num, 2).ToString();
                            MessageBox.Show("Успешно добавена отстъпка от 5%.");
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Моля заредете първо.");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неуспешно взимане на нформацията\nза всички карти");
            }
        }

        private void addDiscount3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<string> allCardNums = new List<string>();
            try
            {
                allCardNums = queries.GetAllCardNums();
                for (int i = 0; i < allCardNums.Count; i++)
                {
                    if (CardInput3.Text == allCardNums[i])
                    {
                        if (double.Parse(fuelPrice3.Text) != 0)
                        {
                            double num = (double.Parse(fuelPrice3.Text) / 100) * 5;
                            DiscountCard3.Text = Math.Round(num, 2).ToString();
                            MessageBox.Show("Успешно добавена отстъпка от 5%.");
                            break;

                        }
                        else
                        {
                            MessageBox.Show("Моля заредете първо.");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неуспешно взимане на нформацията\nза всички карти");
            }
        }
        private void addDiscount4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            List<string> allCardNums = new List<string>();
            try
            {
                allCardNums = queries.GetAllCardNums();
                for (int i = 0; i < allCardNums.Count; i++)
                {
                    if (CardInput.Text == allCardNums[i])
                    {
                        if (double.Parse(fuelPrice4.Text) != 0)
                        {
                            double num = (double.Parse(fuelPrice4.Text) / 100) * 5;
                            DiscountCard4.Text = Math.Round(num, 2).ToString();
                            MessageBox.Show("Успешно добавена отстъпка от 5%.");
                            break;

                        }else
                        {
                            MessageBox.Show("Моля заредете първо.");
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Неуспешно взимане на нформацията\nза всички карти");
            }

        }

        //selling 1
        private void border1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (MoneyImage1.Visibility == Visibility.Visible)
            {
                string gasType = GasTypeLabel1.Text;
                if (gasType == "Дизел")
                {
                    gasType = "1";
                }else if (gasType == "Бензин")
                {
                    gasType= "2";
                }else if (gasType == "Газ")
                {
                    gasType = "3";
                }
                double quantity = double.Parse(litriInput1.Text);
                DateTime dateTime = DateTime.Now;
                string year = dateTime.Year.ToString();
                string month = dateTime.Month.ToString();
                string day = dateTime.Day.ToString();
                string hour = dateTime.Hour.ToString();
                string minute = dateTime.Minute.ToString();
                string second = dateTime.Second.ToString();
                string finalTime = $"{year}-{month}-{day} {hour}:{minute}:{second}";
                string inputPrice = "";
                for (int i = 0;i< PriceTextBlock1.Text.Length-2;i++)
                {
                    inputPrice += PriceTextBlock1.Text[i];
                }
                double price = double.Parse(inputPrice);
                string petrolType = GasTypeLabel1.Text;
                queries.SellPetrol(int.Parse(gasType),quantity,finalTime,price,petrolType,1,1);
            }
            else
            {
                MoneyImage1.Visibility = Visibility.Visible;
                arrow1.Visibility = Visibility.Collapsed;
                double fuelPrice = double.Parse(fuelPrice1.Text);
                double discount = double.Parse(DiscountCard1.Text);
                double finalPrice = fuelPrice - discount;
                FinalPrice1.Text = Math.Round(finalPrice, 2).ToString();
            }
        }

        private void RefreshData_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            RefreshPetrol();
        }
        private void RefreshPetrol()
        {
            int benzin = 1;
            int diesel = 2;
            int gas = 3;
            double sumB = queries.GetGasTankInfo(benzin);
            double sumD = queries.GetGasTankInfo(diesel);
            double sumG = queries.GetGasTankInfo(gas);
            double percentageB = Math.Round(sumB / 10000 * 100, 2);
            double percentageD = Math.Round(sumD / 10000 * 100, 2);
            double percentageG = Math.Round(sumG / 10000 * 100, 2);
            ProgressBarDiesel.Value = percentageD;
            ProgressPercents1.Text = percentageD.ToString() + "%";
            ProgressBarBenzin.Value = percentageB;
            ProgressPercents2.Text = percentageB.ToString() + "%";
            ProgressBarGas.Value = percentageG;
            ProgressPercents3.Text = percentageG.ToString() + "%";
        }
    }
}
