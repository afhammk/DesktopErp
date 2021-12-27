using System;
using System.Collections.Generic;
using System.Text;

namespace MainMaterialApp.Billing.ChangePaymentMode.Models
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
