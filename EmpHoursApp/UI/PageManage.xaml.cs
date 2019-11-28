using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PageManage.xaml
    /// </summary>
    public partial class PageManage : Page
    {
        private EmployeeViewModel _employeeViewModel;
        private void ReloadTheTable()
        {
            List<EmployeeViewModel> employeeViews;
            _sql = new SQLActions();
            employeeViews = _sql.GetAllEmployee();
            ListOfEmployees.ItemsSource = employeeViews;
            
        }        
        private SQLActions _sql;
        

        public PageManage()
        {
            InitializeComponent();

            ////Provide vm obj to the view

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            _employeeViewModel = employeeViewModel;                        
            this.DataContext = employeeViewModel;

            //_employeeViewModel.Dob = DateTime.Today;
            //euWorkDate.SelectedDate = DateTime.Today;
            _employeeViewModel.WorkDate = DateTime.Today;



            ReloadTheTable();
        }

        private void btnReloadTable_Click(object sender, RoutedEventArgs e)
        {
            ReloadTheTable();
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            this.euWorkDate.SelectedDate = this.euWorkDate.SelectedDate;

            int empId = int.Parse(euEmpId.Text);            
            string firstName = euFirstName.Text;
            string lastName = euLastName.Text;
            string email = euEmail.Text;
            DateTime dob = (DateTime)euDob.SelectedDate;
            string phone = euPhone.Text;

            try
            {
                _sql = new SQLActions();
                _sql.UpdateEmployee(empId, firstName, lastName, email, dob, phone);                              
            }
            catch
            {
                MessageBox.Show("Not Connected to DB", "Error!");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            //euEmpId.Text = "";
            euFirstName.Text = "";
            euLastName.Text = "";
            euEmail.Text = "";
            euDob.SelectedDate = DateTime.Today;
            euPhone.Text = "";
            euHours.Text = "";
            euWorkDate.SelectedDate = DateTime.Today;
            ReloadTheTable();
        }

        private void btnRecordHours_Click(object sender, RoutedEventArgs e)
        {
            int empId = int.Parse(euEmpId.Text);
            DateTime workDate = (DateTime)euWorkDate.SelectedDate;
            double hours = double.Parse(euHours.Text);
            

            try
            {
                _sql = new SQLActions();
                _sql.InsertEmpHours(empId, workDate, hours);                
                ReloadTheTable();
            }
            catch
            {
                MessageBox.Show("Not Connected to DB", "Error!");
            }
        }

        private void ListofEmployoees_MouseDoubleClckHandler(object sender, MouseButtonEventArgs e)
        {
            //Double Click the record to pick up the record
            // row.DataContext got the Data from the selected row.

            var item = sender as ListViewItem;
            if (item != null)
            {                
                this.DataContext = item.Content;
                _employeeViewModel.WorkDate = DateTime.Today;
            }
           
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[.][0-9]+$|^[0-9]*[.]{0,1}[0-9]*$");
            e.Handled = !regex.IsMatch((sender as TextBox).Text.Insert((sender as TextBox).SelectionStart, e.Text));
            //foreach (char ch in e.Text)
            //    if (!(Char.IsDigit(ch) || ch.Equals('.')))
            //    {
            //        e.Handled = true;
            //    }
        }

        //private void ListofEmployoees_MouseLeftButtonDownHandler(object sender, MouseButtonEventArgs e)
        //{
        //    //Double Click the record to pick up the record
        //    // row.DataContext got the Data from the selected row.
        //    var item = sender as ListViewItem;
        //    if(item != null)
        //    {
        //        this.DataContext = item.Content;
        //    }
        //    _employeeViewModel.WorkDate = DateTime.Today;
        //}

    }
}
