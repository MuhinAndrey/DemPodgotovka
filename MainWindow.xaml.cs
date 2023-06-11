using System.Windows;
using System.Data.SqlClient;

namespace DemSecond
{
    public partial class MainWindow : Window
    {
        DataBase dataBase = new DataBase();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            var _login = Login_Reg.Text.Trim();
            var _password1 = Password1_Reg.Password.Trim();
            var _password2 = Password2_Reg.Password.Trim();

            if(_password1 == _password2)
            {
                string zapros = $"insert into Registration (login, password) values('{_login}','{_password1}')";

                SqlCommand command = new SqlCommand(zapros, dataBase.GetConnection());

                dataBase.OpenConnection();

                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Всё ок!!");
                    Hide();
                    new AutoWindow().ShowDialog();
                    ShowDialog();
                }
                else
                {
                    MessageBox.Show("Не ок!!");
                }

            }
            else
            {
                MessageBox.Show("Не ок!!");
            }
        }

        private void Auto_Button_Click(object sender, RoutedEventArgs e)
        {
            Hide();
            new AutoWindow().ShowDialog();
            ShowDialog();
        }
    }
}
