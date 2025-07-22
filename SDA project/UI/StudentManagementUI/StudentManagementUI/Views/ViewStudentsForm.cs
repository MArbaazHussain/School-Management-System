using StudentManagementUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentManagementUI.Views
{
    public partial class btnDelete : Form
    {
        public btnDelete()
        {
            InitializeComponent();
        }

        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            var controller = new StudentController();
            var students = await controller.GetStudentsAsync();
            dataGridViewStudents.DataSource = students;
        }

        private async void ViewStudentsForm_Load(object sender, EventArgs e)
        {
            var controller = new StudentController();
            var students = await controller.GetStudentsAsync();
            dataGridViewStudents.DataSource = students;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this student?", "Confirm", MessageBoxButtons.YesNo);
                Student student = null;
                if (confirm == DialogResult.Yes)
                {
                    // Get selected student from DataGridView
                    var selectedRow = dataGridViewStudents.SelectedRows[0];
                    student = selectedRow.DataBoundItem as Student;
                }
                if (student != null)
                {
                    var controller = new StudentController();
                    await controller.DeleteStudentAsync(student.Id);

                    MessageBox.Show("Student deleted successfully!");

                    // Refresh Data
                    var students = await controller.GetStudentsAsync();
                    dataGridViewStudents.DataSource = students;
                }

            }
            else
            {
                MessageBox.Show("Please select a student row first.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide(); // AddStudentForm ko close karo

            Form1 mainForm = new Form1(); // Form1 tumhara main form hai
            mainForm.Show();
        }
    }
}

