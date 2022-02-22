using System;
using SQLite.Net;
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
using System.Net.NetworkInformation;

using System.Data;

namespace fff
{
    /// <summary>
    /// Logika interakcji dla klasy SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {


        public string connStr = "server=db4free.net; user = pitcairn1987; database = pitcairn1987; port = 3307;  password =talithacumi1";


        public string fieldsempty;
        public string loginformat;
        public string passmatch;
        public string passformat;
        public string ok;
        public string wrongloginpass;
        public string nodatabaseyet;
        public string areyousure;
        public string erasedatabase;

        public void FillMessages()
        {
            fieldsempty = fff.Properties.Resources.FieldsEmpty;
            loginformat = fff.Properties.Resources.LoginFormat;
            passmatch = fff.Properties.Resources.NotPasswords;
            passformat = fff.Properties.Resources.PassFormat;
            ok = fff.Properties.Resources.Ok;
            wrongloginpass = fff.Properties.Resources.LoginPassWrond;
            nodatabaseyet = fff.Properties.Resources.YetServerDatabase;
            areyousure = fff.Properties.Resources.YouAre;
            erasedatabase = fff.Properties.Resources.DatabaseErase;
        }



        public SettingsPage()
        {
            InitializeComponent();
            FillMessages();
        }


        private void btnErase_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show(areyousure, erasedatabase, System.Windows.MessageBoxButton.YesNo);

            if (messageBoxResult == MessageBoxResult.Yes)
            {

                using (var db = new SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {

                    db.Execute("PRAGMA foreign_keys=ON");
                    db.Execute("delete from " + "Events");
                    db.Execute("delete from " + "Persons");
                    db.Execute("UPDATE SQLITE_SEQUENCE SET SEQ=0 WHERE NAME in ('Persons','Events','EventsPersons','Sales','SaleBuyers');");
                    db.Close();
                }
            }

        }

        private void btnUpload_Click(object sender, RoutedEventArgs e)
        {
            if (stkUp.Visibility == Visibility.Collapsed)
            {

                stkUp.Visibility = Visibility.Visible;
            }

            else stkUp.Visibility = Visibility.Collapsed;

        }

        private void btnDown_Click(object sender, RoutedEventArgs e)
        {
            if (stkDown.Visibility == Visibility.Collapsed)
            {
                stkDown.Visibility = Visibility.Visible;
            }
            else stkDown.Visibility = Visibility.Collapsed;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (stkReg.Visibility == Visibility.Collapsed)
            {
                stkReg.Visibility = Visibility.Visible;
            }

            else stkReg.Visibility = Visibility.Collapsed;
        }

        private void btnRegSave_Click(object sender, RoutedEventArgs e)
        {


            if (txtRegName.Text.Trim() == "" || txtRegPass.Password.Trim() == "" || txtRegPass2.Password.Trim() == "")
            {

                MessageBox.Show(fieldsempty);

            }

            else if (txtRegName.Text.Length < 6)
            {
                MessageBox.Show(loginformat);

            }

            else if (txtRegPass.Password != txtRegPass2.Password)
            {
                MessageBox.Show(passmatch);

            }

            else if (txtRegPass.Password.Length < 6)
            {
                MessageBox.Show(passformat);

            }
            else
            {

                /*

                MySqlConnection conn = new MySqlConnection(connStr);
                conn.Open();
                string cmdstr = "INSERT INTO Users VALUES(@user, @pass)";
                MySqlCommand cmd = new MySqlCommand(cmdstr, conn);
                cmd.CommandText = "INSERT INTO Users(UserLogin, UserPass) VALUES(@user, @pass)";
                cmd.Prepare();
                cmd.Parameters.AddWithValue("@user", txtRegName.Text);
                cmd.Parameters.AddWithValue("@pass", txtRegPass.Password);
                cmd.ExecuteNonQuery();

                conn.Close();

                FtpTool ftpClient = new FtpTool(@"ftp://ftp.cluster020.hosting.ovh.net/Buy4U/", "awarteplvt", "TaH4MRS6shJG");
                ftpClient.createDirectory(txtRegName.Text);

                txtRegName.Text = "";
                txtRegPass.Password = "";
                txtRegPass2.Password = "";

                MessageBox.Show(ok);

    */
            }

        }

