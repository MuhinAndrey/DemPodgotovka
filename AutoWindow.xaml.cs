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
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace DemSecond
{
    public partial class AutoWindow : Window
    {
        DataBase dataBase = new DataBase();
        public AutoWindow()
        {
            InitializeComponent();
        }

        private void Auto_Button_Click(object sender, RoutedEventArgs e)
        {

            var _login = Login_Auto.Text.Trim();
            var _password = Password_Auto.Password.Trim();

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            string zapros = $"select login, password from Registration where login = '{_login}' and password = '{_password}'";

            SqlCommand command = new SqlCommand(zapros, dataBase.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if(table.Rows.Count == 1)
            {
                MessageBox.Show("Авторизация успешна!");
                Hide();
                new CabinetWindow().ShowDialog();
                ShowDialog();
            }
            else
            {
                MessageBox.Show("Авторизация не успешна!");
            }
        }
    }
}
