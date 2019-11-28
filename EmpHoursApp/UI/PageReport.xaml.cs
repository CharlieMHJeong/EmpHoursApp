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

using EmpHoursApp.Data;
using EmpHoursApp.ViewModel;


namespace EmpHoursApp.UI
{
    /// <summary>
    /// Interaction logic for PageReport.xaml
    /// </summary>
    public partial class PageReport : Page
    {
        private EmployeeViewModel _employeePageReportViewModel;
        private SQLActions _sql;
        private void ReloadTotalTable()
        {
            List<EmployeeViewModel> employeeViews;
            _sql = new SQLActions();
            employeeViews = _sql.GetAllEmployee();

            //ListOfEmployeeTotalHours ==> ListView.Name in xaml
            ListOfEmployeeTotalHours.ItemsSource = employeeViews;
        }
        

        public PageReport()
        {
            InitializeComponent();
            //Provide vm obj to the view
            EmployeeViewModel employeePageReportViewModel = new EmployeeViewModel()
            { EndDate = DateTime.Today, BeginDate=DateTime.Today};

            _employeePageReportViewModel = employeePageReportViewModel;
            this.DataContext = _employeePageReportViewModel;   

            ReloadTotalTable();
        }

        private void btnReloadTable_Click(object sender, RoutedEventArgs eventArgs)
        {
            ReloadTotalTable(); 
        }

        private void btnCalculateTotalHoursForThePeriod(object sender, RoutedEventArgs eventArgs)
        {
            List<EmployeeViewModel> employeeViews;
            _sql = new SQLActions();

            var _beginDate = beginDate.SelectedDate.Value.Date;
            var _endDate = endDate.SelectedDate.Value.Date;

            employeeViews = _sql.ListAllEmployeeTotalHoursForThePeriod(_beginDate, _endDate);

            //ListOfEmployeeTotalHours ==> ListView.Name in xaml
            ListOfEmployeeTotalHours.ItemsSource = employeeViews;
        }

    }
}
