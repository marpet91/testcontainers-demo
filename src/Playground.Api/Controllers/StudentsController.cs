using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Playground.Api.Data;

namespace Playground.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class StudentsController : ControllerBase
{
    private readonly SchoolContext _context;

    public StudentsController(SchoolContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Student>> GetAsync()
    {
        return await _context.Students.ToListAsync();
    }

    [HttpPost]
    [Route("{name}")]
    public async Task<IResult> CreateStudentAsync([FromRoute] string name)
    {
        var student = new Student
        {
            LastName = name,
            EnrollmentDate = DateTime.UtcNow
        };

        _context.Students.Add(student);
        await _context.SaveChangesAsync();
        return Results.Ok();
    }
}