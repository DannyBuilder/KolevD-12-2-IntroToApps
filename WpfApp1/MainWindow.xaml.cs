using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        string sqlCon = @"Data Source=LAB108PC18\SQLEXPRESS; Initial Catalog=SignUp; Integrated Security=True;";

        //string sqlCon = "SERVER NAME/DATABASE NAME/Protected or not"


    

        private void Insert_(object sender, RoutedEventArgs e)
        {
            //establish the connection

            SqlConnection conn = new SqlConnection(sqlCon);

            try
            {
                //open the conneciton to the db 
                conn.Open();

                //create the query 

                string query = $"Insert into Credentials_table(Username,FirstName,LastName,Email,Password) values ('{txtUsername.Text}','{txtFName.Text}','{txtLastName.Text}','{txtEmail.Text}','{pswdBox.Password}')";
                //establish the conn between the query and the db

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success it works fine!");

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

   



        }

        private void Update_(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);
            try
            {
                conn.Open();
                string query = $"Update Credentials SET FirstName = '{txtFName.Text}',LastName = '{txtLastName.Text}',Email = '{txtEmail.Text}', Password = '{pswdBox.Password}' WHERE UserName = '{txtUsername.Text}'";
                SqlCommand sqlCom = new SqlCommand(query, conn);
                sqlCom.ExecuteNonQuery();
                MessageBox.Show("You have successfully updated data");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void Delete_(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(sqlCon);
            try
            {
                conn.Open();
                string query = $"Delete from Credentials where UserName = '{txtUsername.Text}'";
                SqlCommand sqlCom = new SqlCommand(query, conn);
                sqlCom.ExecuteNonQuery();
                MessageBox.Show("You have successfully deleted data");
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }
    }
}
