using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Windows.Controls;


namespace MainMaterialApp.Masters.SalesReturnOtherStores
{
    /// <summary>
    /// Interaction logic for SalesReturnOtherStores.xaml
    /// </summary>
    
    public partial class SalesReturnOtherStores : UserControl
    {
        ObservableCollection<Models.TableDataStructure> datagriditems = new ObservableCollection<Models.TableDataStructure>();

        public SalesReturnOtherStores()
        {
            InitializeComponent();
            InsideDatagrid.ItemsSource = datagriditems;

            datagriditems.Add(new Models.TableDataStructure()
            {
                Amount = "12",
                Barcode = "3223",
                Cgst = "3232",
                CgstDetails = "2332",
                Salesman = "ansar mon",
                Sgst = "2121",
                SgstDetails = "3434",
                Details = "Shirt Details",
                Discount = "132",
                Id = "23",
                DiscountDetails = "422",
                Item = "Shirt",
                Mrp = "232",
                No = "32",
                Qty = "4343"

             });

            
         }
    }
}
