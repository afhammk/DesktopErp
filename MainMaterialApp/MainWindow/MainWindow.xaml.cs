using Syncfusion.Windows.Tools.Controls;
using Syncfusion;
using MaterialDesignThemes;
using System;
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
using System.Windows.Threading;

namespace MainMaterialApp.MainWindow
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var x = new ContentControl() { Content = new Masters.SalesB2C.SalesB2C(), Style = null };
            DocumentContainer.SetHeader(x, "Sales b2c ");
            DocCont.Items.Add(x);


            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Timer.Text = DateTime.Now.ToString();
        }


        private void MenuBtn_Click(object sender, RoutedEventArgs e)
        {
            if (DrawerHost.IsLeftDrawerOpen == false)
                DrawerHost.IsLeftDrawerOpen = true;
            else
                DrawerHost.IsLeftDrawerOpen = false;

        }

        private void SalesB2C_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Masters.SalesB2C.SalesB2C(), Style = null };
            DocumentContainer.SetHeader(x, "Sales B2C");

            DocCont.Items.Add(x);
        

        }


        private void SalesReturn_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Masters.SalesReturn.SalesReturn() ,Style = null};
            DocumentContainer.SetHeader(x, "Sales Return");
            DocCont.Items.Add(x);

        }

        private void SalesB2B_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Masters.SalesB2B.SalesB2B(), Style = null };
            DocumentContainer.SetHeader(x, "Sales B2B");
            DocCont.Items.Add(x);
        }

        private void BillingPaymentWindow_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Billing.BillingPaymentWindow.BillingPaymentWindow(), Style = null };
            DocumentContainer.SetHeader(x, "Payment ");
            DocCont.Items.Add(x);
        }

        private void BillingReceiptWindow_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Billing.BillingReceiptWindow.BillingReceiptWindow(), Style = null };
            DocumentContainer.SetHeader(x, "Receipt ");
            DocCont.Items.Add(x);
        }

        private void ChangePaymentMode_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Billing.ChangePaymentMode.ChangePaymentMode(), Style = null };
            DocumentContainer.SetHeader(x, "Change Payment Mode ");
            DocCont.Items.Add(x);
        }

        private void RefundVoucher_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Billing.RefundVoucher.RefundVoucher(), Style = null };
            DocumentContainer.SetHeader(x, "Refund Voucher");
            DocCont.Items.Add(x);
        }

        private void DayClosing_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Billing.DayClosing.DayClosing(), Style = null };
            DocumentContainer.SetHeader(x, "Day Closing");
            DocCont.Items.Add(x);
        }

        private void Newumorphism_Selected(object sender, RoutedEventArgs e)
        {
          
        }

        private void SalesReturnOtherStore_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Masters.SalesReturnOtherStores.SalesReturnOtherStores(), Style = null };
            DocumentContainer.SetHeader(x, "SalesReturnOtherStores");
            DocCont.Items.Add(x);
        }

        private void SectionWiseReport_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Reports.SectionWiseReport.SectionWiseReport(), Style = null };
            DocumentContainer.SetHeader(x, "Section Wise Report");
            DocCont.Items.Add(x);
        }

        private void GiftIssue_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Billing.GiftCardIssue.GiftCardIssue(), Style = null };
            DocumentContainer.SetHeader(x, "Gift Card Issue");
            DocCont.Items.Add(x);
        }

        private void PurchaseReturn_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Purchase.PurchaseReturn.PurchaseReturn(), Style = null };
            DocumentContainer.SetHeader(x, "Purchase Return");
            DocCont.Items.Add(x);
        }

        private void DamageStockEntry_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Masters.DamageStockEntry.DamageStockEntry(), Style = null };
            DocumentContainer.SetHeader(x, "Damage Stock Entry");
            DocCont.Items.Add(x);
        }

    

        private void PurchaseView_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Purchase.PurchaseView.PurchaseView(), Style = null };
            DocumentContainer.SetHeader(x, "Purchase View");
            DocCont.Items.Add(x);
        }

        private void PurchaseRecieveForm_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Purchase.PurchaseRecieveForm.PurchaseRecieveForm(), Style = null };
            DocumentContainer.SetHeader(x, "Purchase Recieve Form");
            DocCont.Items.Add(x);
        }

        private void SalesReport_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Reports.SalesReport.SalesReport(), Style = null };
            DocumentContainer.SetHeader(x, "Sales Report");
            DocCont.Items.Add(x);
        }

        private void SearchBarcode_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Reports.SearchBarcode.SearchBarcode(), Style = null };
            DocumentContainer.SetHeader(x, "Search Barcode");
            DocCont.Items.Add(x);
        }

        private void SalesmanReport_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Reports.SalesmanReport.SalesmanReport(), Style = null };
            DocumentContainer.SetHeader(x, "Salesman Report");
            DocCont.Items.Add(x);
        }

        private void CustomerSales_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Billing.CustomerSales.CustomerSales(), Style = null };
            DocumentContainer.SetHeader(x, "Customer Sales");
            DocCont.Items.Add(x);
        }

        private void CustomerScreen_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new PagesForCustomer.CustomerScreen.CustomerScreen1(), Style = null };
            DocumentContainer.SetHeader(x, "Customer Screen");
            DocCont.Items.Add(x);
        }

        private void CustomerRating_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new PagesForCustomer.CustomerRating.CustomerScreen(), Style = null };
            DocumentContainer.SetHeader(x, "Customer Rating");
            DocCont.Items.Add(x);
        }

        private void Loading_Selected(object sender, RoutedEventArgs e)
        {
            var x = new ContentControl() { Content = new Loading(), Style = null };
            DocumentContainer.SetHeader(x, "Loading");
            DocCont.Items.Add(x);
        }

        private void Settings_Expanded(object sender, RoutedEventArgs e)
        {
            ReportsTree.IsExpanded = false;
            TailoringTree.IsExpanded = false;
            BillingTree.IsExpanded = false;
            PurchaseTree.IsExpanded = false;
            MastersTree.IsExpanded = false;
        }

        private void Reports_Expanded(object sender, RoutedEventArgs e)
        {
            TailoringTree.IsExpanded = false;
            BillingTree.IsExpanded = false;
            PurchaseTree.IsExpanded = false;
            MastersTree.IsExpanded = false;
            SettingsTree.IsExpanded = false;
        }

        private void Tailoring_Expanded(object sender, RoutedEventArgs e)
        {
            ReportsTree.IsExpanded = false;
            BillingTree.IsExpanded = false;
            PurchaseTree.IsExpanded = false;
            MastersTree.IsExpanded = false;
            SettingsTree.IsExpanded = false;
        }

        private void Billing_Expanded(object sender, RoutedEventArgs e)
        {
            ReportsTree.IsExpanded = false;
            TailoringTree.IsExpanded = false;
            PurchaseTree.IsExpanded = false;
            MastersTree.IsExpanded = false;
            SettingsTree.IsExpanded = false;
        }

        private void Purchase_Expanded(object sender, RoutedEventArgs e)
        {
            ReportsTree.IsExpanded = false;
            BillingTree.IsExpanded = false;
            TailoringTree.IsExpanded = false;
            MastersTree.IsExpanded = false;
            SettingsTree.IsExpanded = false;
        }

        private void Masters_Expanded(object sender, RoutedEventArgs e)
        {
            ReportsTree.IsExpanded = false;
            BillingTree.IsExpanded = false;
            PurchaseTree.IsExpanded = false;
            TailoringTree.IsExpanded = false;
            SettingsTree.IsExpanded = false;
        }

        private void MastersTree_Selected(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
