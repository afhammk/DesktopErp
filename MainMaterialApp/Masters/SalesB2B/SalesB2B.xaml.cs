using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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


namespace MainMaterialApp.Masters.SalesB2B
{

    public partial class SalesB2B : UserControl
    {
        string branchid = "1";
        string counterid = "1";
        string salesId = "0";
        string status = "0";

        QueryHandler.QueryHandler queryHandler = new QueryHandler.QueryHandler();
        ManualValidationHandler.ManualValidationHandler err = new ManualValidationHandler.ManualValidationHandler();
        ObservableCollection<Models.TableDataStructure> datagriditems = new ObservableCollection<Models.TableDataStructure>();
        ObservableCollection<Models.SalesmanOptionsDataStructure> salesmanOptions = new ObservableCollection<Models.SalesmanOptionsDataStructure>();  
        ObservableCollection<Models.PartyModel> partiesOptions = new ObservableCollection<Models.PartyModel>();
        Models.TableTotal totals = new Models.TableTotal();
        Models.BasicInfo basicinfo = new Models.BasicInfo();


        public SalesB2B()
        {
            InitializeComponent();

            B2BDatagrid.ItemsSource = datagriditems;
            TotalsGrid.DataContext = totals;
            PartySelectbox.ItemsSource = partiesOptions;
            InvoiceNoNumericField.DataContext = basicinfo;
            InvoiceDatePicker.DataContext = basicinfo;
            PartySelectbox.DataContext = basicinfo;

            datagriditems.Add(new Models.TableDataStructure());


        }

        private void screen_Loaded(object sender, RoutedEventArgs e)
        {

            setInvoiceNo();
            void setInvoiceNo()
            {
                var invoiceNoResponse = queryHandler.HandleQuery("SELECT MAX(invoiceno + 1) as invno FROM public.salesinvoices WHERE invoicetype = 'BB' LIMIT 1", "select");
                if (invoiceNoResponse != null && invoiceNoResponse.HasValues)
                {
                    status = "1";
                    basicinfo.InvoiceNo = Convert.ToDouble(invoiceNoResponse[0]["invno"].ToString());
                }
            }

            setPartyOptions();
            void setPartyOptions()
            {
                var response = queryHandler.HandleQuery("SELECT id,name,stateid FROM public.suppliers WHERE deletedat IS NULL", "select");
                if (response != null && response.HasValues)
                {
                    foreach (var item in response)
                    {
                        partiesOptions.Add(new Models.PartyModel() { Id = item["id"].ToString(), Name = item["name"].ToString(), StateId = item["stateid"].ToString() });
                    }
                }
            }

        }