        private void btnDownSave_Click(object sender, RoutedEventArgs e)
        {
            /*
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string cmdstr = "Select * from Users where UserLogin = @user and UserPass = @pass";
            MySqlCommand cmd = new MySqlCommand(cmdstr, conn);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@user", txtDownName.Text);
            cmd.Parameters.AddWithValue("@pass", txtDownPass.Password);
            if (cmd.ExecuteScalar() == null)
            {

                MessageBox.Show(wrongloginpass);
                conn.Close();

            }

            else
            {
                conn.Close();
                FtpTool ftpClient = new FtpTool(@"ftp://ftp.cluster020.hosting.ovh.net/", "awarteplvt", "TaH4MRS6shJG");

                var appDir = Environment.CurrentDirectory;
                string myDir = @"/Buy4U/" + txtDownName.Text + @"/zakupy.db";
                var dir = System.IO.Path.Combine(appDir, "zakupy.db");

                string[] list = new string[1];

                list = ftpClient.directoryListSimple(myDir);
                if (list[0] == "")
                {
                    MessageBox.Show(nodatabaseyet);

                }
                else
                {

                    ftpClient.download(myDir, dir);
                    txtDownPass.Password = "";
                    txtDownName.Text = "";
                    MessageBox.Show(ok);
                }
            }

    */
        }

        private void btnUpSave_Click(object sender, RoutedEventArgs e)
        {

            /*
            MySqlConnection conn = new MySqlConnection(connStr);
            conn.Open();
            string cmdstr = "Select * from Users where UserLogin = @user and UserPass = @pass";
            MySqlCommand cmd = new MySqlCommand(cmdstr, conn);
            cmd.Prepare();
            cmd.Parameters.AddWithValue("@user", txtUpName.Text);
            cmd.Parameters.AddWithValue("@pass", txtUpPass.Password);

            if (cmd.ExecuteScalar() == null)
            {

                MessageBox.Show(wrongloginpass);
                conn.Close();

            }

            else
            {
                conn.Close();
                FtpTool ftpClient = new FtpTool(@"ftp://ftp.cluster020.hosting.ovh.net/", "awarteplvt", "TaH4MRS6shJG");
                var appDir = Environment.CurrentDirectory;
                string myDir = @"/Buy4U/" + txtUpName.Text + @"/zakupy.db";
                var dir = System.IO.Path.Combine(appDir, "zakupy.db");
                ftpClient.upload(myDir, dir);
                txtUpName.Text = "";
                txtUpPass.Password = "";
                MessageBox.Show(ok);
            }
            */
        }

        private void cmbLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            AppSettings aps = new AppSettings();
            



            if (cmbLanguage.SelectedIndex==0)
            {    
                using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {
                    aps = db.Table<AppSettings>().Where(x => x.SettingName == "Language").FirstOrDefault();

                    var cmb = (ComboBoxItem)cmbLanguage.SelectedItem;
                    aps.SettingValue = cmb.Content.ToString();

                    db.Update(aps);


                }

                App.ChangeCulture(new System.Globalization.CultureInfo("pl-PL"));
            }


            else
            {           
               

               

                using (var db = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.Generic.SQLitePlatformGeneric(), "zakupy.db"))
                {
                    aps = db.Table<AppSettings>().Where(x => x.SettingName == "Language").FirstOrDefault();

                    var cmb = (ComboBoxItem)cmbLanguage.SelectedItem;
                    aps.SettingValue = cmb.Content.ToString();

                    db.Update(aps);


                }

                App.ChangeCulture(new System.Globalization.CultureInfo("en"));



            }




        }
    }
}
