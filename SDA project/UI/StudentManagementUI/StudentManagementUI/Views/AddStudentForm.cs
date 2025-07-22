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
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private async void btnAddStudent_Click(object sender, EventArgs e)
        {
            var student = new Student
            {
                Name = txtName.Text,
                RollNumber = txtRollNumber.Text,
                Class = txtClass.Text,
                Section = txtSection.Text
            };
            var controller = new StudentController();
            await controller.AddStudentAsync(student);

            MessageBox.Show("Student added successfully!");

        }

        private void AddStudentForm_Load(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close(); // Current form ko hide karo

            Form1 mainForm = new Form1(); // Yahan apne main form ka naam use karo
            mainForm.Show();
        }
    }
}
