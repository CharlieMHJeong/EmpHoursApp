using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EmpHoursApp.UI
{
    public class DatePickerValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            var date = (DateTime)value;

            return date.Date.CompareTo(DateTime.Now) < 0
                ? new ValidationResult(false, "the date can not be before today")
                : new ValidationResult(true, null);
        }
    }
}
