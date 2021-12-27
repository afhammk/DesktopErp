using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Syncfusion;

namespace MainMaterialApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTUxNjczQDMxMzkyZTM0MmUzMFZXNHV6eDNyekhTcVRzb2dxUUdLVEFhRnJQQ3ZmVGZNL1VZMm9TQlpveXc9");
        }
        
    }
}
