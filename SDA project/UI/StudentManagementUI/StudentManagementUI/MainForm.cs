using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementUI.Views;
namespace StudentManagementUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddStudentForm form = new AddStudentForm();
            form.ShowDialog();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new btnDelete();
            form.ShowDialog();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateStudentForm form = new UpdateStudentForm();
            form.ShowDialog();
            this.Hide();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AddCourseForm form = new AddCourseForm();
            form.ShowDialog();
            this.Hide();
        }

        private void btnAssignCourse_Click(object sender, EventArgs e)
        {
            AssignCourseForm assignForm = new AssignCourseForm();
            assignForm.ShowDialog();
            this.Hide();
        }

     

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
