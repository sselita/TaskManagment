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
            var desc = txtDescription.Text;
            var status =cbStatus.SelectedItem;
            var emp = cbEmployee.SelectedItem;
            var ded = dtpDeadline.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string insertQuery = "INSERT INTO Task (Title,Description,Status,Deadline,EmployeeId)  VALUES (@Title,@Description,@Status,@Deadline,@EmployeeId)";
                    SqlCommand sCommand = new SqlCommand(insertQuery, connection);

                    sCommand.Parameters.AddWithValue("@Title", Title);
                    sCommand.Parameters.AddWithValue("@Description", desc);
                    sCommand.Parameters.AddWithValue("@Status", status);
                    sCommand.Parameters.AddWithValue("@Deadline", ded);
                    sCommand.Parameters.AddWithValue("@EmployeeId", emp);


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
