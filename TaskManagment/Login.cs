using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManagment
{
    public partial class Login : Form
    {
        private string connectionString = @"Server=localhost;Database=WorkTaskDb;Trusted_Connection=True;";
        public Login()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            // Validate inputs
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Database connection string
           

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Query to check user credentials
                    string query = "SELECT COUNT(1) FROM Users WHERE Username = @Username AND Pasword = @Password";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        int result = (int)command.ExecuteScalar(); // Get the count of matching rows

                        if (result == 1)
                        {
                            MessageBox.Show("Login successful!");
                        //    GlobalUser.CurrentUser = username;
                            MainForm mainForm = new MainForm(username);
                            
                            mainForm.Show();
                            this.Hide(); // Hide the login form
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
     
        private void Register_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog (); 
        }
    }
}
