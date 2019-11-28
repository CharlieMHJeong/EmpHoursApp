using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace EmpHoursApp.ViewModel
{
    public class EmployeeViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        public EmployeeViewModel()
        {
            Employees = new ObservableCollection<Employee>();
        }

        private int empId;
        private string firstName;
        private string lastName;
        private string email;
        private DateTime dob;
        private string phone;
        private DateTime workDate;
        private double totalHours;
        private double hours;
        private DateTime beginDate;
        private DateTime endDate;

        public int EmpId
        {
            get { return empId; }
            set { empId = value; OnPropertyChanged("EmpId"); }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; OnPropertyChanged("FirstName"); }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; OnPropertyChanged("LastName"); }
        }

        public string Email
        {
            get { return email; }
            set { email = value; OnPropertyChanged("Email"); }
        }

        public DateTime Dob
        {
            get { return dob; }
            set { dob = value; OnPropertyChanged("Dob"); }
        }

        public DateTime WorkDate
        {
            get { return workDate; }
            set { workDate = value; OnPropertyChanged("WorkDate"); }
        }

        public string Phone
        {
            get { return phone; }
            set { phone = value; OnPropertyChanged("Phone"); }
        }

        public double TotalHours
        {
            get { return totalHours; }
            set { totalHours = value; OnPropertyChanged("TotalHours"); }
        }
        public double Hours
        {
            get { return hours; }
            set { hours = value; OnPropertyChanged("Hours"); }
        }

        public DateTime BeginDate
        {
            get { return beginDate; }
            set { beginDate = value; OnPropertyChanged("BeginDate"); }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; OnPropertyChanged("EndDate"); }
        }


        public ObservableCollection<Employee> Employees { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        // Validation

        public string Error
        {
            get
            {
                return null;
            }
        }
        //var model = new ValidationViewModel
        //modle
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "FirstName")
                {
                    if (string.IsNullOrEmpty(FirstName))
                    {
                        result = "FirstName is a mandatory field!";
                    }
                }
                if (columnName == "LastName")
                {
                    if (string.IsNullOrEmpty(LastName))
                    {
                        result = "LastName is a mandatory field!";
                    }
                }

                if (columnName == "Email")
                {
                    if (string.IsNullOrEmpty(Email))
                    {
                        result = "Email a mandatory field!";
                    }
                    else if(!EmailValidation.IsValidEmailAddress(Email))
                    {
                        result = "The emails address is not valid!!";
                    }
                }

                if (columnName == "Phone")
                {
                    if (string.IsNullOrEmpty(Phone))
                    {
                        result = "Phone is a mandatory field!";
                    }
                }

                if (columnName == "Dob")
                {
                    DateTime hundredYearsPast = DateTime.Now.AddYears(-100);

                    if (Dob.Equals(null))
                    {
                        result = "Dob is a mandatory field!";
                    }

                    else if (Dob.CompareTo(DateTime.Now) > 0)
                    {
                        result = "Dob should be in the past!";
                    }
                    //else if(DateTime.Compare(hundredYearsPast, DateTime.Now.AddYears(-100))< 1)
                    else if(Dob < hundredYearsPast)
                    {
                        result = "Dob not should be in the 100+ years past";
                    }
                }

                if (columnName == "WorkDate")
                {
                    DateTime tenYearsPast = DateTime.Now.AddYears(-10);

                    if (WorkDate.Equals(null))
                    {
                        result = "WorkDate is a mandatory field!";
                    }

                    else if (WorkDate.CompareTo(DateTime.Now) >= 0)
                    {
                        result = "WorkDate should be in the past or Today!";
                    }
                    //else if(DateTime.Compare(hundredYearsPast, DateTime.Now.AddYears(-100))< 1)
                    else if (WorkDate < tenYearsPast)
                    {
                        result = "WorkDate should not be in 10+ year past";
                    }                 
                }

                if (columnName == "Hours")
                {
                    if (Hours <= 0 || Hours > 24)
                    {
                        result = "Hours must be between 0 and 24";
                    }
                }

                if (columnName == "BeginDate")
                {
                    DateTime tenYearsPast = DateTime.Now.AddYears(-10);

                    if (BeginDate.Equals(null))
                    {
                        result = "BeginDate is a mandatory field to Calculate TotalHours for the period!";
                    }

                    else if (BeginDate.CompareTo(DateTime.Now) >= 0)
                    {
                        result = "BeginDate should be in the past or Today!";
                    }
                    //else if(DateTime.Compare(hundredYearsPast, DateTime.Now.AddYears(-100))< 1)
                    else if (BeginDate < tenYearsPast)
                    {
                        result = "BeginDate should not be in 10+ year past";
                    }
                }

                if (columnName == "EndDate")
                {
                    DateTime tenYearsPast = DateTime.Now.AddYears(-10);

                    if (EndDate.Equals(null))
                    {
                        result = "EndDate is a mandatory field to Calculate TotalHours for the period!";
                    }

                    else if (EndDate.CompareTo(DateTime.Now) >= 0)
                    {
                        result = "EndDate should be in the past or Today!";
                    }
                    //else if(DateTime.Compare(hundredYearsPast, DateTime.Now.AddYears(-100))< 1)
                    else if (EndDate < tenYearsPast)
                    {
                        result = "EndDate should not be in 10+ year past";
                    }
                }

                return result;
            }
        }




    }
}
