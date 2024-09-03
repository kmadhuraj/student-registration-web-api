using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Abstractions;
using Student.Domain.Entities;
using StudentWebApi.DTOs;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentHobbiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentHobbiesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;   
        }
        [HttpPost]
        public async Task<IActionResult> AddStudentHobbies(StudentHobbiesDTO hobby)
        {
            if (ModelState.IsValid)
            {
                var mappedHobbie = _mapper.Map<StudentHobbies>(hobby);
                await _unitOfWork.StudentHobbiesRepository.AddAsync(mappedHobbie);
                return StatusCode(201, "Student Hobby added successfully");
            }
            return StatusCode(400, "Please provide valid data ");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudentHobbbies()
        {
            var hobbies = await _unitOfWork.StudentHobbiesRepository.GetAll();
            if (hobbies != null)
            {
                return Ok(hobbies);

            }
            return StatusCode(500, "Unable to fetch the data.");

        }

        [HttpGet("StudentHobbies{id}")]
        public async Task<IActionResult> GetHobbiesById(int id)
        {
            var hobbie = await _unitOfWork.StudentHobbiesRepository.GetById(id);
            if (hobbie != null)
            {
                return Ok(hobbie);
            }
            return StatusCode(404, "Hobbie does not exist");
        }

        [HttpPut("StudentHobbies{id}")]
        public async Task<IActionResult> UpdateHobbies(int id, StudentHobbiesDTO hobbie)
        {
            var existHobbie = await _unitOfWork.StudentHobbiesRepository.GetById(id);
            if (existHobbie != null)
            {
                return StatusCode(404, "Hobbie does not exist");
            }
            if (ModelState.IsValid)
            {
                var mappedHobbie=_mapper.Map<StudentHobbies>(hobbie);
                //existHobbie.Hobbie = hobbie.Hobbie;
                return Ok(mappedHobbie);
            }
            return StatusCode(404, "Invalid data");
        }

        [HttpDelete("StudentHobbies{id}")]
        public async Task<IActionResult> DeleteHobbie(int id)
        {
            var hobbies = await _unitOfWork.StudentHobbiesRepository.GetById(id);
            if (hobbies != null)
            {
                await _unitOfWork.StudentHobbiesRepository.DeleteAsync(hobbies);
                return StatusCode(204, "Successfully deleted");
            }
            return StatusCode(404, "Hobbie does not exist");
        }
        
        
    }
}
