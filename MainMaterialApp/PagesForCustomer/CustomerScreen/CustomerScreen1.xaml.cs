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
using System.Windows.Threading;

namespace MainMaterialApp.PagesForCustomer.CustomerScreen
{
    /// <summary>
    /// Interaction logic for CustomerScreen1.xaml
    /// </summary>
    public partial class CustomerScreen1 : UserControl
    {
        ObservableCollection<Models.ListItemStructure> listitems = new ObservableCollection<Models.ListItemStructure>();
        public CustomerScreen1()
        {
            InitializeComponent();
            BillDataGrid.ItemsSource = listitems;
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
        }
      
    }
}
