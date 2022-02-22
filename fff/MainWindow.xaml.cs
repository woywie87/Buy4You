using SQLite.Net;
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
using System.Windows.Shapes;
using System.Xml;
using MahApps.Metro.Controls;
//using MySql.Data.MySqlClient;
using System.Data;
using System.Threading;

namespace fff
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public List<Report> listReports;


        public string xmlfile;
        public string reportfile;

        public void FillMessages()
        {
            xmlfile = fff.Properties.Resources.XmlProblem;
            reportfile = fff.Properties.Resources.ReportFileProblem;
          
        }

        public void GetReports()
        {
            XmlDocument xml = new XmlDocument();
            try
            {
                xml.Load("reports.xml");
                listReports = new List<Report>();

                foreach (XmlNode xn in xml.SelectNodes("/reports/report"))
                {

                    Report newReport = new Report();
                    newReport.ReportID = xn["id"].InnerText;
                    newReport.Name = xn["title"].InnerText;
                    newReport.Query = xn["query"].InnerText;

                    listReports.Add(newReport);
                }

            }
            catch (System.Xml.XmlException)
            {
                MessageBox.Show(xmlfile);
            }

            catch(System.IO.FileNotFoundException)
            {
                MessageBox.Show(reportfile);
            }
        }


        public void SetLanguage()
        {
            AppSettings aps = new AppSettings();


            using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
            {
                aps = db.Table<AppSettings>().Where(x => x.SettingName == "Language").FirstOrDefault();


            }

            if (aps.SettingValue == "Polish")
            {


                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("pl-PL");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("pl-PL");

               
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en");
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");


            }


        }

        public MainWindow()
        {
            InitializeComponent();
            FillMessages();
            GetReports();
            SetLanguage();



        }
      
      

        private void btnMain_Click(object sender, RoutedEventArgs e)
        {
            EventsPage ep = new EventsPage();
            ContentFrame.Navigate(ep);
        }

        private void btnPersons_Click(object sender, RoutedEventArgs e)
        {
            PersonPage p = new PersonPage();
            ContentFrame.Navigate(p);
        }

        private void btnSummary_Click(object sender, RoutedEventArgs e)
        {
            SummaryPage sm = new SummaryPage();
            ContentFrame.Navigate(sm);
        }

        private void btnCustomRep_Click(object sender, RoutedEventArgs e)
        {
            ReportPage rp = new ReportPage(listReports);
            ContentFrame.Navigate(rp);
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsPage sp = new SettingsPage();
            ContentFrame.Navigate(sp);
        }

        private void btnInfo_Click(object sender, RoutedEventArgs e)
        {
            AboutPage ap = new AboutPage();
            ap.ShowDialog();
        }

       
    }
    
}
