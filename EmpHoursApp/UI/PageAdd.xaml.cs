using System;
using System.Collections.Generic;
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

using EmpHoursApp.ViewModel;
using EmpHoursApp.Data;

namespace EmpHoursApp.UI
{
    /// <summary>
    /// Interaction logic for PageAdd.xaml
    /// </summary>
    public partial class PageAdd : Page
    {
        private EmployeeViewModel _employee;
        private SQLActions _sql;

        public PageAdd()
        {
            InitializeComponent();

            EmployeeViewModel employee = new EmployeeViewModel();
            _employee = employee;
            this.DataContext = employee;

            //Setting Default for dob
            //_employee.Dob = DateTime.Today;
            
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs eventArgs)
        {
            _sql = new SQLActions();
            _sql.InsertNewEmployee(_employee.FirstName, _employee.LastName, _employee.Email, _employee.Dob, _employee.Phone);
        }
        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            _employee.FirstName = "";
            _employee.LastName = "";
            _employee.Email = "";
            _employee.Dob = DateTime.Today;
            _employee.Phone = "";
        }
    }
}
