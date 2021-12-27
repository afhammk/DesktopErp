using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MainMaterialApp.Masters.SalesB2B.Models
{
    class BasicInfo :INotifyPropertyChanged , IDataErrorInfo

    {

        public event PropertyChangedEventHandler PropertyChanged;


        private DateTime invoicedate = DateTime.Now;
        public DateTime InvoiceDate
        {
            get { return invoicedate; }
            set
            {
                invoicedate = value;
                OnPropertyChanged("InvoiceDate");
            }
        }
        private Models.PartyModel partyselected { get; set; }
        public Models.PartyModel PartySelected
        {
            get { return partyselected; }
            set
            {
                partyselected = value;
                OnPropertyChanged("PartySelected");
            }
        }
     
        private double invoiceno { get; set; }
        public double InvoiceNo
        {
            get { return invoiceno; }
            set
            {
                invoiceno = value;
                OnPropertyChanged("InvoiceNo");
            }
        }
        private bool dataChanged = false;
        protected void OnPropertyChanged(string name)
        {
            dataChanged = true;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        /*----------------------------Error Validation---------------------------------*/

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                return GetErrorForProperty(propertyName);
            }
        }

        private string GetErrorForProperty(string propertyName)
        {
            switch (propertyName)
            {
               
                case "PartySelected":
                    if (PartySelected==null && dataChanged)
                        return "PartySelected is empty";

                    else
                    {
                        return string.Empty;
                    }
            
                default:
                    return string.Empty;
            }
        }
    }
}
