using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Abstractions;
using Student.Domain.Entities;
using System.Data.SqlTypes;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CoursesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(Courses course)
        {
            if(ModelState.IsValid) {
                await _unitOfWork.CourseRepository.AddAsync(course);
                return StatusCode(201, "New Course added Successfully");
            
            }
            return StatusCode(400, "Enter the proper Data");
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCourses()
        {
            var courses=await _unitOfWork.CourseRepository.GetAll();
            if (courses != null)
            {
                return Ok(courses);

            }
            return StatusCode(500, "Internal Server Error");


        }
        [HttpGet("Courses {id}")]
        public async Task<IActionResult> GetCourseById(int id) {
            var course=await _unitOfWork.CourseRepository.GetById(id);
            if(course != null)
            {
                return Ok(course);
            }
            return StatusCode(404, "Student does not exist");
        }

        [HttpPut("Courses{id}")]
        public async Task<IActionResult> UpdateCourse(int id,Courses course)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);

            }
            var existCourse = await _unitOfWork.CourseRepository.GetById(id);
            if(existCourse != null)
            {
                existCourse.CourseName = course.CourseName;
                _unitOfWork.CourseRepository.UpdateAsync(existCourse);
                return Ok(existCourse);
            }
            return StatusCode(404, "Course not found");
        }
        [HttpDelete("Courses{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            var course = await _unitOfWork.CourseRepository.GetById(id);
            if (course != null)
            {
                await _unitOfWork.CourseRepository.DeleteAsync(course);
                return StatusCode(204, "Successfully deleted");
            }
            return StatusCode(404, "Student does not exist");
        }
    }
}
