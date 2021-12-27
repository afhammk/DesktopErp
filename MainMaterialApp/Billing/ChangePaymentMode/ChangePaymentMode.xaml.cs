using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MainMaterialApp.Billing.ChangePaymentMode
{
    /// <summary>
    /// Interaction logic for ChangePaymentMode.xaml
    /// </summary>
    public partial class ChangePaymentMode : UserControl
    {
        ObservableCollection<Models.PaymentDataGrid> listOfPayments = new ObservableCollection<Models.PaymentDataGrid>();

        public ChangePaymentMode()
        {
            InitializeComponent();
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0, PaymentName = "paid by Cash" });
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0, PaymentName = "paid by Hdfc1" });
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0, PaymentName = "paid by Upi" });
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0, PaymentName = "paid by Hdfc2" });
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0, PaymentName = "Reserve Amount" });
            PmntDataGrid.ItemsSource = listOfPayments;
        }
    }
}
