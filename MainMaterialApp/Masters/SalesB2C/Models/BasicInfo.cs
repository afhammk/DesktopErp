using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace MainMaterialApp.Masters.SalesB2C.Models
{

    public class BasicInfo : INotifyPropertyChanged, INotifyDataErrorInfo
    {

        public event PropertyChangedEventHandler PropertyChanged;

        private string mobile { get; set; }
        public string Mobile
        {
            get { return mobile; }
            set
            {
                mobile = value;
                ValidateMobile(false);
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
               // ValidateName();
                OnPropertyRaised("Name");

            }

        }
        private string place { get; set; }
        public string Place
        {
            get { return place; }
            set
            {
                place = value;
               // ValidateName();
                OnPropertyRaised("Place");

            }

        }


        private void OnPropertyRaised(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }

        /*--------------------Error--------------------------------*/

        private Dictionary<string, List<string>> propertyErrors = new Dictionary<string, List<string>>();

        public bool HasErrors => propertyErrors.Any();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public IEnumerable GetErrors(string propertyName)
        {
            return propertyErrors.ContainsKey(propertyName) ?
                propertyErrors[propertyName] : null;
        }

        private void OnErrorsChanged(string propertyName)
        {
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        }

        public void ValidateMobile(bool x)
        {
            ClearErrors(nameof(Mobile));
            if (string.IsNullOrWhiteSpace(Mobile))
                AddError(nameof(Mobile), "Mobile cannot be empty.");
            else if (string.Equals(Mobile, "Admin", StringComparison.OrdinalIgnoreCase))
                AddError(nameof(Mobile), "Admin is not valid Mobile.");

            if (x.ToString() == "True")
                AddError(nameof(Mobile), "user not found");



        }
        public void ValidateName()
        {
            ClearErrors(nameof(Name));
            if (string.IsNullOrWhiteSpace(Name))
                AddError(nameof(Name), "Name cannot be empty.");
            else if (string.Equals(Name, "Admin", StringComparison.OrdinalIgnoreCase))
                AddError(nameof(Name), "Admin is not valid Name.");
            else if (Name == null || Name?.Length <= 5)
                AddError(nameof(Name), "Mobile must be at least 6 characters long.");


        }
        private void AddError(string propertyName, string error)
        {
            if (!propertyErrors.ContainsKey(propertyName))
                propertyErrors[propertyName] = new List<string>();

            if (!propertyErrors[propertyName].Contains(error))
            {
                propertyErrors[propertyName].Add(error);
                OnErrorsChanged(propertyName);
            }
        }

        private void ClearErrors(string propertyName)
        {
            if (propertyErrors.ContainsKey(propertyName))
            {
                propertyErrors.Remove(propertyName);
                OnErrorsChanged(propertyName);
            }
        }
    }

}
