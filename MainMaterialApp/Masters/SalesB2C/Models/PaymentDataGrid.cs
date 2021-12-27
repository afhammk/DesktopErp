using System;
using System.Collections.Generic;
using System.Text;

namespace MainMaterialApp.Masters.SalesB2C.Models
{
    class PaymentDataGrid
    {
        private string paymentName;
        public string PaymentName
        {
            get
            {
                return paymentName;
            }
            set
            {
                paymentName = value;
            }
        }
        private int amount;
        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }
        }
    }
}
