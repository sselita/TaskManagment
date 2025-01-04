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
            var statusi = cbStatus.SelectedItem;
            var emp = cbEmployee.SelectedItem;
            var ded = dtpDeadline.Text;
            Status statusss = (Status)Enum.Parse(typeof(Status), statusi.ToString());
            int intValue = (int)statusss;
            var empID = GetEmployeeByName(emp.ToString());
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();


                    string insertQuery = "INSERT INTO Tasks (Title,Description,Status,Deadline,EmployeeId)  VALUES (@Title,@Description,@Status,@Deadline,@EmployeeId)";
                    SqlCommand sCommand = new SqlCommand(insertQuery, connection);

                    sCommand.Parameters.AddWithValue("@Title", Title);
                    sCommand.Parameters.AddWithValue("@Description", desc);
                    sCommand.Parameters.AddWithValue("@Status", intValue);
                    sCommand.Parameters.AddWithValue("@Deadline", ded);
                    sCommand.Parameters.AddWithValue("@EmployeeId", empID);


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
    
       public int GetEmployeeByName(string name)
        {

            int id = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection("Server=localhost;Database=WorkTaskDB;Trusted_Connection=True;"))
                {
                    connection.Open();

                    string queryIng = "SELECT Id FROM Employees where FirstName = @firstname";
                    SqlCommand commanding = new SqlCommand(queryIng, connection);
                    commanding.Parameters.AddWithValue("@firstname", name);

                    using (SqlDataReader reader = commanding.ExecuteReader())
                    {
                        while (reader.Read())
                        {

                            id = reader.GetInt32(0);



                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return id;
        }
    } }
