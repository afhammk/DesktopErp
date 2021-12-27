using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainMaterialApp.Masters.SalesB2C.SubWindows
{
    

    public partial class PaymentWindow : Window
    {
        ObservableCollection<Models.PaymentDataGrid> listOfPayments = new ObservableCollection<Models.PaymentDataGrid>();
        Action obj1;
        public PaymentWindow(Action obj)
        {
            InitializeComponent();
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0 , PaymentName = "paid by Cash" }); 
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0 , PaymentName = "paid by Hdfc1" }); 
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0 , PaymentName = "paid by Upi" }); 
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0 , PaymentName = "paid by Hdfc2" }); 
            listOfPayments.Add(new Models.PaymentDataGrid { Amount = 0 , PaymentName = "Reserve Amount" });
            PmntDataGrid.ItemsSource = listOfPayments;
            this.obj1 = obj;
        }

        private void CreditAdjustment_Click(object sender, RoutedEventArgs e)
        {
            var creditAdjustments = new CreditAdjustments();
            creditAdjustments.ShowDialog();
        }

        private void DiscountCoupon_Click(object sender, RoutedEventArgs e)
        {
            var discountCoupon = new DiscountsRedeemWindow();
            discountCoupon.ShowDialog();
        }

        private void PointsRedeem_Click(object sender, RoutedEventArgs e)
        {
            var pointsRedeem = new PointsRedeemWindow();
            pointsRedeem.ShowDialog();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            obj1.Invoke();
        }
    }
}
