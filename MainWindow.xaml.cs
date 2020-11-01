using System.Collections.Generic;
using System.Windows;

namespace db_controller
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        DB db;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            txtQuery.Text = "SELECT * FROM customers WHERE mobile = @mobile";
            txtName.Text = "@mobile";
            txtValue.Text = "1234";
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            db = new DB(txtConnectionString.Text);
            lblStatus.Content = "Connection is OPEN";
            btnNonQuery.IsEnabled = btnScalar.IsEnabled = btnQuery.IsEnabled = true;
        }

        private async void btnQuery_Click(object sender, RoutedEventArgs e)
        {
            var results = await db.query(txtQuery.Text, new Dictionary<string, object> { { txtName.Text, txtValue.Text } });
            lblStatus.Content = $"row count: {results.Rows.Count}";
            dgvData.ItemsSource = results.DefaultView;
        }

        private async void btnScalar_Click(object sender, RoutedEventArgs e)
        {

            var result = await db.scalar(txtQuery.Text, new Dictionary<string, object> { { txtName.Text, txtValue.Text } });
            lblStatus.Content = $"result: {result}";
        }

        private async void btnNonQuery_Click(object sender, RoutedEventArgs e)
        {

            var result = await db.nonQuery(txtQuery.Text, new Dictionary<string, object> { { txtName.Text, txtValue.Text } });
            lblStatus.Content = $"updated rows count: {result}";
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            txtQuery.Text = "INSERT INTO customers (mobile) VALUES (@mobile)";
            txtName.Text = "@mobile";
            txtValue.Text = "1234";
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            txtQuery.Text = "UPDATE customers SET points = points + 1 WHERE mobile = @mobile";
            txtName.Text = "@mobile";
            txtValue.Text = "1234";
        }
    }
}
