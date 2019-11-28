using HamburgerMenu;
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

namespace EmpHoursApp.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private void HamburgerMenuItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            HamburgerMenuItem item = sender as HamburgerMenuItem;
            if (item != null)
            {
                switch (item.Text)
                {
                    case "Add":
                        //https://stackoverflow.com/questions/777843/wpf-frame-source-refreshing-the-loaded-page
                        //this.ContentFrame.Navigate(new Uri("/PageAdd.xaml", UriKind.RelativeOrAbsolute));
                        this.ContentFrame.Source = new System.Uri("PageAdd.xaml", UriKind.Relative);
                        break;

                    case "Manage":
                        //this.ContentFrame.NavigationService.Navigate("PageManage.xaml");
                        this.ContentFrame.Source = new System.Uri("PageManage.xaml", UriKind.Relative);
                        break;

                    case "Report":
                        //this.ContentFrame.NavigationService.Navigate("PageReport.xaml");
                        this.ContentFrame.Source = new System.Uri("PageReport.xaml", UriKind.Relative);
                        break;
                }
            }
        }
    }
}
