using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace SUPERSERVICE_MYHITOVA
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        int devider = 1000;
        int currentPage = 1;
        int possible_pages;
        public ServicePage()
        {
            InitializeComponent();            
            Update();
        }

        void Update()
        {
            var clients = MUHITOV_LANGUAGEEntities.GetContext().Client.ToList();




            int init = clients.Count();
            possible_pages = clients.Count() / devider;
            if (possible_pages == 0)
                possible_pages = 1;
            if (devider < clients.Count())
            {
                clients.RemoveRange(currentPage * devider, clients.Count() - currentPage * devider);
                clients.RemoveRange(0, (currentPage - 1) * devider);
            }

            int remain = clients.Count();
            RemainRecords.Text = remain.ToString();
            InitRecords.Text = init.ToString();
            RemainPages.Text = currentPage.ToString();
            InitPages.Text = possible_pages.ToString();


            ServiceListView.ItemsSource = clients;
        }

        private void GoLeftPage_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage != 1)
                currentPage--;
            Update();
        }

        private void GoRightPage_Click(object sender, RoutedEventArgs e)
        {
            if(currentPage < possible_pages)
                currentPage++;
            Update();
        }

        private void By10_Click(object sender, RoutedEventArgs e)
        {
            devider = 10;
            currentPage = 1;
            Update();
        }

        private void By50_Click(object sender, RoutedEventArgs e)
        {
            devider = 50;
            currentPage = 1;
            Update();
        }

        private void By200_Click(object sender, RoutedEventArgs e)
        {
            devider = 200;
            currentPage = 1;
            Update();
        }

        private void AllRecords_Click(object sender, RoutedEventArgs e)
        {
            devider = 1000;
            currentPage = 1;
            Update();
        }
    }
}
