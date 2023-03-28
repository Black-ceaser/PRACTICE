using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace assignment
{
    public partial class Form1 : Form
    {
        double costTotal;
        static string folderPath = "StoreData";
        static string storeCodesfile = "StoreCodes.csv";
        static string storeDataFolder = "StoreData";

        Dictionary<string, Store> stores = new Dictionary<string, Store>();
        HashSet<Date> dates = new HashSet<Date>();
        public List<Order> orders = new List<Order>();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            string storeCodesFilePath = Directory.GetCurrentDirectory() + @"\" + folderPath + @"\" + storeCodesfile;
            string[] storeCodeData = File.ReadAllLines(storeCodesFilePath);
            foreach (var storeData in storeCodeData)
            {
                string[] storeDataSplit = storeData.Split(',');
                Store store = new Store { StoreCode = storeDataSplit[0], StoreLocation = storeDataSplit[1] };
                if (!stores.ContainsKey(store.StoreCode))
                    stores.Add(store.StoreCode, store);
            }

            string[] fileNames = Directory.GetFiles(folderPath + @"\" + storeDataFolder);
            foreach (var filePath in fileNames)
            {
                string fileNameExt = Path.GetFileName(filePath);
                string fileName = Path.GetFileNameWithoutExtension(filePath);

                string[] fileNameSplit = fileName.Split('_');
                Store store = stores[fileNameSplit[0]];
                Date date = new Date
                {
                    week = Convert.ToInt32(fileNameSplit[1]),
                    year = Convert.ToInt32(fileNameSplit[2])
                };
                dates.Add(date);


                string[] orderData = File.ReadAllLines(folderPath + @"\" + storeDataFolder + @"\" + fileNameExt);
                foreach (var orderInfo in orderData)
                {
                    string[] orderSplit = orderInfo.Split(',');
                    Order order = new Order
                    {
                        Store = store,
                        Date = date,
                        SupplierName = orderSplit[0],
                        SupplierType = orderSplit[1],
                        Cost = Convert.ToDouble(orderSplit[2])
                    };
                    costTotal += Convert.ToDouble(orderSplit[2]);
                  //  allStores = store;

                    orders.Add(order);
                }





                var _bind2 = orders.Select(a => new
                {
                    storeCode = a.Store.StoreCode,
                    storeLoc = a.Store.StoreLocation,
                    weeknum = a.Date.week,
                    yearnum = a.Date.year,
                    supplierN = a.SupplierName,
                    supplierT = a.SupplierType,
                    costT = a.Cost

                }).ToList();
                dgvData.DataSource = _bind2;

            }

        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculations frmCalc = new Calculations(costTotal,orders);
            frmCalc.ShowDialog();
            
        }
    }

}
