using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MainMaterialApp.Masters.SalesReturn.FlowDocument
{
    /// <summary>
    /// Interaction logic for FlowDocument.xaml
    /// </summary>
    public partial class FlowDocument : Window
    {
        public FlowDocument()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
            {
                IDocumentPaginatorSource idp = FlowDoc;
                printDialog.PrintDocument(idp.DocumentPaginator, "Flooooow");
            }
        }
    }
}