        private void B2BDatagrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            var row = datagriditems[e.Row.GetIndex()];
            if (e.Column.Header.ToString() == "Barcode")
            {
                var editedTextbox = e.EditingElement as TextBox;
                var editedText = editedTextbox.Text;

                Mouse.OverrideCursor = Cursors.Wait;
                var res = queryHandler.HandleQuery($"SELECT pd.barcode,pd.itemid,pd.variantid,pd.mrp,pd.cost as price,i.hsn,CONCAT(ic.name,' ',b.name,' ',i.articlenumber,' ',iv.name) as item, CASE WHEN td.cgstrate IS NULL THEN 0 ELSE td.cgstrate END, CASE WHEN td.sgstrate IS NULL THEN 0 ELSE td.sgstrate END, CASE WHEN td.igstrate IS NULL THEN 0 ELSE td.igstrate END FROM public.purchaseitemdetails pd LEFT JOIN items i ON pd.itemid = i.id LEFT JOIN itemcategories ic ON i.categoryid = ic.id LEFT JOIN brands b ON i.brandid = b.id LEFT JOIN itemvariants iv ON pd.variantid = iv.id LEFT JOIN taxes t ON i.taxid = t.id LEFT JOIN taxdetails td ON t.id = td.taxid AND td.type= 'E' AND (pd.mrp between td.ratefrom AND td.rateto ) WHERE pd.barcode='{editedText}' ", "select");
                Mouse.OverrideCursor = null;
                
                if (res!=null && res.HasValues)
                {
                    row.No = e.Row.GetIndex().ToString();
                    row.ItemName = res[0]["item"].ToString();
                    row.Barcode = res[0]["barcode"].ToString();
                    row.ItemId = res[0]["itemid"].ToString();
                    row.VariantId = res[0]["variantid"].ToString();
                    row.HSN = String.IsNullOrEmpty(res[0]["hsn"].ToString()) ? "0" : res[0]["hsn"].ToString();
                    row.Mrp = String.IsNullOrEmpty(res[0]["mrp"].ToString()) ? "0" : res[0]["mrp"].ToString();
                    row.Price = String.IsNullOrEmpty(res[0]["price"].ToString()) ? "0" : res[0]["price"].ToString();
                    row.Cgst = "0";
                    row.Sgst = "0";
                    row.Igst = "0";
                    row.CgstDetails = res[0]["cgstrate"].ToString();
                    row.SgstDetails = res[0]["sgstrate"].ToString();
                    row.IgstDetails = res[0]["igstrate"].ToString();
                    //datagriditems[e.Row.GetIndex()].Amount = res[0]["amount"].ToString();

                    B2BDatagrid.CurrentCell = new DataGridCellInfo(B2BDatagrid.Items[e.Row.GetIndex()], B2BDatagrid.Columns[4]);
                    B2BDatagrid.BeginEdit();
                    editedTextbox.Text = editedTextbox.Text;
                }
                else
                {
                    
                    datagriditems[e.Row.GetIndex()].InvalidBarcode = true;
                    editedTextbox.Text = editedText;
                    e.Cancel = true;
                    
                }

            }
            else if (e.Column.Header.ToString() == "Qty")
            {
                var editedTextbox = e.EditingElement as TextBox;
                var editedText = editedTextbox.Text;
                if (string.IsNullOrWhiteSpace(editedText))
                {
                    datagriditems[e.Row.GetIndex()].Qty = "";
                    e.Cancel = true;
                }
                else if (!editedText.All(c => char.IsDigit(c)))
                {
                    e.Cancel = true;
                }
                else
                {
                    row.Qty = Math.Round(Convert.ToDouble(editedText)).ToString();
                    row.Cgst = Math.Round((Convert.ToDouble(row.Qty) * Convert.ToDouble(row.Mrp) * (Convert.ToDouble(row.CgstDetails) / 100)), 2).ToString();
                    row.Sgst = Math.Round((Convert.ToDouble(row.Qty) * Convert.ToDouble(row.Mrp) * (Convert.ToDouble(row.SgstDetails) / 100)), 2).ToString();
                    row.Igst = Math.Round((Convert.ToDouble(row.Qty) * Convert.ToDouble(row.Mrp) * (Convert.ToDouble(row.IgstDetails) / 100)), 2).ToString();
                    row.Amount = Math.Round((Convert.ToDouble(row.Qty) * Convert.ToDouble(row.Mrp) + Convert.ToDouble(row.Cgst) + Convert.ToDouble(row.Sgst)), 2).ToString();
                    CalculateTotals();

                    if (datagriditems.Count == e.Row.GetIndex() + 1)
                    {
                        datagriditems.Add(new Models.TableDataStructure());
                    }
                    //B2BDatagrid.CurrentCell = new DataGridCellInfo(B2BDatagrid.Items[e.Row.GetIndex()+1], B2BDatagrid.Columns[1]);
                    //B2BDatagrid.BeginEdit();
                    //editedTextbox.Text = editedTextbox.Text;
                }
            }
        }


