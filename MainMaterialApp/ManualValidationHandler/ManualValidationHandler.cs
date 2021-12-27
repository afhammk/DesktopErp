using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;
using System.Windows.Data;

namespace MainMaterialApp.ManualValidationHandler
{
    class ManualValidationHandler
    {
        public void Trigger(TextBox textBox , string errormsg )
        {
            
            BindingExpression bindingExpression = BindingOperations.GetBindingExpression(textBox, TextBox.TextProperty);
            BindingExpressionBase bindingExpressionBase = BindingOperations.GetBindingExpressionBase(textBox, TextBox.TextProperty);

            ValidationError validationError = new ValidationError(new ExceptionValidationRule(), bindingExpression);
            validationError.ErrorContent = errormsg;
            Validation.MarkInvalid(bindingExpressionBase, validationError);

        }
    }
}
