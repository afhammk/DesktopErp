using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace MainMaterialApp.Masters.SalesReturnOtherStores.Models
{
    public class TableDataStructure : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private ObservableCollection<TableDataStructure> tableitems { get; set; }
        public ObservableCollection<TableDataStructure> TableItems
        {
            get { return tableitems; }
            set
            {
                tableitems = value;
                OnPropertyChanged();
            }
        }
        private string id { get; set; }
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged();
            }
        }
        private string no;
        public string No
        {
            get { return no; }
            set
            {
                no = value;
                OnPropertyChanged();
            }
        }


        private string details;
        public string Details
        {
            get { return details; }
            set
            {
                details = value;
                OnPropertyChanged();
            }
        }

        private string cgstdetails;
        public string CgstDetails
        {
            get { return cgstdetails; }
            set
            {
                cgstdetails = value;
                OnPropertyChanged();
            }
        }

        private string sgstdetails;
        public string SgstDetails
        {
            get { return sgstdetails; }
            set
            {
                sgstdetails = value;
                OnPropertyChanged();
            }
        }

        private string discountdetails;
        public string DiscountDetails
        {
            get { return discountdetails; }
            set
            {
                discountdetails = value;
                OnPropertyChanged();
            }
        }
        private string barcode;
        public string Barcode
        {
            get { return barcode; }
            set
            {
                barcode = value;
                OnPropertyChanged();
            }
        }

        private string hsn;
        public string HSN
        {
            get { return hsn; }
            set
            {
                hsn = value;

                OnPropertyChanged();
            }
        }

        private string item;
        public string Item
        {
            get { return item; }
            set
            {
                item = value;
                OnPropertyChanged();
            }
        }
        private string qty;
        public string Qty
        {
            get { return qty; }
            set
            {
                qty = value;
                OnPropertyChanged();
            }
        }

        private string mrp;
        public string Mrp
        {
            get { return mrp; }
            set
            {
                mrp = value;
                OnPropertyChanged();
            }
        }
        private string discount;
        public string Discount
        {
            get { return discount; }
            set
            {
                discount = value;
                OnPropertyChanged();
            }
        }

        private string cgst;
        public string Cgst
        {
            get { return cgst; }
            set
            {
                cgst = value;
                OnPropertyChanged();
            }
        }

        private string sgst;
        public string Sgst
        {
            get { return sgst; }
            set
            {
                sgst = value;
                OnPropertyChanged();
            }
        }


        private string amount;
        public string Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnPropertyChanged();
            }
        }
        private string salesman;
        public string Salesman
        {
            get { return salesman; }
            set
            {
                salesman = value;
                OnPropertyChanged();
            }
        }
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    
}
}
