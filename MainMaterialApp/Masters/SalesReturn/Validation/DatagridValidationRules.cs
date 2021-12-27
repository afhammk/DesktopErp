using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows.Controls;

namespace MainMaterialApp.Masters.SalesReturn.Validation
{
    class DatagridValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string valueToValidate = value as string;
            if (String.IsNullOrWhiteSpace(valueToValidate))
            {
                return new ValidationResult(false, "Barcode is empty");
            }

            return new ValidationResult(true, null);
        }
    }
}
