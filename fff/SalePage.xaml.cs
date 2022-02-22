using System;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;
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
using System.Collections.ObjectModel;

namespace fff
{
    /// <summary>
    /// Logika interakcji dla klasy SalePage.xaml
    /// </summary>
    public partial class SalePage : Page
    {

        public List<Sales> listSales;

        public ObservableCollection<Sales> listSales2;

        public List<Persons> listPerson;

        public List<Currencies> listCurrency1;
        public List<Currencies> listCurrency2;

        public Sales newSale;

        public Events passedEvent;

        public Persons payer;


        public List<SaleBuyers> listSaleDetails;

        public List<SaleBuyers> listSaleDetailsAll;

        public Currencies selectedCurrency;

        public List<Persons> listBuyers;

        public List<SaleBuyers> listSaleBuyers;
        public SaleBuyers newSaleBuyer;

        public Sales selectedSale;


        public string calcString;


        public string chooseperson;
        public string fillexpense;
        public string fillprice;
        public string decimalformat;
        public string choosepayer;
        public string wrongstring;
        public int pos;

        public void FillMessages()
        {
            chooseperson = fff.Properties.Resources.PersonChoose;
            fillexpense = fff.Properties.Resources.ExpenseFill;
            fillprice = fff.Properties.Resources.PriceFill;
            decimalformat = fff.Properties.Resources.DecimalOnly;
            choosepayer = fff.Properties.Resources.PayerChoose;
            wrongstring = fff.Properties.Resources.StringWrong;
        }


        public SalePage(Events passEvent)
        {
            InitializeComponent();
            FillMessages();

            passedEvent = passEvent;

            using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
            {


                


                listSales = db.GetAllWithChildren<Sales>(recursive: true).Where(x => x.EventID == passedEvent.EventID).OrderByDescending(x => x.SaleID).ToList();
                listCurrency1 = db.Table<Currencies>().Where(x=>x.CurrencyID == passedEvent.DefaultCurrency).ToList();
                listCurrency2 = db.Table<Currencies>().Where(x => x.CurrencyID != passedEvent.DefaultCurrency).ToList();

                listPerson = db.Query<Persons>("select p.* from EventsPersons ep inner join Events e on ep.EventID = e.EventID inner join Persons p on ep.PersonID = p.PersonID and p.Status = 0 WHERE ep.EventID=?", passEvent.EventID).ToList();


            }

            /*
            var listCurrencySorted =
                 (from curr in listCurrency
                  where curr.CurrencyID == passedEvent.DefaultCurrency
                  select new { CurrencyID = curr.CurrencyID, CurrencyName = curr.CurrencyName , CurrencyValue = curr.CurrencyValue}).ToList().Union
                   (from curr in listCurrency
                    where curr.CurrencyID != passedEvent.DefaultCurrency
                    select new { CurrencyID = curr.CurrencyID, CurrencyName = curr.CurrencyName, CurrencyValue = curr.CurrencyValue }).ToList();

    */


            listCurrency1.AddRange(listCurrency2);

         


            if (passedEvent.Solo == 1)
            {
                cmbPayer.Visibility = Visibility.Collapsed;
                lstBuyers.Visibility = Visibility.Collapsed;
                txbBuyers.Visibility = Visibility.Collapsed;
                txbPayer.Visibility = Visibility.Collapsed;
                chkAll.Visibility = Visibility.Collapsed;
            }




            listSales2 = new ObservableCollection<Sales>(listSales);

            txbEventTitle.DataContext = passEvent.FullName;
            lstSaleDetails.DataContext = listSales2.OrderByDescending(x => x.SaleID);
            cmbPayer.DataContext = listPerson;
            lstBuyers.DataContext = listPerson;
    

            txbSumSale.DataContext = listSales2.Sum(x => x.Price).ToString();


       

            btnSaleCuurency.Content = listCurrency1[0].CurrencyName;

            pos = 0;
            selectedCurrency = listCurrency1[pos];


        }


        private void chkAll_Checked(object sender, RoutedEventArgs e)
        {
            if (lstBuyers != null) lstBuyers.SelectAll();
        }

        private void chkAll_Unchecked(object sender, RoutedEventArgs e)
        {

            if (lstBuyers != null) lstBuyers.UnselectAll();

        }

        private void lstSaleDetails_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ListViewItem item = lstSaleDetails.ItemContainerGenerator.ContainerFromItem(lstSaleDetails.SelectedItem) as ListViewItem;





            if (item != null)

            {

                if (item.Height == 68)
                {

                    item.Height = 34;
                }


                else if (item.Height != 34)
                {
                    item.Height = 68;
                }


                else if (item.Height == 34)
                {
                    item.Height = 68;
                }

            }
        }

        private void removeSale_Click(object sender, RoutedEventArgs e)
        {
            selectedSale = (Sales)lstSaleDetails.SelectedItem;
            if (selectedSale != null)
            {



                using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {
                    //db.Execute("delete from SaleBuyers where SaleID=?", selectedSale.SaleID);

                    db.Execute("PRAGMA foreign_keys=ON");
                    db.Delete(selectedSale);

                }
                listSales2.Remove(selectedSale);
                lstSaleDetails.DataContext = listSales2.OrderByDescending(x => x.SaleID);
                txbSumSale.DataContext = listSales2.Sum(x => x.Price).ToString();
                // MessageBox.Show("Deleted");

            }

            else
            {

                MessageBox.Show(chooseperson);

            }
        }



