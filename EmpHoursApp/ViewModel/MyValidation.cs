using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Globalization;


namespace EmpHoursApp.ViewModel
{
    public class MyValidation : ValidationRule
    {

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            DateTime dob = (DateTime)value;
            return new ValidationResult(dob < DateTime.Now, "Please, enter date before Now()");
        }

        //public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        //{
        //    return new ValidationResult(false, "ErrorContent");
        //}
    }
}
