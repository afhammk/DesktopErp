using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace MainMaterialApp.Masters.SalesReturn
{
    /// <summary>
    /// Interaction logic for SalesReturn.xaml
    /// </summary>
    
    public partial class SalesReturn : UserControl
    {
       
        BasicInfo obj = new BasicInfo();
        ObservableCollection<string> obj2 = new ObservableCollection<string>();

        ObservableCollection<Models.TableDataStructure> datagriditems = new ObservableCollection<Models.TableDataStructure>();
        QueryHandler.QueryHandler queryHandler = new QueryHandler.QueryHandler();
        ManualValidationHandler.ManualValidationHandler err = new ManualValidationHandler.ManualValidationHandler();

        public SalesReturn()
        {
            InitializeComponent();
            MobileTextBox.DataContext = obj;
            NameTextBox.DataContext = obj;
            InsideDatagrid.ItemsSource = datagriditems;
            datagriditems.Add(new Models.TableDataStructure());

           
            obj2.Add("Male");
            obj2.Add("Female");
            Gender.ItemsSource = obj2;
        }

        private void MobileTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                TextBox txtBox = sender as TextBox;
            }
        }

        private void NameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
           

        }

        private void InsideDatagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

            //if (e.Column.Header.ToString() == "Barcode")
            //{
            //    var editedTextbox = e.EditingElement as TextBox;
            //    var editedText = editedTextbox.Text;


            //    var res = queryHandler.HandleQuery($"select * from public.\"BarcodeItems\" where barcode='{editedText}'","select");

            //    if (res.HasValues)
            //    {
            //        datagriditems[e.Row.GetIndex()].Id = e.Row.GetIndex().ToString();
            //        datagriditems[e.Row.GetIndex()].Item = res[0]["item"].ToString();
            //        datagriditems[e.Row.GetIndex()].Barcode = res[0]["barcode"].ToString();
            //        datagriditems[e.Row.GetIndex()].Mrp = res[0]["mrp"].ToString();
            //        datagriditems[e.Row.GetIndex()].Discount = res[0]["discount"].ToString();
            //        datagriditems[e.Row.GetIndex()].Cgst = res[0]["cgst"].ToString();
            //        datagriditems[e.Row.GetIndex()].Sgst = res[0]["sgst"].ToString();
            //        datagriditems[e.Row.GetIndex()].Amount = res[0]["amount"].ToString();
            //        datagriditems[e.Row.GetIndex()].Details = res[0]["item"].ToString();
            //        datagriditems[e.Row.GetIndex()].CgstDetails = res[0]["cgst"].ToString();
            //        datagriditems[e.Row.GetIndex()].SgstDetails = res[0]["sgst"].ToString();
            //        datagriditems[e.Row.GetIndex()].DiscountDetails = res[0]["discount"].ToString();


            //        InsideDatagrid.CurrentCell = new DataGridCellInfo(InsideDatagrid.Items[e.Row.GetIndex()], InsideDatagrid.Columns[3]);
            //        InsideDatagrid.BeginEdit();
            //        editedTextbox.Text = editedTextbox.Text;

            //        if (datagriditems.Count == e.Row.GetIndex() + 1)
            //        {
            //            datagriditems.Add(new Models.TableDataStructure());
            //        }
            //    }
            //    else
            //    {
            //        e.Cancel = true;
            //        err.Trigger(editedTextbox, "Barcode not found");
            //    }

            //}
            //else if (e.Column.Header.ToString() == "Qty")
            //{
            //    var editedTextbox = e.EditingElement as TextBox;
            //    var editedText = editedTextbox.Text;
            //    if (string.IsNullOrWhiteSpace(editedText) || string.IsNullOrEmpty(datagriditems[e.Row.GetIndex()].Barcode))
            //    {
            //        e.Cancel = true;
            //    }
            //    else
            //    {

            //        InsideDatagrid.CurrentCell = new DataGridCellInfo(InsideDatagrid.Items[e.Row.GetIndex()], InsideDatagrid.Columns[9]);
            //        InsideDatagrid.BeginEdit();

            //    }

            //}
            //else if (e.Column.Header.ToString() == "Salesman")
            //{
            //    InsideDatagrid.CurrentCell = new DataGridCellInfo(InsideDatagrid.Items[datagriditems.Count - 1], InsideDatagrid.Columns[1]);
            //    InsideDatagrid.BeginEdit();
            //}

        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            FlowDocument.FlowDocument obj = new FlowDocument.FlowDocument();
            obj.Show();
        }
    }

    public class BasicInfo : INotifyPropertyChanged, IDataErrorInfo
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string mobile { get; set; }
        public string Mobile
        {
            get { return mobile; }
            set
            {
              
                mobile = value;
                OnPropertyRaised("Mobile");

            }

        }

        private string name { get; set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyRaised("Name");

            }

        }



        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        /*----------------------------Error Validation---------------------------------*/

        public string Error
        {
            get
            {
                return string.Empty;
            }
        }

        public string this[string propertyName]
        {
            get
            {
                return GetErrorForProperty(propertyName);
            }
        }

        private string GetErrorForProperty(string propertyName)
        {
            switch (propertyName)
            {
                case "Mobile":
                    if (Mobile?.Length > 6)
                        return "length should be less";
                    else if (Mobile?.Length < 3)
                        return "length should be more";

                    else
                    {
                        return string.Empty;
                    }
                    
                case "Name":
                    if (Name?.Length > 5)
                        return "Name length should be less";
                    else
                        return string.Empty;
                default:
                    return string.Empty;
            }
        }
    }
}