        private void txtCalc_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Add || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9 || e.Key == Key.Back || e.Key == Key.Decimal))
            {

                e.Handled = false;


            }

            else e.Handled = true;
        }

        private void txtCalc_PreviewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == ApplicationCommands.Copy ||
                 e.Command == ApplicationCommands.Cut ||
                 e.Command == ApplicationCommands.Paste)
            {
                e.Handled = true;
            }
        }



        private void btnExpandCalc_Click(object sender, RoutedEventArgs e)
        {
            if (stkCalc.Visibility == Visibility.Collapsed)

            {
                stkCalc.Visibility = Visibility.Visible;
            }

            else
            {
                stkCalc.Visibility = Visibility.Collapsed;

            }
        }

        private void btnAddSale_Click(object sender, RoutedEventArgs e)
        {
            decimal d;
            bool isdecimal = Decimal.TryParse(txtPrice.Text, out d);


            var sel = 0;
            dynamic selCurr = sel;

            


            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show(fillexpense);
            }

            else if (txtPrice.Text.Trim() == "")
            {

                MessageBox.Show(fillprice);

            }

            else if (isdecimal == false)
            {

                MessageBox.Show(decimalformat);

            }

            else if (cmbPayer.SelectedItem == null)
            {
                MessageBox.Show(choosepayer);
            }

            else
            {
                listBuyers = new List<Persons>();
                foreach (var item in lstBuyers.SelectedItems)
                    listBuyers.Add((Persons)item);


                newSale = new Sales();

                payer = new Persons();
                payer = (Persons)cmbPayer.SelectedItem;

                newSale.Description = txtDescription.Text;
               // newSale.Price = System.Math.Round(Convert.ToDouble(txtPrice.Text), 1);
                newSale.Price = System.Math.Round(Convert.ToDouble(txtPrice.Text) / selectedCurrency.CurrencyValue, 2);
                newSale.BasePrice = System.Math.Round(Convert.ToDouble(txtPrice.Text), 2);
                newSale.EventID = passedEvent.EventID;
                newSale.PayerID = payer.PersonID;
                newSale.BuyerQty = listBuyers.Count;
                newSale.CurrencyID = selectedCurrency.CurrencyID;
                newSale.CurrencyName = selectedCurrency.CurrencyName;
                newSale.Settled = 0;

                listSaleBuyers = new List<SaleBuyers>();

                for (int i = 0; i < listBuyers.Count; i++)
                {
                    newSaleBuyer = new SaleBuyers();
                    newSaleBuyer.BuyerID = listBuyers[i].PersonID;
                    newSaleBuyer.Price = System.Math.Round((Convert.ToDouble(txtPrice.Text) / selectedCurrency.CurrencyValue) / listBuyers.Count, 2);
                    newSaleBuyer.SaleID = newSale.SaleID;

                    listSaleBuyers.Add(newSaleBuyer);
                }

                newSale.bList = listSaleBuyers;
                newSale.Payers = payer;




                using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {
                    db.InsertWithChildren(newSale);

                    listSales = db.GetAllWithChildren<Sales>(recursive: true).Where(x => x.EventID == passedEvent.EventID).ToList();


                }
                listSales2 = new ObservableCollection<Sales>(listSales);
                lstSaleDetails.DataContext = listSales2.OrderByDescending(x => x.SaleID);
                txbSumSale.DataContext =  listSales2.Sum(x => x.Price).ToString();
                //MessageBox.Show("Ok");



            }
        }

        private void btnMoveCalcValue_Click(object sender, RoutedEventArgs e)
        {
            calcString = txtCalc.Text;

            double tmp;
            bool check = false;
            int cnt = 0;


            char[] sep = new char[] { '+' };

            string[] numb = calcString.Split(sep, StringSplitOptions.RemoveEmptyEntries);


            for (int i = 0; i < numb.Count(); i++)
            {

                check = Double.TryParse(numb[i], out tmp);
                if (check == false) cnt++;

            }

            if (cnt > 0)
            {

                MessageBox.Show(wrongstring);

            }

            else
            {

                double[] myInts = numb.Select(double.Parse).ToArray();
                double sum = myInts.Sum();
                txtPrice.Text = sum.ToString();

            }
        }

        private void btnClearCalc_Click(object sender, RoutedEventArgs e)
        {
            txtCalc.Text = "";
        }

        private void btnSaleCuurency_Click(object sender, RoutedEventArgs e)
        {

            pos = pos + 1;
          


            

            if (pos == listCurrency1.Count)
            {
                btnSaleCuurency.Content = listCurrency1[0].CurrencyName;
                pos = 0;
                selectedCurrency = listCurrency1[0];

            }

            else
            {
                selectedCurrency = listCurrency1[pos];
                btnSaleCuurency.Content = selectedCurrency.CurrencyName;
            }
            

        }

        private void SettleSale_OnClick(object sender, RoutedEventArgs e)
        {
            selectedSale = (Sales)lstSaleDetails.SelectedItem;
            if (selectedSale != null)
            {



                using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {
                    //db.Execute("delete from SaleBuyers where SaleID=?", selectedSale.SaleID);
                    selectedSale.Settled = 1;
                    db.Execute("PRAGMA foreign_keys=ON");
                    db.Update(selectedSale);
                //    selectedSale.IsSettledColor = (SolidColorBrush)(new BrushConverter().ConvertFrom("#D2B48C"));



                }
          
                lstSaleDetails.DataContext = listSales2.OrderByDescending(x => x.SaleID);

               
                // MessageBox.Show("Deleted");

            }

            else
            {

                MessageBox.Show(chooseperson);

            }
        }
    }
}
