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
    /// Interaction logic for CustomerScreen.xaml
    /// </summary>
    public partial class CustomerScreen : UserControl
    {
        ObservableCollection<Models.ListItemStructure> listitems = new ObservableCollection<Models.ListItemStructure>();
        ObservableCollection<UserControl> imageList = new ObservableCollection<UserControl>();
        int count = 1;
        public CustomerScreen()
        {
            InitializeComponent();
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22" , Details="SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            listitems.Add(new Models.ListItemStructure { Qty = "1", Amount = "123", Discount = "10", Item = "shirt", Mrp = "22", Details = "SHIRT DETAILS" });
            ListTable.ItemsSource = listitems;

            imageList.Add(new Images.image1UserControl());
            imageList.Add(new Images.image2UserControl());
            imageList.Add(new Images.image3UserControl());
            imageList.Add(new Images.image4UserControl());
            imageList.Add(new Images.image5UserControl());
            imageList.Add(new Images.image6UserControl());
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += timer_Tick;
            timer.Start();

            ContentArea.Content = imageList[0];

        }
        void timer_Tick(object sender, EventArgs e)
        {
            count = count + 1;
            ContentArea.Content = imageList[count-1];
            if (count == imageList.Count)
                count = 0;
        }
    }
}
