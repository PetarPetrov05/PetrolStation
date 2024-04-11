using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace Petrol_Station_Libary
{
    public class Queries
    {
        public SqlConnection conn = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\VisualStudio\\Projects\\Petrol_Station\\Petrol_StationDB\\PetrolStationDB.mdf;Integrated Security=True;Connect Timeout=30");
        public Queries() 
        {
            
        }   
        public bool InsertDataDelivery(string name_,string mol,string address,string bulstat)
        {
            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Delivery (name_,mol,adress,bulstat) VALUES (N'{name_}', N'{mol}', N'{address}', N'{bulstat}') ", conn);
            try
            {
                conn.Open();
                sqlCommand.ExecuteNonQuery();
                conn.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public Dictionary<int, string> GetNamesForDelivery()
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT id,name_ FROM Delivery",conn);
            List<string> names = new List<string>();
            Dictionary<int,string> idAndNames = new Dictionary<int,string>();
            conn.Open() ;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                idAndNames.Add(int.Parse(reader[0].ToString()), reader[1].ToString());
            }
            conn.Close();
            return idAndNames;
        }
        public void InsertDeliveredGasData(string typeGas,string deliver, string quantity, string deliveryPrice, string where, string registerPlate, string driver)
        {
            SqlCommand testing = new SqlCommand($"SELECT quantity FROM AllDelivered where gasId = {where}", conn);
            double sum = 0;
            conn.Open();
            SqlDataReader reader = testing.ExecuteReader();
            while( reader.Read() )
            {
                sum+=(double.Parse(reader[0].ToString()));
            }
            conn.Close();
            sum += double.Parse(quantity) ;
            if (sum>=10000)//max capacity
            {
                return;
            }
            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO AllDelivered (gasId,deliveryId,quantity,gasTankId,registerPlate,driver,price) VALUES ({typeGas},{deliver},{quantity},{where},N'{registerPlate}',N'{driver}',{deliveryPrice})", conn);
            conn.Open();
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            SqlCommand sqlCommand2 = new SqlCommand($"UPDATE GasTank SET quantity +={quantity} where name_ = {where}", conn);
            conn.Open();
            sqlCommand2.ExecuteNonQuery();
            conn.Close();
        }
        public string WhichIdIsThisGas(string name)
        {
            string id = "";
            SqlCommand sqlCommand = new SqlCommand($"SELECT (id) FROM GAS where (type_ = N'{name.ToLower().Trim()}')", conn);
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while ( reader.Read() )
            {
                id = reader[0].ToString();
            }
            conn.Close();
            return id;
        }
        public Dictionary<int, List<string>> GetAllAccountData() 
        {
            Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
            
            SqlCommand sqlCommand = new SqlCommand($"SELECT Accounts.name_,Accounts.password_,Roles.role_ FROM Accounts JOIN Roles on Accounts.roleId = Roles.id", conn);
            
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sqlCommand);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            string name = dt.Rows[0][1].ToString();
            for (int i = 0; i < dt.Rows.Count;i++)
            {
                List<string> list = new List<string>();
                for (int y = 0; y< 3;y++)
                {
                    list.Add(dt.Rows[i][y].ToString());
                }
                dic.Add(i, list);
            }
            adapter.Dispose();
            conn.Close();
            return dic;
        }
        public void InsertCardInfo(string name,string phoneNum,string cardNum,string barcodePath)
        {
            SqlCommand sqlCommand = new SqlCommand($"INSERT INTO Cards (name_,phone_num,card_num,barcode_path) VALUES (N'{name}',N'{phoneNum}',N'{cardNum}',N'{barcodePath}')", conn);
            conn.Open();
            sqlCommand.ExecuteNonQuery();
            conn.Close();
        }
        public List<string> GetPricesForFuel(string typeFuel)
        {
            
            List<string> list = new List<string>();
            SqlCommand sqlCommand = new SqlCommand($"SELECT AllDelivered.price FROM AllDelivered Join Gas on AllDelivered.gasId = Gas.id join Delivery on AllDelivered.deliveryId = Delivery.id where Gas.type_ = N'{typeFuel}';", conn);
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }
            conn.Close();
            return list;
        }
        public List<string> GetAllCardNums()
        {
            List<string> list = new List<string>();
            SqlCommand sqlCommand = new SqlCommand("SELECT card_num from Cards;", conn);
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                list.Add(reader[0].ToString());
            }
            conn.Close();
            return list;
        }
        public double GetGasTankInfo(int where)
        {
            SqlCommand sqlCommand = new SqlCommand($"SELECT quantity from GasTank where name_ = {where}", conn);
            double sum = 0;
            conn.Open();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                sum+=double.Parse(reader[0].ToString());
            }
            conn.Close();
            return sum;
        }
        public void SellPetrol(int where ,double quantity,string date,double soldPrice,string type,int pump ,int kasierId)
        {
            SqlCommand sqlCommand = new SqlCommand($"UPDATE GasTank SET quantity -={quantity} where name_ = {where}", conn);
            conn.Open();
            sqlCommand.ExecuteNonQuery();
            conn.Close();
            sqlCommand = new SqlCommand($"INSERT INTO Sold_Gas (quantity,date_,sold_price,type_,pump,kasierId) VALUES ({quantity},'{date}',{soldPrice},N'{type}',{pump},{kasierId})", conn);
            conn.Open();
            sqlCommand.ExecuteNonQuery();
            conn.Close();
        }
    }
}
