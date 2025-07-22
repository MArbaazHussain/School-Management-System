using Newtonsoft.Json;
using StudentManagementUI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentManagementUI.Controllers;


namespace StudentManagementUI.Views
{
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private async void btnAddCourse_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required!");
                return;
            }

            var course = new Course
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                CreditHours = (int)numCreditHours.Value
            };

            var controller = new CourseController();
            await controller.AddCourseAsync(course);

            MessageBox.Show("Course added successfully!");

            txtTitle.Clear();
            txtDescription.Clear();
            numCreditHours.Value = 1;

            LoadCoursesAsync();
        }
            
        
        private async void LoadCoursesAsync()
        {
            var controller = new CourseController();
            var courses = await controller.GetCoursesAsync();
            dataGridCourses.DataSource = courses;
        }

       
        private async void button1_Click(object sender, EventArgs e)
        {
            if (dataGridCourses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a course to delete.");
                return;
            }

            // Select ki gayi row se ID nikaalo
            var selectedRow = dataGridCourses.SelectedRows[0];
            var course = selectedRow.DataBoundItem as Course;

            var confirm = MessageBox.Show($"Are you sure you want to delete '{course.Title}'?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                var controller = new CourseController();
                await controller.DeleteCourseAsync(course.Id);

                MessageBox.Show("Course deleted successfully!");

                LoadCoursesAsync(); // List refresh
            }

        }
        private async Task LoadCourses()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7289"); // yahan apni CourseService API ka URL daalo
                HttpResponseMessage response = await client.GetAsync("/api/course");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var courseList = JsonConvert.DeserializeObject<List<Course>>(json);
                    dataGridCourses.DataSource = courseList; // ya jis control mein dikha rahe ho
                }
            }
        }

        private async void AddCourseForm_Load(object sender, EventArgs e)
        {
            await LoadCourses();
        }


        private async void btnRefresh_Click(object sender, EventArgs e)
        {
            await LoadCourses();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide(); // AddStudentForm ko hide karo

            Form1 mainForm = new Form1(); // Form1 tumhara main form hai
            mainForm.Show();
        }
    }
}
