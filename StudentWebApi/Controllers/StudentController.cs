using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Abstractions;
using Student.Domain.Entities;
using Student.Infrastructure;
using StudentWebApi.DTOs;
namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public StudentController(IUnitOfWork unitOfWork, IMapper mapper)
        {

            _unitOfWork = unitOfWork;
            _mapper = mapper;


        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var getStudent = await _unitOfWork.StudentDetailsRepository.GetAll();
            if (getStudent != null)
            {

                return Ok(getStudent);

            }
            return StatusCode(500, "Unexpected error occured");
        }

        [HttpGet("Student/{studentId}")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            //var getStudentById = _studentInterface.GetStudentById(studentId);
            var getStudentById = await _unitOfWork.StudentDetailsRepository.GetById(studentId);
            if (getStudentById != null)
            {
                return Ok(getStudentById);
            }
            return StatusCode(404, "Student not found");
        }

        [HttpPost]
        public async Task<IActionResult> Addstudent([FromBody] StudentDetailsDTO studentDto)
        {
            if (studentDto != null)
            {

                //_studentInterface.AddStudent(student);
                var student = _mapper.Map<StudentDetails>(studentDto);
                await _unitOfWork.StudentDetailsRepository.AddAsync(student);
                return StatusCode(201, "Student Successfully created");
            }
            return StatusCode(400, "Bad Request,please enter proper data");

        }

        [HttpPut("Student/{Id}")]
        public async Task<IActionResult> UpdateStudent(int Id, StudentDetailsDTO studentDto)
        {
            if (studentDto != null)
            {

                //var existStudent = await _studentInterface.GetStudentById(Id);

                var existStudent = await _unitOfWork.StudentDetailsRepository.GetById(Id);
                if (existStudent != null)
                {
                    existStudent.Address = studentDto.Address;
                    existStudent.City = studentDto.City;
                    existStudent.State = studentDto.State;
                    existStudent.DateOfBirth = studentDto.DateOfBirth;
                    existStudent.MobileNumber = studentDto.MobileNumber;
                    //existStudent.Gender = studentDto.Gender;
                    existStudent.FirstName = studentDto.FirstName;
                    existStudent.LastName = studentDto.LastName;
                    existStudent.CourseID = studentDto.CourseID;
                    existStudent.Country = studentDto.Country;
                    existStudent.Pincode = studentDto.Pincode;
                    existStudent.EmailD = studentDto.EmailD;
                    //var existStudent = _mapper.Map<StudentDetails>(studentDto);

                    await _unitOfWork.StudentDetailsRepository.UpdateAsync(existStudent);
                    return StatusCode(200, "Successfully Updated");
                }
                else
                {
                    return StatusCode(404, "The student does not exist");

                }

            }
            return StatusCode(400, "please enter proper data");

        }

        [HttpDelete("Student/{Id}")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            //var student= _studentInterface.GetStudentById(Id);
            var student = await _unitOfWork.StudentDetailsRepository.GetById(Id);
            if (student != null)
            {

                await _unitOfWork.StudentDetailsRepository.DeleteAsync(student);
                return StatusCode(204, "Student Successfully Deleted");
            }
            return StatusCode(404, "No Data found");
        }



    }
}
