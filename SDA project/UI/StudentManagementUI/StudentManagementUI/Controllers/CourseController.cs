using StudentManagementUI.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace StudentManagementUI.Controllers
{ 
public class CourseController
{
    private readonly HttpClient _client;

    public CourseController()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("https://localhost:7289/"); // ⬅️ CourseService API ka URL daalo yahan
    }

    public async Task AddCourseAsync(Course course)
    {
        await _client.PostAsJsonAsync("api/course", course);
    }

    public async Task<List<Course>> GetCoursesAsync()
    {
        return await _client.GetFromJsonAsync<List<Course>>("api/course");
    }


    public async Task DeleteCourseAsync(int courseId)
    {
        await _client.DeleteAsync($"api/course/{courseId}");
    }

    public async Task UpdateCourseAsync(Course course)
    {
        await _client.PutAsJsonAsync($"api/course/{course.Id}", course);
    }




    // Baad mein Get, Update, Delete bhi add karenge
}
}