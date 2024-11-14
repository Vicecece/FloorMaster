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

namespace FloorMaster
{
    /// <summary>
    /// Логика взаимодействия для PartnerPage.xaml
    /// </summary>
    public partial class PartnerPage : Page
    {
        int CountRecords = FloorMasterEntities.GetContext().Partners.Count();
        public PartnerPage()
        {
            InitializeComponent();
            var currentPartner = FloorMasterEntities.GetContext().Partners.ToList();
            var typePartner = FloorMasterEntities.GetContext().TypePartners.ToList();
            PartnersListView.ItemsSource = currentPartner;
            TballRecords.Text = "Записей: " + CountRecords + " из " + CountRecords;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddAndReductPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                FloorMasterEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                PartnersListView.ItemsSource = FloorMasterEntities.GetContext().Partners.ToList();
            }
            CountRecords = FloorMasterEntities.GetContext().Partners.Count();
            UpdatePatners();
        }

        private void UpdatePatners()
        {
            var currentBooks = FloorMasterEntities.GetContext().Partners.ToList();

            var CountRecordsNew = currentBooks.Count;
            TballRecords.Text = "Записей: " + CountRecordsNew + " из " + CountRecords;

            PartnersListView.ItemsSource = currentBooks;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (((sender as Button).DataContext as Partners).Rating <= 2)
            {
                if (MessageBox.Show("Вы точно хотите выполнить удаление?", "Внимание", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    FloorMasterEntities.GetContext().Partners.Remove((sender as Button).DataContext as Partners);
                    FloorMasterEntities.GetContext().SaveChanges();

                    PartnersListView.ItemsSource = FloorMasterEntities.GetContext().Partners.ToList();
                    CountRecords -= 1;
                    UpdatePatners();
                }

            }
            else
            {
                MessageBox.Show("Невозможно удалить", "Ошибка");
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddAndReductPage((sender as Button).DataContext as Partners));
        }
    }
}
