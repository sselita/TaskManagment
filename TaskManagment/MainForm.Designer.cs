﻿using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace TaskManagment
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnExportEmployees;
        private System.Windows.Forms.ListBox lstTasks;
        private System.Windows.Forms.Label lblTasks;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        private System.Windows.Forms.ComboBox cmbStatus; // ComboBox for status

        private void InitializeComponent(string username)
        {
            this.btnAddTask = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.lblTasks = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();

            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(20, 20);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(120, 40);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Update Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.UpdateTaskButton_Click);

            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new System.Drawing.Point(160, 30); // Adjusted position
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(120, 23);
            this.cmbStatus.TabIndex = 1;
            this.cmbStatus.Items.AddRange(new string[] { "Open", "In_Progress", "Completed", "Blocked", "Cancelled" });

            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(20, 100);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(460, 160); // Increased width
            this.lstTasks.TabIndex = 2;
            this.lstTasks.DataSource = GetTaskByUsername(username);

            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.Location = new System.Drawing.Point(20, 80);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(42, 15);
            this.lblTasks.TabIndex = 3;
            this.lblTasks.Text = "Tasks:";

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 300); // Increased width
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblTasks);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.btnAddTask);
            this.Name = "MainForm";
            this.Text = "Task Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        public List<Task> GetTaskByUsername(string username)
        {
            List<Task> tasks = new List<Task>();

            try
            {
                using (SqlConnection connection = new SqlConnection("Server=localhost;Database=WorkTaskDB;Trusted_Connection=True;"))
                {
                    connection.Open();

                    string query = "SELECT t.Id , t.Title , T.Description , t.Status FROM Tasks t INNER JOIN Employees e ON t.EmployeeId = e.Id INNER JOIN Users u ON e.Email = u.Email WHERE u.Email = @UserName ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@UserName", username);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Task task = new Task
                            {
                                Title = reader.GetString(1), // Name
                                Description = reader.GetString(2),
                                Id = reader.GetInt32(0),
                                status =(Status)reader.GetInt32(3)
                            };
                          
                            tasks.Add(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return tasks;
        }
      
        public List<Task> GetAdminTask()
        {
            List<Task> tasks = new List<Task>();

            try
            {
                using (SqlConnection connection = new SqlConnection("Server=localhost;Database=WorkTaskDB;Trusted_Connection=True;"))
                {
                    connection.Open();

                    string query = "SELECT Id,Title,Description, Status FROM Tasks ";
                    SqlCommand command = new SqlCommand(query, connection);
                  
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Task task = new Task
                            {
                                Id = reader.GetInt32(0),
                                
                               Title = reader.GetString(1),   // Name
                              Description = reader.GetString(2),
                                status = (Status)reader.GetInt32(3)

                            };
                            tasks.Add(task);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }

            return tasks;
        }
        private void InitializeAdminComponent()
        {
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnExportEmployees = new System.Windows.Forms.Button();
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.lblTasks = new System.Windows.Forms.Label();

            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(20, 20); // Leave some padding from the left
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(120, 40);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            // 
            // btnExportEmployees
            // 
            this.btnExportEmployees.Location = new System.Drawing.Point(160, 20); // Positioned next to Add Task button
            this.btnExportEmployees.Name = "btnExportEmployees";
            this.btnExportEmployees.Size = new System.Drawing.Size(160, 40); // Increased width for better UI
            this.btnExportEmployees.TabIndex = 1;
            this.btnExportEmployees.Text = "Export Employees";
            this.btnExportEmployees.UseVisualStyleBackColor = true;
            this.btnExportEmployees.Click += new System.EventHandler(this.btnExportEmployees_Click);

            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(20, 100); // Below the buttons
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(460, 200); // Increased width and height to match form width
            this.lstTasks.TabIndex = 2;

            var tasks = GetAdminTask();
            this.lstTasks.DataSource = tasks;

            // 
            // lblTasks
            // 
            this.lblTasks.AutoSize = true;
            this.lblTasks.Location = new System.Drawing.Point(20, 80); // Positioned above the task list
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(42, 15);
            this.lblTasks.TabIndex = 3;
            this.lblTasks.Text = "Tasks:";

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(500, 400); // Increased form width and height
            this.Controls.Add(this.lblTasks);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.btnExportEmployees);
            this.Controls.Add(this.btnAddTask);
            this.Name = "MainForm";
            this.Text = "Task Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}