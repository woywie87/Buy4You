using SQLite;
using SQLiteNetExtensions.Extensions;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;
using System.Globalization;
using System.ComponentModel;

namespace fff
{
    /// <summary>
    /// Logika interakcji dla klasy EventsPage.xaml
    /// </summary>
    public partial class EventsPage : Page
    {
        public List<Persons> listPerson;

        public List<Events> listEvents;
        public ObservableCollection<Events> listEvents2;
        public List<Currencies> listCurrency;

    

        public Events newEvent;

        public List<EventsPersons> listEventsPersons;
        public EventsPersons newEventsPersons;

        public Events selectedEvent;

        //messages strings
        public string EventFill;
        public string ChooseDate;
        public string OnePerson;
        public string PersonSoloMode;
        public string ChoosePerson;

        public int filter = 0;

        public Currencies selectedCurrency;



        public void FillMessages()
        {
            EventFill = fff.Properties.Resources.EventFill;
            ChooseDate = fff.Properties.Resources.DateChoose;
            OnePerson = fff.Properties.Resources.PersonOneChoose;
            PersonSoloMode = fff.Properties.Resources.PersonSoloChoode;
            ChoosePerson = fff.Properties.Resources.PersonChoose;
        }


        public void RefreshView()
        {
            if(filter == 1)
            {
                lstEvents.DataContext = listEvents2.Where(x => x.Solo == 0).OrderByDescending(x => x.EventID);
            }
            else if (filter == 2)
            {
                lstEvents.DataContext = listEvents2.Where(x => x.Solo == 1).OrderByDescending(x => x.EventID);
            }

            else
            {
                lstEvents.DataContext = listEvents2.OrderByDescending(x => x.EventID);
            }



        }


        public EventsPage()
        {
            InitializeComponent();
            FillMessages();
          




            cldEventDate.SelectedDate = DateTime.Today;


            using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
            {

                listPerson = db.Table<Persons>().Where(x => x.Property == "P" && x.Status == 0).ToList();

                listEvents = db.GetAllWithChildren<Events>().OrderByDescending(x=>x.EventID).ToList();
                listCurrency = db.Table<Currencies>().ToList();
            }


            listEvents2 = new ObservableCollection<Events>(listEvents);

            lstPersons.DataContext = listPerson;
            lstEvents.DataContext = listEvents2;

            btnDefaultCurrency.Content = listCurrency[0].CurrencyName;
            selectedCurrency = listCurrency[0];

            // listPersonFinal = new List<Persons>();
        }


        void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext;
            if (item != null && item is Events)
            {
                selectedEvent = new Events();
                selectedEvent = (Events)item;
                /*
                SaleDetailsWindow w = new SaleDetailsWindow(selectedEvent);
                w.ShowDialog();
                */

                this.NavigationService.Navigate(new SalePage(selectedEvent));
            }
        }


        private void btnExpandPerson_Click(object sender, RoutedEventArgs e)
        {
            if (cldEventDate.Visibility == Visibility.Visible) cldEventDate.Visibility = Visibility.Collapsed;

            if (lstPersons.Visibility == Visibility.Collapsed)
            {
                lstPersons.Visibility = Visibility.Visible;
              //  txtExpandPerson.Foreground = Brushes.YellowGreen;
            }

            else
            {
                lstPersons.Visibility = Visibility.Collapsed;
               // txtExpandPerson.Foreground = Brushes.White;
            }
        }

        private void btnExpandCalendar_Click(object sender, RoutedEventArgs e)
        {
            if (lstPersons.Visibility == Visibility.Visible) lstPersons.Visibility = Visibility.Collapsed;

            if (cldEventDate.Visibility == Visibility.Collapsed)
            {
                cldEventDate.Visibility = Visibility.Visible;

            }

            else
            {
                cldEventDate.Visibility = Visibility.Collapsed;

            }
        }

