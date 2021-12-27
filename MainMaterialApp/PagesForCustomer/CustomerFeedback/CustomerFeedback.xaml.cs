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
using System.Windows.Shapes;

namespace MainMaterialApp.PagesForCustomer.CustomerFeedback
{
    /// <summary>
    /// Interaction logic for CustomerFeedback.xaml
    /// </summary>
    public partial class CustomerFeedback : Window
    {
        ObservableCollection<Models.ListItemStructure> listitems = new ObservableCollection<Models.ListItemStructure>();

        public CustomerFeedback()
        {
            InitializeComponent();
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22" });
            ListTable.ItemsSource = listitems;
        }
    }
}
