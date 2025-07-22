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
    public partial class UpdateStudentForm : Form
    {
        private List<Student> studentList = new List<Student>();
        public UpdateStudentForm()
        {
            InitializeComponent();
        }

        private async void UpdateStudentForm_Load(object sender, EventArgs e)
        {
            var controller = new StudentController();
            studentList = await controller.GetStudentsAsync();

            comboBoxStudents.DataSource = studentList;
            comboBoxStudents.DisplayMember = "Name";
            comboBoxStudents.ValueMember = "Id";

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            if (comboBoxStudents.SelectedItem is Student selected)
            {
                txtName.Text = selected.Name;
                txtRollNumber.Text = selected.RollNumber;
                txtClass.Text = selected.Class;
                txtSection.Text = selected.Section;
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (comboBoxStudents.SelectedItem is Student selected)
            {
                selected.Name = txtName.Text;
                selected.RollNumber = txtRollNumber.Text;
                selected.Class = txtClass.Text;
                selected.Section = txtSection.Text;
                var controller = new StudentController();
                await controller.UpdateStudentAsync(selected);

                MessageBox.Show("Student updated successfully!");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // AddStudentForm ko hide karo

            Form1 mainForm = new Form1(); // Form1 tumhara main form hai
            mainForm.Show();
        }
    }
}