        private void btnAddEvent_Click(object sender, RoutedEventArgs e)
        {


   
            if (txtEventName.Text.Trim() == "")
            {
                MessageBox.Show(EventFill);
            }

            else if (cldEventDate.SelectedDate == null)
            {

                MessageBox.Show(ChooseDate);

            }

            else if (lstPersons.SelectedItems.Count < 1)
            {
                MessageBox.Show(OnePerson);

            }
            else if (lstPersons.SelectedItems.Count > 1 && chkSolo.IsChecked==true)
            {

                MessageBox.Show(PersonSoloMode);

            }

            else
            {
                newEvent = new Events();
                newEvent.EventName = txtEventName.Text;

                if (chkSolo.IsChecked == true) 
                {
                    newEvent.Solo = 1;
                  
                
                 }

                else
                {
                    newEvent.Solo = 0;
                  
                }

                DateTime dt = cldEventDate.SelectedDate.Value;
                newEvent.EventDate = dt.ToString("dd/MM/yy");

                newEvent.pList = new List<Persons>();
                newEvent.DefaultCurrency = selectedCurrency.CurrencyID;

                for (int i = 0; i < lstPersons.SelectedItems.Count; i++)
                {
                    Persons p = new Persons();
                    p = (Persons)lstPersons.SelectedItems[i];
                    newEvent.pList.Add(p);

                }


                using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {
                  
                    db.InsertWithChildren(newEvent);

                }

                listEvents2.Add(newEvent);
                // lstEvents.DataContext = listEvents2.OrderByDescending(x => x.EventID);
                RefreshView();



            }
        }

        private void removeEvent_Click(object sender, RoutedEventArgs e)
        {
            selectedEvent = (Events)lstEvents.SelectedItem;
            if (selectedEvent != null)
            {
                using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {

                    db.Execute("PRAGMA foreign_keys=ON");
                   // db.Execute("delete from Events where EventID=?", selectedEvent.EventID);
                    db.Delete(selectedEvent);

                }
                listEvents2.Remove(selectedEvent);
                // lstEvents.DataContext = listEvents2.OrderByDescending(x => x.EventID);
                RefreshView();

            }

            else
            {

                MessageBox.Show(ChoosePerson);

            }
        }


        private void SettleEvent_Click(object sender, RoutedEventArgs e)
        {

            selectedEvent = (Events)lstEvents.SelectedItem;
            if (selectedEvent != null)
            {

                using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {

                    db.Execute("PRAGMA foreign_keys=ON");
                     db.Execute("update Sales set Settled = 1 where EventID = (select e.EventID from Events e where e.EventID = ?)", selectedEvent.EventID);
                   // db.Delete(selectedEvent);

                }
                // listEvents2.Remove(selectedEvent);
                // lstEvents.DataContext = listEvents2.OrderByDescending(x => x.EventID);
                RefreshView();

            }

            else
            {

                MessageBox.Show(ChoosePerson);

            }


        }





        private void cmbFilters_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listEvents2!=null)
            {

                if (cmbFilters.SelectedIndex == 0)
                {

                    filter = 0;
                    lstEvents.DataContext = listEvents2.OrderByDescending(x => x.EventID);

                }

                else if (cmbFilters.SelectedIndex == 1)
                {
                    lstEvents.DataContext = listEvents2.Where(x => x.Solo == 0).OrderByDescending(x => x.EventID);
                    filter = 1;

                }

                else if (cmbFilters.SelectedIndex == 2)
                {
                    lstEvents.DataContext = listEvents2.Where(x => x.Solo == 1).OrderByDescending(x => x.EventID);
                    filter = 2;
                }

            }
        }

  
        private void btnDefaultCurrency_Click(object sender, RoutedEventArgs e)
        {
            int pos = listCurrency.FindIndex(x => x.CurrencyName == btnDefaultCurrency.Content);// Find(x => x.CurrencyName == btnTest.Content);


            if (pos == listCurrency.Count - 1)
            {
                btnDefaultCurrency.Content = listCurrency[0].CurrencyName;
                pos = 0;
                selectedCurrency = listCurrency[0];

            }

            else
            {
                btnDefaultCurrency.Content = listCurrency[pos + 1].CurrencyName;
                selectedCurrency = listCurrency[pos + 1];
            }

        }

        private void TxtSearchEventsBySale_OnSelectionChanged(object sender, RoutedEventArgs e)
        {

            if (txtSearchEventsBySale.Text != "")
            {
                string searchtext = txtSearchEventsBySale.Text.ToLower();
                List<int> ids = new List<int>();
                using (var db =
                    new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(),
                        "zakupy.db"))
                {

                    var lst =
                        db.Query<Events>(
                            "select E.EventID from Events E inner join Sales S ON e.EventID = S.EventID WHERE S.Description like ?",
                            '%' + searchtext + '%').ToList().OrderByDescending(x => x.EventID);

                    foreach (var l in lst)
                    {
                        ids.Add(l.EventID);
                    }

                    lstEvents.DataContext = listEvents2.Where(t => ids.Contains(t.EventID));
                }
            }
        }
    }
}
