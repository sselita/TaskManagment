using System.Data.SqlClient;
using System.Formats.Asn1;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using OfficeOpenXml;

namespace TaskManagment
{
    public partial class MainForm : Form
    {
        private string connectionString = @"Server=localhost;Database=WorkTaskDb;Trusted_Connection=True;";
        public MainForm(string username)
        {
            if (username is null || username == "Admin")
            {
                InitializeAdminComponent();
            }
            else InitializeComponent();

        }
   

        private void LoadTasks()
        {
            lstTasks.Items.Clear(); // Clear existing items

            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["TaskAppDB"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT TaskName, Department, Status FROM Tasks";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string task = $"Name: {reader["TaskName"]}, Dept: {reader["Department"]}, Status: {reader["Status"]}";
                                lstTasks.Items.Add(task);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading tasks: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // Open the TaskForm to add a new task
        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddTask taskForm = new AddTask();
          
            taskForm.ShowDialog();

        }

        // Export employees to a CSV file
        private void btnExportEmployees_Click(object sender, EventArgs e)
        {
            try
            {
              

                OpenFileDialog openFileDialog = new OpenFileDialog
                {
                
                    Title = "Select an Excel File with Employee Data"
                };

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;
                    ImportEmployeesFromCsv(selectedFilePath);
                    MessageBox.Show("Employee data successfully imported into the database.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ImportEmployeesFromCsv(string filePath)
        {
            // Read the CSV file
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
            {
                var records = csv.GetRecords<EmployeeCSV>().ToList();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    foreach (var record in records)
                    {
                        // Only insert if required fields are not empty
                        if (!string.IsNullOrEmpty(record.first_name))
                        {
                            // Assuming Id is auto-incremented in the database, remove it from the query
                            string query = @"INSERT INTO Employees 
                                     (SSN, FirstName, LastName, Gender, StreetName, StreetNumber, ZipCode, City, Email)
                                     VALUES 
                                     (@SSN, @FirstName, @LastName, @Gender, @StreetName, @StreetNumber, @ZipCode, @City, @Email)";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Id", (object)record.id ?? DBNull.Value);

                                command.Parameters.AddWithValue("@SSN", (object)record.ssn ?? DBNull.Value);
                                command.Parameters.AddWithValue("@FirstName", (object)record.first_name ?? DBNull.Value);
                                command.Parameters.AddWithValue("@LastName", (object)record.last_name ?? DBNull.Value);
                                command.Parameters.AddWithValue("@Gender", (object)record.gender ?? DBNull.Value);
                                command.Parameters.AddWithValue("@StreetName", (object)record.street_name ?? DBNull.Value);
                                command.Parameters.AddWithValue("@StreetNumber", (object)record.street_number ?? DBNull.Value);
                                command.Parameters.AddWithValue("@ZipCode", (object)record.zipcode ?? DBNull.Value);
                                command.Parameters.AddWithValue("@City", (object)record.city ?? DBNull.Value);
                                command.Parameters.AddWithValue("@Email", (object)record.email ?? DBNull.Value);
                           //  command.Parameters.AddWithValue("@Department", (object)record.Department ?? DBNull.Value);

                                command.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }

    }
}
    