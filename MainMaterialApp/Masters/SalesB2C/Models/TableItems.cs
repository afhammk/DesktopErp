using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MainMaterialApp.Masters.SalesB2C.Models
{
    class TableItems
    {
        private ObservableCollection<Models.TableDataStructure> itemsindatagrid;
        public ObservableCollection<Models.TableDataStructure> ItemsInDataGrid
        {
            get { return itemsindatagrid; }
            set
            {
                itemsindatagrid = value;
             
            }
        }
    }
}
