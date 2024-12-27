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

        private void InitializeComponent()
        {
            this.btnAddTask = new System.Windows.Forms.Button();
        
            this.lstTasks = new System.Windows.Forms.ListBox();
            this.lblTasks = new System.Windows.Forms.Label();

      
            this.btnAddTask.Location = new System.Drawing.Point(20, 20);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(120, 40);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Update Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(20, 100);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(260, 160);
            this.lstTasks.TabIndex = 2;

         
            this.lblTasks.AutoSize = true;
            this.lblTasks.Location = new System.Drawing.Point(20, 80);
            this.lblTasks.Name = "lblTasks";
            this.lblTasks.Size = new System.Drawing.Size(42, 15);
            this.lblTasks.TabIndex = 3;
            this.lblTasks.Text = "Tasks:";

            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.lblTasks);
            this.Controls.Add(this.lstTasks);
            this.Controls.Add(this.btnExportEmployees);
            this.Controls.Add(this.btnAddTask);
            this.Name = "MainForm";
            this.Text = "Task Manager";
            this.ResumeLayout(false);
            this.PerformLayout();
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
            this.btnAddTask.Location = new System.Drawing.Point(20, 20);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(120, 40);
            this.btnAddTask.TabIndex = 0;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);

            // 
            // btnExportEmployees
            // 

            this.btnExportEmployees.Location = new System.Drawing.Point(160, 20);
            this.btnExportEmployees.Name = "btnExportEmployees";
            this.btnExportEmployees.Size = new System.Drawing.Size(120, 40);
            this.btnExportEmployees.TabIndex = 1;
            this.btnExportEmployees.Text = "Export Employees";
            this.btnExportEmployees.UseVisualStyleBackColor = true;
            this.btnExportEmployees.Click += new System.EventHandler(this.btnExportEmployees_Click);

            // 
            // lstTasks
            // 
            this.lstTasks.FormattingEnabled = true;
            this.lstTasks.Location = new System.Drawing.Point(20, 100);
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size(260, 160);
            this.lstTasks.TabIndex = 2;

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
            this.ClientSize = new System.Drawing.Size(300, 300);
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