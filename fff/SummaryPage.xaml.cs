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
using SQLite.Net;
using System.Data;

namespace fff
{
    /// <summary>
    /// Logika interakcji dla klasy SummaryPage.xaml
    /// </summary>
    public partial class SummaryPage : Page
    {
        public List<vwFinal> sumList;
        public vwFinal selectedSumm;
        public vwFlow2 selectedSummDet;

        public List<vwPivot> saleList;

        public List<vwSales> pivotList;

        public SummaryPage()
        {
            InitializeComponent();

            using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
            {
                sumList = db.Table<vwFinal>().OrderBy(x=>x.BuyerName).ToList();
              //  pivotList = db.Table<vwSales>().ToList();
               // saleList = db.Table<vwPivot>().ToList();
            }



            lstSummary.DataContext = sumList;
         
     

        }

        private void lstSummary_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtgPivot.DataContext = null;
            dtgPivot.Visibility = Visibility.Collapsed;
            lstSummDetails.Visibility = Visibility.Visible;
            selectedSumm = (vwFinal)lstSummary.SelectedItem;
            using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
            {
               lstSummDetails.DataContext = db.Table<vwFlow2>().Where(x => x.BuyerID == selectedSumm.BuyerID && x.PayerID == selectedSumm.PayerID || x.PayerID == selectedSumm.BuyerID && x.BuyerID == selectedSumm.PayerID).OrderBy(x => x.EventName).ToList();
            }
        }

        private void lstSummDetails_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            selectedSummDet = (vwFlow2)lstSummDetails.SelectedItem;

            if (selectedSummDet != null)
            {
                dtgPivot.Visibility = Visibility.Visible;

                using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {
                    pivotList = db.Table<vwSales>().Where(x => x.EventID == selectedSummDet.EventID).ToList();
                    saleList = db.Table<vwPivot>().Where(x => x.EventID == selectedSummDet.EventID).ToList();
                }



                var buyerlist = pivotList.Select(x => x.BuyerName).Distinct();
                var query = from r in pivotList
                            group r by r.SaleID into nameGroup
                            select new
                            {
                                Name = nameGroup.Key,
                                Values = from lang in buyerlist
                                         join ng in nameGroup
                                              on lang equals ng.BuyerName into languageGroup
                                         select new
                                         {
                                             Column = lang,
                                             Value = languageGroup.Any() ?
                                                     languageGroup.First().Price : null
                                         }
                            };


                var q = (from qr in query
                         join sl in saleList on qr.Name equals sl.SaleID.ToString()
                         select new
                         {
                             qr.Name
                            ,
                             sl.Description
                              ,
                             sl.Settled
                              ,
                             sl.PayerName
                            ,
                             qr.Values
                         }).ToList();

                DataTable piv = new DataTable();
                piv.Columns.Add("Płatnik");
                piv.Columns.Add("Wydatek");
                piv.Columns.Add("Rozliczone");

                foreach (var buyer in buyerlist)
                    piv.Columns.Add(buyer);

                foreach (var key in q)
                {
                    var row = piv.NewRow();
                    var items = key.Values.Select(v => v.Value).ToList(); // data for columns
                    items.InsertRange(0, new List<string>() { key.PayerName, key.Description, key.Settled.ToString() }); // data for first column
                    row.ItemArray = items.ToArray();
                    piv.Rows.Add(row);
                }

                dtgPivot.DataContext = piv.DefaultView;
            }


        }
    }
}