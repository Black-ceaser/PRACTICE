using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace assignment
{
    public partial class Calculations : Form
    {
        double singleStoreTotalSalesaftx, singleStoreWeeklySalesaftx, singleStoreMonthlySalesaftx;
        double allStoresTotalSalesaftx, allStoresWeeklySalesaftx, allStoresMonthlySalesaftx;
        List<Order> orderz;
        double totalCost;

        // Variables
        double singleStoreTotalSales, singleStoreWeeklySales, singleStoreMonthlySales;
        double allStoresTotalSales, allStoresWeeklySales, allStoresMonthlySales;

        public Calculations(double costTotal, List<Order> orders)
        {
            InitializeComponent();
            allStoresTotalSales = costTotal;
            orderz = orders;
        }

        private  void button5_Click(object sender, EventArgs e)
        {
            allStoresMonthlySales = 0;

            var _storeBrief = orderz.Select(a => new
            {
                weeknum = a.Date.week,
                costT = a.Cost
            }).ToList();



            if (cmbweek.SelectedItem != null)
            {


                var _str = _storeBrief.Where(b => b.weeknum.Equals(cmbweek.SelectedItem)).Select(a => new { costT = a.costT });
                foreach (var costs in _str)
                {
                    allStoresMonthlySales += costs.costT;
                }
                lblAllMonthlySales.Text = Convert.ToString(totalCost);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            singleStoreMonthlySales = 0;
        }
        private void btnAllSales_Click(object sender, EventArgs e)
        {
            lblCostTotal.Text = Convert.ToString(allStoresTotalSales);
            
        }

        private void btnSingleStoreSale_Click(object sender, EventArgs e)
        {
            singleStoreTotalSales = 0;
            var _bind2 = orderz.Select(a => new
            {
                storeCode = a.Store.StoreCode,
            }).Distinct().ToList();

            var _singleStoreTotal = orderz.Select(a => new
            {
                costT = a.Cost
            }).ToList();

            var _storeBrief = orderz.Select(a => new
            {
                storeCode = a.Store.StoreCode,
                costT = a.Cost
            }).ToList();

            foreach (var items in _bind2)
            {
                cmbAllStores.Items.Add(items.storeCode);
            }

            cmbAllStores.SelectedIndexChanged += new System.EventHandler(StoresSelectedIndexChange);
            

        }

       
        private void StoresSelectedIndexChange(object sender, System.EventArgs e)
        {
            singleStoreTotalSales = 0;
            var _storeBrief = orderz.Select(a => new
            {
                storeCode = a.Store.StoreCode,
                costT = a.Cost
            }).ToList();

           

            if (cmbAllStores.SelectedItem != null)
            {
      
                
               var _str = _storeBrief.Where(b => b.storeCode == cmbAllStores.SelectedItem).Select(a => new { costT = a.costT });
                foreach (var costs in _str)
                {
                    singleStoreTotalSales += costs.costT;
                }
                lblSingleTotal.Text = Convert.ToString(singleStoreTotalSales);
            }
        }

        private void WeeklySalesSelectedIndexChange(object sender, System.EventArgs e)
        {
            allStoresWeeklySales = 0;

            var _storeBrief = orderz.Select(a => new
            {
                weeknum = a.Date.week,
                costT = a.Cost
            }).ToList();



            if (cmbweek.SelectedItem != null)
            {


                var _str = _storeBrief.Where(b => b.weeknum.Equals(cmbweek.SelectedItem)).Select(a => new { costT = a.costT });
                foreach (var costs in _str)
                {
                    allStoresWeeklySales += costs.costT;
                }
                lblWeekSales.Text = Convert.ToString(allStoresWeeklySales);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var _bind2 = orderz.Select(a => new
            {
                weeknum = a.Date.week
            }).Distinct().ToList();
            foreach (var items in _bind2)
            {
                cmbweek.Items.Add(items.weeknum);
            }
            cmbweek.SelectedIndexChanged += new System.EventHandler(WeeklySalesSelectedIndexChange);
        }

        private void Calculations_Load(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            singleStoreMonthlySalesaftx = singleStoreMonthlySales - (singleStoreMonthlySales * 0.2);
            lblSingleStoreMonthlySaleaftx.Text = Convert.ToString(singleStoreMonthlySalesaftx);
        }

        private void cmbAllStores_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            singleStoreWeeklySales = 0;
            var _bind3 = orderz.Select(a => new
            {
                storeCode = a.Store.StoreCode,
            }).Distinct().ToList();


            var _storeBrief = orderz.Select(a => new
            {
                
                storeCode = a.Store.StoreCode,
                costT = a.Cost,
                weeknum = a.Date.week
            }).ToList();

            foreach (var items in _bind3)
            {
                cmbstore.Items.Add(items.storeCode);
            }

            cmbstore.SelectedIndexChanged += new System.EventHandler(StoresSelectedIndexChange);


            var _bind2 = orderz.Select(a => new
            {
                weeknum = a.Date.week
            }).Distinct().ToList();
            foreach (var items in _bind2)
            {
                cmbsingWeek.Items.Add(items.weeknum);
            }
            cmbsingWeek.SelectedIndexChanged += new System.EventHandler(SingleWeeklySalesSelectedIndexChange);
            cmbstore.SelectedIndexChanged += new System.EventHandler(SingleWeeklySalesSelectedIndexChange);

        }

        private void SingleWeeklySalesSelectedIndexChange(object sender, System.EventArgs e)
        {
            singleStoreWeeklySales = 0;



            var _storeBrief = orderz.Select(a => new
            {
                storeCode = a.Store.StoreCode,
                weeknum = a.Date.week,
                costT = a.Cost
            }).ToList();



            if (cmbsingWeek.SelectedItem != null && cmbstore.SelectedItem != null)
            {


                var _str = _storeBrief.Where(b => b.weeknum.Equals(cmbsingWeek.SelectedItem) && b.storeCode.Equals(cmbstore.SelectedItem)).Select(a => new { costT = a.costT });
                foreach (var costs in _str)
                {
                    singleStoreWeeklySales += costs.costT;
                }
                lblSingleWeekly.Text = Convert.ToString(singleStoreWeeklySales);
            }
        }

        private void btnAllSalesaftx_Click(object sender, EventArgs e)
        {
            allStoresTotalSalesaftx = allStoresTotalSales - (allStoresTotalSales * 0.2);
            lblAllStoresTotalSalesaftx.Text = Convert.ToString(allStoresTotalSalesaftx);
        }

        private void btnSingleStoreSaleaftx_Click(object sender, EventArgs e)
        {

           singleStoreTotalSalesaftx = singleStoreTotalSales  - (singleStoreTotalSales * 0.2);
            lblSingleStoreTotalaftx.Text = Convert.ToString(singleStoreTotalSalesaftx);

            totalCost = 0;
            var _bind2aftx = orderz.Select(a => new
            {
                storeCode = a.Store.StoreCode,
            }).Distinct().ToList();

            var _singleStoreTotalaftx = orderz.Select(a => new
            {
                costT = a.Cost
            }).ToList();

            var _storeBrief = orderz.Select(a => new
            {
                storeCode = a.Store.StoreCode,
                costT = a.Cost
            }).ToList();

            foreach (var itemstx in _bind2aftx)
            {
                cmbAllStoresaftx.Items.Add(itemstx.storeCode);
            }

            cmbAllStoresaftx.SelectedIndexChanged += new System.EventHandler(StoresSelectedIndexChange);


        }

        private void button7_Click(object sender, EventArgs e)
        {
            allStoresWeeklySalesaftx = allStoresWeeklySales - (allStoresWeeklySales * 0.2);
            lblAllStoresWeeklySalesaftx.Text = Convert.ToString(allStoresWeeklySalesaftx);

            var _bind2tx= orderz.Select(a => new
            {
                weeknum = a.Date.week
            }).Distinct().ToList();
            foreach (var items in _bind2tx)
            {
                cmbweekaftx.Items.Add(items.weeknum);
            }
            cmbweekaftx.SelectedIndexChanged += new System.EventHandler(WeeklySalesSelectedIndexChange);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            singleStoreWeeklySalesaftx = singleStoreWeeklySales - (singleStoreWeeklySales * 0.2);
            lblSingleStoreWeeklySalesaftx.Text = Convert.ToString(singleStoreWeeklySalesaftx);

            totalCost = 0;
            var _bind3tx = orderz.Select(a => new
            {
                storeCode = a.Store.StoreCode,
            }).Distinct().ToList();


            var _storeBrief = orderz.Select(a => new
            {

                storeCode = a.Store.StoreCode,
                costT = a.Cost,
                weeknum = a.Date.week
            }).ToList();

            foreach (var items in _bind3tx)
            {
                cmbstoreaftx.Items.Add(items.storeCode);
            }

            cmbstoreaftx.SelectedIndexChanged += new System.EventHandler(StoresSelectedIndexChange);


            var _bind2tx = orderz.Select(a => new
            {
                weeknum = a.Date.week
            }).Distinct().ToList();
            foreach (var items in _bind2tx)
            {
                cmbsingWeekaftx.Items.Add(items.weeknum);
            }
            cmbsingWeekaftx.SelectedIndexChanged += new System.EventHandler(SingleWeeklySalesSelectedIndexChange);
            cmbstoreaftx.SelectedIndexChanged += new System.EventHandler(SingleWeeklySalesSelectedIndexChange);

        }

        private void button9_Click(object sender, EventArgs e)
        {

            allStoresMonthlySalesaftx = allStoresMonthlySales - (allStoresMonthlySales * 0.2);
            lblAllStoresMonthlySalesaftx.Text = Convert.ToString(allStoresMonthlySalesaftx);

            totalCost = 0;

            var _storeBrief = orderz.Select(a => new
            {
                weeknum = a.Date.week,
                costT = a.Cost
            }).ToList();



            if (cmbweek.SelectedItem != null)
            {


                var _str = _storeBrief.Where(b => b.weeknum.Equals(cmbweek.SelectedItem)).Select(a => new { costT = a.costT });
                foreach (var costs in _str)
                {
                    totalCost += costs.costT;
                }
                lblAllMonthlySales.Text = Convert.ToString(totalCost);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
