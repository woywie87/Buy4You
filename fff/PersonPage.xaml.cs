using SQLite.Extensions;
using SQLiteNetExtensions.Attributes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using SQLite.Net;
using SQLiteNetExtensions.Extensions;

namespace fff
{
    /// <summary>
    /// Logika interakcji dla klasy PersonPage.xaml
    /// </summary>
    /// 



    

    public partial class PersonPage : Page
    {

        public Persons selectedPerson;

        public List<vwPersonSummary> buyList;

        public Dictionary<string, string> ColorCombination = new Dictionary<string, string>();

        public string fillperson;
        public string chooseperson;



        public void FillMessages()
        {
            fillperson = fff.Properties.Resources.PersonFill;
            chooseperson = fff.Properties.Resources.PersonChoose;
          
        }


        private KeyValuePair <string, string> GetRandomColor()
        {
            Random _rand = new Random();

            return ColorCombination.ElementAt(_rand.Next(ColorCombination.Count));
        }


        public Persons newPerson;
        public List<Persons> listPerson;

        public ObservableCollection<Persons> listPerson2;



        public PersonPage()
        {
            InitializeComponent();
            FillMessages();



            ColorCombination.Add("#0059B3", "White");
            ColorCombination.Add("#001A33", "White");
            ColorCombination.Add("#E63900", "White");
            ColorCombination.Add("#FF1A1A", "White");
            ColorCombination.Add("#4D9900", "Black");
            ColorCombination.Add("#80FF80", "Black");
            ColorCombination.Add("#999966", "White");

            ColorCombination.Add("#993333", "White");
            ColorCombination.Add("#6699FF", "Black");
            ColorCombination.Add("#FFFF4D", "Black");
            ColorCombination.Add("#339966", "Black");
            ColorCombination.Add("#00CC66", "Black");
            ColorCombination.Add("#4D0000", "White");



            using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
            {

                listPerson = db.Table<Persons>().Where(x => x.Property == "P" && x.Status == 0).ToList();

            }

            listPerson2 = new ObservableCollection<Persons>(listPerson);

            lstPersons.DataContext = listPerson2;
        }


        private void btnAddPerson_Click(object sender, RoutedEventArgs e)
        {
            KeyValuePair<string, string> kp = GetRandomColor();


            if (txtPersonName.Text.Trim() != "")
            {

                newPerson = new Persons();

                newPerson.Property = "P";
                newPerson.Status = 0;
                newPerson.Name = txtPersonName.Text;
                newPerson.PersonColor = kp.Key;
                newPerson.PersonColor2 = kp.Value;
                newPerson.Initials = newPerson.Name.Substring(0, 1);

                using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {

                    db.Insert(newPerson);


                }
                listPerson2.Add(newPerson);
            }

            else
            {

                MessageBox.Show(fillperson);
            }
        }

        private void lstPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstPersonDetails.Visibility = Visibility.Visible;

            selectedPerson = (Persons)lstPersons.SelectedItem;

            if (selectedPerson != null)
            {

                buyList = new List<vwPersonSummary>();

                using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {
                    buyList = db.Table<vwPersonSummary>().Where(x => x.PersonID == selectedPerson.PersonID).ToList();

                }
                lstPersonDetails.DataContext = buyList;
            }


        }

        private void removePerson_Click_1(object sender, RoutedEventArgs e)
        {
            selectedPerson = (Persons)lstPersons.SelectedItem;
            if (selectedPerson != null)
            {
                selectedPerson.Status = 1;
                selectedPerson.PersonColor = "Black";
                selectedPerson.PersonColor2 = "White";


                using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {

                    db.Update(selectedPerson);


                }
                listPerson2.Remove(selectedPerson);
              //  MessageBox.Show("Deleted");

            }

            else
            {

                MessageBox.Show(chooseperson);

            }
        }
    }
}
