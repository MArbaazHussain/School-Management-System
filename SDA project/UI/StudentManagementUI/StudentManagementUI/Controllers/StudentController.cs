using StudentManagementUI.Models;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

public class StudentController
{
    private readonly HttpClient _client;

    public StudentController()
    {
        _client = new HttpClient();
        _client.BaseAddress = new Uri("http://localhost:7207/");    
    }

    public async Task<List<Student>> GetStudentsAsync()
    {
        return await _client.GetFromJsonAsync<List<Student>>("api/student");
    }

    public async Task AddStudentAsync(Student student)
    {
        await _client.PostAsJsonAsync("api/student", student);
    }

    public async Task UpdateStudentAsync(Student student)
    {
        await _client.PutAsJsonAsync($"api/student/{student.Id}", student);
    }

    public async Task DeleteStudentAsync(int id)
    {
        await _client.DeleteAsync($"api/student/{id}");
    }
}