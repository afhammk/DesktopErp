using Newtonsoft.Json.Linq;
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

namespace MainMaterialApp.Masters.SalesB2C.SubWindows
{
    /// <summary>
    /// Interaction logic for OfferSection.xaml
    /// </summary>
    public partial class OfferSection : Window
    {
        private JArray response;
        ObservableCollection<Models.Offers> offerlist = new ObservableCollection<Models.Offers>();
        QueryHandler.QueryHandler queryHandler = new QueryHandler.QueryHandler();
        Action<string> act;

        public OfferSection(dynamic offers , Action<string> action)
        {
            InitializeComponent();
            this.offerlist = offers;
            this.act = action;
            OffersListBox.ItemsSource = offerlist ;     
           
        }

        string id;
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            foreach(var elem in offerlist)
            {
                if (elem.isSelected == true)
                {
                    this.id = elem.id;
                }
            }
            this.Close();
            act(id);    
            return;
        }

    }

}
