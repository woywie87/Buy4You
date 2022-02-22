using SQLite.Net;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace fff
{

    public class Events
    {
        [PrimaryKey, AutoIncrement]
        public int EventID { get; set; }

        public string EventName { get; set; }

        public string EventDate { get; set; }

        public string FullName
        {

            get
            {
                return EventDate + " " + EventName;

            }

        }

        public int Solo { get; set; }


        [ManyToMany(typeof(EventsPersons))]
        public List<Persons> pList { get; set; }

        public int DefaultCurrency { get; set; }




    }




    public class Persons
    {
        [PrimaryKey, AutoIncrement]
        public int PersonID { get; set; }

        public string Name { get; set; }

        public string Property { get; set; }

        public int Status { get; set; }

        public string PersonColor { get; set; }

        public string PersonColor2 { get; set; }

        public string Initials { get; set; }
        
        [ManyToMany(typeof(EventsPersons))]
        public List<Events> eList { get; set; }



    }


    public class EventsPersons
    {
        [PrimaryKey, AutoIncrement]
        public int EventsPersonsID { get; set; }


        [ForeignKey(typeof(Events))]
        public int EventID { get; set; }

        [ForeignKey(typeof(Persons))]
        public int PersonID { get; set; }
    }

    
    public class Sales
    {
        [PrimaryKey, AutoIncrement]
        public int SaleID { get; set; }

        public int EventID { get; set; }
        public double Price { get; set; }
        public double BasePrice { get; set; }
        public string Description { get; set; }

        public int Settled { get; set; }

        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public int CurrencyValue { get; set; }

        [ForeignKey(typeof(Persons)) ]
        public int PayerID { get; set; }

        public int BuyerQty { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<SaleBuyers> bList { get; set; }

        [OneToOne]
        public Persons Payers { get; set; }



        public string PriceConv
        {
            get
            {


                return Price.ToString() + " PLN";

            }

        }


        public string BasePriceConv
        {
            get
            {

                if (CurrencyName == "PLN") return "";
                else return BasePrice.ToString() + " " + CurrencyName;

            }

        }

        [Ignore]
        public SolidColorBrush IsSettledColor
        {
            get
            {
                if (Settled == 1) return (SolidColorBrush)(new BrushConverter().ConvertFrom("#D2B48C"));
                else
                {
                    return new SolidColorBrush(Colors.AntiqueWhite);
                }
            }


        }

    }



    public class SaleBuyers
    {
        [PrimaryKey, AutoIncrement]
        public int SaleBuyerID { get; set; }

        [ForeignKey(typeof(Sales))]
        public int SaleID { get; set; }

        [ForeignKey(typeof(Persons))]
        public int BuyerID { get; set; }

        public double Price { get; set; }

        [OneToOne(CascadeOperations = CascadeOperation.All)]
        public Persons Buyers { get; set; }


        [ManyToOne]
        public Sales Sales { get; set; }

     


    }


    public class AppSettings
    {
        [PrimaryKey, AutoIncrement]
        public int SettingID { get; set; }

        public string SettingName { get; set; }
        public string SettingValue { get; set; }
 
    }



    public class Currencies
    {
        [PrimaryKey, AutoIncrement]
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public float CurrencyValue { get; set; }
    }




    public class vwFinal
    {

        public string PayerName { get; set; }
        public string BuyerName { get; set; }
        public int PayerID { get; set; }
        public int BuyerID { get; set; }
        public double Price { get; set; }
        public string Summary { get; set; }

    }

    public class vwFlow
    {
        public int PayerID { get; set; }
        public int BuyerID { get; set; }
        public double Sumprice { get; set; }

    }


    public class vwFlow2
    {
        public string PayerName { get; set; }
        public string BuyerName { get; set; }
        public string EventName { get; set; }
       // public string Description { get; set; }
        public int PayerID { get; set; }
        public int BuyerID { get; set; }
        public int EventID { get; set; }
        public string Summary { get; set; }

    }

    public class vwBuy
    {
        public string EventName { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int PersonID { get; set; }
        public int EventID { get; set; }
        public double Price { get; set; }
    }


    public class vwPersonSummary
    {
        public string EventName { get; set; }
        public string PersonName { get; set; }
        public int PersonID { get; set; }
        public int EventID { get; set; }
        public double OwnPrice { get; set; }
        public double FPrice { get; set; }
        public double MPrice { get; set; }


    }

    public class Report
    {
        public string ReportID { get; set; }
        public string Name { get; set; }
        public string Query { get; set; }


    }


    public class vwSales
    {
        public string SaleID { get; set; }
        public int EventID { get; set; }
        public string Price { get; set; }
        public int PayerID { get; set; }
        public int Buyerid { get; set; }
        public string BuyerName { get; set; }
        public string PayerName { get; set; }
        public string Description { get; set; }


    }

    public class vwPivot
    {
        public string SaleID { get; set; }
        public string Description { get; set; }
        public int Settled { get; set; }
        public string Price { get; set; }
        public string PayerName { get; set; }
        public int EventID { get; set; }

    }





}