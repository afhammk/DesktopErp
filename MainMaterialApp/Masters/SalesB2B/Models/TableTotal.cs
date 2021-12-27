using System;
using System.Collections.Generic;
using System.Text;

namespace MainMaterialApp.Masters.SalesB2B.Models
{
    public class TableTotal : TableDataStructure
    {


        private string totalquantity { get; set; }
        public string TotalQuantity
        {
            get { return totalquantity; }
            set
            {
                totalquantity = value;
                OnPropertyChanged("TotalQuantity");
            }
        }
        private string totalhsn { get; set; }
        public string TotalHsn
        {
            get { return totalhsn; }
            set
            {
                totalhsn = value;
                OnPropertyChanged("TotalHsn");
            }
        }
        private string totalamount { get; set; }
        public string TotalAmount
        {
            get { return totalamount; }
            set
            {
                totalamount = value;
                OnPropertyChanged("TotalAmount");
            }
        }
        private string totalmrp { get; set; }
        public string TotalMrp
        {
            get { return totalmrp; }
            set
            {
                totalmrp = value;
                OnPropertyChanged("TotalMrp");
            }
        }
        private string totalprice { get; set; }
        public string TotalPrice
        {
            get { return totalprice; }
            set
            {
                totalprice = value;
                OnPropertyChanged("TotalPrice");
            }
        }
        private string totalsgst { get; set; }
        public string TotalSgst
        {
            get { return totalsgst; }
            set
            {
                totalsgst = value;
                OnPropertyChanged("TotalSgst");
            }
        }
        private string totalcgst { get; set; }
        public string TotalCgst
        {
            get { return totalcgst; }
            set
            {
                totalcgst = value;
                OnPropertyChanged("TotalCgst");
            }
        }
     
    }
}
