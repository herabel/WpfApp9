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

namespace WpfApp9
{
    /// <summary>
    /// Логика взаимодействия для Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Page
    {
        public Dashboard()
        {
            InitializeComponent();
            UpdateData();
        }

        private void FilterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateData();
        }

        public void UpdateData()
        {
            var list = App.context.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(SearchTB.Text))
            {
                string search = SearchTB.Text.Trim().ToLower();

                list = list.Where(x => x.ProductName.ToLower().Contains(search) || x.Description.ToLower().Contains(search));
            }

            switch (FilterCB.SelectedIndex)
            {
                case 0:
                    list = list.OrderBy(x => x.ProductName);
                    break;
                case 1: 
                    list = list.OrderByDescending(x => x.ProductName);
                    break;
                default:
                    break;
            }

            ListBox.ItemsSource = list.ToList();
        }

        private void SearchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            UpdateData();
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
