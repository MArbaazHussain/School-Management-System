using Newtonsoft.Json;
using System.Net.Http.Json;
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

namespace StudentManagementUI.Views
{
    public partial class AssignCourseForm : Form

    {

        public AssignCourseForm()
        {
            InitializeComponent();
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;

        }

        private async void AssignCourseForm_Load(object sender, EventArgs e)
        {
            using (HttpClient client = new HttpClient())
            {
                // Load Students

                var studentResponse = await client.GetAsync("http://localhost:7207/api/student");
                if (studentResponse.IsSuccessStatusCode)
                {
                    var json = await studentResponse.Content.ReadAsStringAsync();
                    var students = JsonConvert.DeserializeObject<List<Student>>(json);
                    cmbStudent.DataSource = students;
                    cmbStudent.DisplayMember = "Name";
                    cmbStudent.ValueMember = "Id";
                }

                // Load Courses
                var courseResponse = await client.GetAsync("https://localhost:7289/api/course");
                if (courseResponse.IsSuccessStatusCode)
                {
                    var json = await courseResponse.Content.ReadAsStringAsync();
                    var courses = JsonConvert.DeserializeObject<List<Course>>(json);
                    cmbCourse.DataSource = courses;
                    cmbCourse.DisplayMember = "Title";
                    cmbCourse.ValueMember = "Id";
                }
            }
        }

        private async void btnAssign_Click(object sender, EventArgs e)
        {
            var studentId = (int)cmbStudent.SelectedValue;
            var courseId = (int)cmbCourse.SelectedValue;

            var data = new
            {
                StudentId = studentId,
                CourseId = courseId
            };

            using (HttpClient client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(data);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://localhost:7176/api/StudentCourse", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("🎉 Course assigned successfully!");
                }
                else
                {
                    MessageBox.Show("❌ Failed: " + response.StatusCode);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // AddStudentForm ko hide karo

            Form1 mainForm = new Form1(); // Form1 tumhara main form hai
            mainForm.Show();
        }
    }
}
