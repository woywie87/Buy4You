using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace fff
{
    /// <summary>
    /// Logika interakcji dla klasy ReportPage.xaml
    /// </summary>
    public partial class ReportPage : Page
    {
        public List<Report> passedReports;

        public Report selectedReport;


        public string wrongquery;
        public string duplcol;


        public void FillMessages()
        {
            wrongquery = fff.Properties.Resources.QueryWrong;
            duplcol = fff.Properties.Resources.DuplCol;
        }


        public ReportPage(List<Report> passReports)
        {
            InitializeComponent();
            FillMessages();

            passedReports = passReports;
            lstReports.DataContext = passedReports;

            if(passedReports != null)
            {

                lstReports.Visibility = Visibility.Visible;


            }

        }

      
        private void lstReports_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dtgCustomReport.Visibility = Visibility.Visible;



            selectedReport = new Report();

            selectedReport = (Report)lstReports.SelectedItem;

            string qr = selectedReport.Query;


            if (
                    qr.Contains("create") || qr.Contains("delete") || qr.Contains("alter") || qr.Contains("update") ||
                    qr.Contains("drop") || qr.Contains("trunc") || qr.Contains("insert")
                )
            {
                MessageBox.Show(wrongquery);
            }

            else
            {
                qr = qr.ToLower();



                string ConString = "zakupy.db";
                DataTable dt = new DataTable();
                using (SQLiteConnection con = new SQLiteConnection(ConString))
                {
                    try
                    {
                        using (var statement = con.Prepare(qr))
                        {
                            try
                            {
                                for (int i = 0; i < statement.ColumnCount; i++)
                                {

                                    dt.Columns.Add(statement.ColumnName(i));
                                }
                            }
                            catch (System.Data.DuplicateNameException)
                            {
                                MessageBox.Show(duplcol);
                                statement.Dispose();
                            }


                            while (statement.Step() == SQLiteResult.ROW)
                            {

                                DataRow dr;
                                dr = dt.NewRow();

                                for (int i = 0; i < statement.ColumnCount; i++)
                                {
                                    dr[i] = statement[i];
                                }
                                dt.Rows.Add(dr);
                            }
                        }
                    }

                    catch (SQLitePCL.SQLiteException)
                    {

                        MessageBox.Show(wrongquery);
                    }
                }
                dtgCustomReport.DataContext = dt.DefaultView;
            }
        }
    }
}
