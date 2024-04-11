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
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;

namespace Petrol_Station_Libary
{
    /// <summary>
    /// Interaction logic for AccountsModule.xaml
    /// </summary>
    public partial class AccountsModule : UserControl
    {
        Queries queries = new Queries();
        public AccountsModule()
        {
            InitializeComponent();
        }
        public class MyData
        {
            public string Name { get; set; }
            public string Role { get; set; }
            public string Password { get; set; }
        }

        private void AddAccount_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        public void GetAccountsData()
        {
            Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
            dic = queries.GetAllAccountData();
            ObservableCollection<MyData> dataList = new ObservableCollection<MyData>();
            
            for (int i = 0; i< dic.Count;i++)
            {
                string role = dic[i][1];
                dataList.Add(new MyData { Name = dic[i][0], Role = dic[i][1],Password = dic[i][2] });
            }
            DataGridAccounts.ItemsSource = dataList;
        }
    }
}
