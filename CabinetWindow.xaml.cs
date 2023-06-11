using System.Linq;
using System.Windows;

namespace DemSecond
{
    public partial class CabinetWindow : Window
    {
        public CabinetWindow()
        {
            InitializeComponent();
            Grid.ItemsSource = DemEntities.GetContext().Registration.ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Удалить?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var _userDel = Grid.SelectedItem as Registration;

                DemEntities.GetContext().Registration.Remove(_userDel);
                DemEntities.GetContext().SaveChanges();

                MessageBox.Show("Гуд!");

                Grid.ItemsSource = DemEntities.GetContext().Registration.ToList();
            }
        }
    }
}
