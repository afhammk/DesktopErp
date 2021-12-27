using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MainMaterialApp.Masters.SalesB2C.Models
{
    public class TableTotal  : TableDataStructure
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
        private string totaldiscount { get; set; }
        public string TotalDiscount
        {
            get { return totaldiscount; }
            set
            {
                totaldiscount = value;
                OnPropertyChanged("TotalDiscount");
            }
        }
    }
}
