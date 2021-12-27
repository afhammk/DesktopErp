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

namespace MainMaterialApp.PagesForCustomer.CustomerScreen
{
    /// <summary>
    /// Interaction logic for CustomerScreenWindow.xaml
    /// </summary>
    public partial class CustomerScreenWindow : Window
    {
        public CustomerScreenWindow(Masters.SalesB2C.Models.BasicInfo basicinfo , ObservableCollection<Masters.SalesB2C.Models.TableDataStructure> datagriditems)
        {
            InitializeComponent();
            BillDataGrid.ItemsSource = datagriditems;
            NameTextBlock.DataContext = basicinfo;
            NameSubTextBlock.DataContext = basicinfo;
            PhoneTextBlock.DataContext = basicinfo;
        }
    }
}
