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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TaskManagment
{
    public partial class AddTask : Form
    {
        private string connectionString = @"Server=localhost;Database=WorkTaskDb;Trusted_Connection=True;";
        public AddTask()
        {
            InitializeComponent();
        }
        private void btnSaveTask_Click(object sender, EventArgs e)
        {
         
            var Title = txtTitle.Text;


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string insertQuery = "INSERT INTO Task (Title,)  VALUES (@Title,)";
                    SqlCommand sCommand = new SqlCommand(insertQuery, connection);

                    double basePrice = 2.0;
                    sCommand.Parameters.AddWithValue("@Name", Title);
                    //sandwichCommand.Parameters.AddWithValue("@Name", Name);

                    sCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}");
            }


            // Close the form and return to MainForm
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