        private void B2BDatagrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                B2BDatagrid.CommitEdit();
                e.Handled = true;
            }
            else if(e.Key == Key.Escape)
            {
                DeleteSelectedRow();
                void DeleteSelectedRow()
                {
                    datagriditems.RemoveAt(B2BDatagrid.SelectedIndex);
                    CalculateTotals();
                }
            }
        }


        private void InvoiceNoNumericField_ValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
      
            if (status == "1")
            {
                status = "0";
                return;
            }

            setMainPageDetails();
            void setMainPageDetails()
            {
                Mouse.OverrideCursor = Cursors.Wait;
                var res = queryHandler.HandleQuery($"SELECT s.id, s.invoiceno, s.invoicedate, s.partyid, s.invoicetype, s.netamount,sl.id supplierid,sl.name suppliername,sl.stateid supplier_stateid FROM public.salesinvoices s LEFT JOIN suppliers sl ON s.partyid = sl.id WHERE s.invoiceno='{basicinfo.InvoiceNo}' AND s.branchid ='{branchid}' AND s.counterid ='{counterid}' AND s.invoicetype='BB' ", "select");
                Mouse.OverrideCursor = null;

                if (res!=null && res.HasValues)
                {
                    salesId = res[0]["id"].ToString();
                    datagriditems.Clear();
                  
                    selectCombobox();
                    void selectCombobox()
                    {
                        int index = 0;
                        for (int i = 0; i < partiesOptions.Count; i++)
                        {
                            if (partiesOptions[i].Id == res[0]["supplierid"].ToString())
                            {
                                index = i;
                            }
                        }
                        PartySelectbox.SelectedIndex = index;
                    }
                    var res1 = queryHandler.HandleQuery($"SELECT s.itemid, s.variantid, s.quantity, s.mrp, s.cost, s.rate, s.igstpercentage, s.igst, s.cgstpercentage, s.cgst, s.sgstpercentage, s.sgst, s.amount, s.barcode,CONCAT(ic.name,' ',b.name,' ',i.articlenumber,' ',iv.name) as item,i.hsn FROM public.salesinvoicedetails s LEFT JOIN items i ON s.itemid = i.id LEFT JOIN itemcategories ic ON i.categoryid = ic.id LEFT JOIN brands b ON i.brandid = b.id LEFT JOIN itemvariants iv ON s.variantid = iv.id WHERE s.salesid='{salesId}';", "select");
                    if (res!=null && res1.HasValues)
                    {
                        addDataToTable();
                        void addDataToTable()
                        {
                            foreach (var item in res1)
                            {
                                datagriditems.Add(new Models.TableDataStructure()
                                {

                                    ItemName = item["item"].ToString(),
                                    Barcode = item["barcode"].ToString(),
                                    Qty = item["quantity"].ToString(),
                                    HSN = item["hsn"].ToString(),
                                    Mrp = item["mrp"].ToString(),
                                    Price = item["cost"].ToString(),
                                    Igst = item["igst"].ToString(),
                                    IgstDetails = item["igstpercentage"].ToString(),
                                    Cgst = item["cgst"].ToString(),
                                    CgstDetails = item["cgstpercentage"].ToString(),
                                    Sgst = item["sgst"].ToString(),
                                    SgstDetails = item["sgstpercentage"].ToString(),
                                    Amount = item["igst"].ToString()
                                });

                            }
                            datagriditems.Add(new Models.TableDataStructure());
                        }
                    }
                }
                else
                {
                    datagriditems.Clear();
                    datagriditems.Add(new Models.TableDataStructure());
                    CalculateTotals();
                }
            }
        }


        private void DgCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var x = e.OriginalSource as ComboBox;
            var y = x.SelectedItem as ComboBoxItem;
            datagriditems[B2BDatagrid.SelectedIndex].Salesman = y.Content.ToString();
            B2BDatagrid.CommitEdit();
        }


        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (basicinfo.PartySelected == null)
            {
                basicinfo.PartySelected = null;
                return;
            }
            if (datagriditems.Count <= 1)
            {
                MessageBox.Show("add atleast one row");
                return;
            }
            foreach (var item in datagriditems)
            {
                if (item.HasErrors.ToString() == "True")
                {
                    MessageBox.Show("Error in Table");
                    return;
                }
            }


            var partyid = PartySelectbox.SelectedItem as Models.PartyModel;
            var partyidstring = partyid.Id.ToString();
            var invDate = basicinfo.InvoiceDate.ToString("yyyy/MM/dd");

            if (salesId == "0")
            {
                var res = queryHandler.HandleQuery($"INSERT INTO public.salesinvoices( invoiceno, invoicedate, partyid, invoicetype, netamount, branchid, counterid) VALUES((SELECT MAX(invoiceno + 1) as invno FROM public.salesinvoices WHERE invoicetype = 'BB' LIMIT 1), '{invDate}', '{partyidstring}', 'BB', '{totals.TotalAmount}', '{branchid}', '{counterid}') RETURNING id;", "insert");

                if (res != null && res.HasValues)
                {
                    salesId = res[0]["id"].ToString();
                    var query = getInsertQuery();

                    var insertquery = queryHandler.HandleQuery(query, "insert");
                    if (insertquery != null)
                        MessageBox.Show("Created Succesfully");
                    else
                        MessageBox.Show("error creating");

                }
            }
            else
            {
                var partyid1 = PartySelectbox.SelectedItem as Models.PartyModel;
                var partyidstring1 = partyid.Id.ToString();
                var invDate1 = basicinfo.InvoiceDate.ToString("yyyy/MM/dd");

                var query = getInsertQuery();

                var updatequery = queryHandler.HandleQuery($"UPDATE public.salesinvoices SET invoicedate ='{invDate1}', partyid ='{partyidstring1}', netamount ='{totals.TotalAmount}' WHERE id ='{salesId}';", "update");
                if (updatequery != null)
                {
                    var deleteandinsertquery = queryHandler.HandleQuery($"DELETE FROM public.salesinvoicedetails WHERE salesid ={salesId};{query}", "deleteandinsert");
                    if (deleteandinsertquery != null)
                    {
                        MessageBox.Show("updated succesfully");
                    }
                    else
                    {
                        MessageBox.Show("error updating");
                    }
                }
            }
        }

        private string getInsertQuery()
        {
            var query = "INSERT INTO public.salesinvoicedetails(salesid, itemid, variantid, quantity, mrp, cost, rate, igstpercentage, igst, cgstpercentage, cgst, sgstpercentage, sgst, amount, barcode) VALUES";
            for (int i = 0; i < datagriditems.Count; i++)
            {
                var item = datagriditems[i];
                var str = $"({salesId},'{item.ItemId}','{item.VariantId}','{item.Qty}','{item.Mrp}','{item.Price}','{item.Price}','{item.Igst}','{item.IgstDetails}','{item.Cgst}','{item.CgstDetails}','{item.Sgst}','{item.SgstDetails}','{item.Amount}','{item.Barcode}'),";
                if (!String.IsNullOrWhiteSpace(item.Barcode) && !String.IsNullOrEmpty(item.Qty))
                {
                    query = query + str;
                }


            }
            query = query.Remove(query.Length - 1, 1);
            query = query + ";";
            return query;
        }

        public void CalculateTotals()
        {
            double totalquantity = 0;
            double totalmrp = 0;
            double totalhsn = 0;
            double totalcgst = 0;
            double totalsgst = 0;
            double totalamount = 0;
            double totalprice = 0;
            foreach (var items in datagriditems)
            {
                totalquantity += Convert.ToDouble(string.IsNullOrEmpty(items.Qty) ? 0 : Math.Round(Convert.ToDouble(items.Qty), 2));
                totalmrp += Convert.ToDouble(string.IsNullOrEmpty(items.Mrp) ? 0 : Math.Round(Convert.ToDouble(items.Mrp), 2));
                totalprice += Convert.ToDouble(string.IsNullOrEmpty(items.Price) ? 0 : Math.Round(Convert.ToDouble(items.Price), 2));
                totalhsn += Convert.ToDouble(string.IsNullOrEmpty(items.HSN) ? 0 : Math.Round(Convert.ToDouble(items.HSN), 2));
                totalcgst += Convert.ToDouble(string.IsNullOrEmpty(items.Cgst) ? 0 : Math.Round(Convert.ToDouble(items.Cgst), 2));
                totalsgst += Convert.ToDouble(string.IsNullOrEmpty(items.Sgst) ? 0 : Math.Round(Convert.ToDouble(items.Sgst), 2));
                totalamount += Convert.ToDouble(string.IsNullOrEmpty(items.Amount) ? 0 : Math.Round(Convert.ToDouble(items.Amount), 2));

            }
            totals.TotalQuantity = Math.Round(Convert.ToDouble(totalquantity), 2).ToString();
            totals.TotalMrp = Math.Round(Convert.ToDouble(totalmrp), 2).ToString();
            totals.TotalHsn = Math.Round(Convert.ToDouble(totalhsn), 2).ToString();
            totals.TotalPrice = Math.Round(Convert.ToDouble(totalprice), 2).ToString();
            totals.TotalCgst = Math.Round(Convert.ToDouble(totalcgst), 2).ToString();
            totals.TotalSgst = Math.Round(Convert.ToDouble(totalsgst), 2).ToString();
            totals.TotalAmount = Math.Round(Convert.ToDouble(totalamount), 2).ToString();
        }

        private void ScrollBar_Scroll(object sender, System.Windows.Controls.Primitives.ScrollEventArgs e)
        {
            TotalScroll.ScrollToHorizontalOffset(e.NewValue);
        }


    }
}
