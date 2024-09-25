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
    public class StudentRegisterController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public StudentRegisterController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;

        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentRegisterDTO StudentReg)
        {
            if (StudentReg == null)
            {

                return StatusCode(400, "Bad Request,please enter proper data");
            }
            var studentDetails = new StudentDetails();
            {
                studentDetails.ID = StudentReg.StudentID;
                studentDetails.FirstName = StudentReg.FirstName;
                studentDetails.LastName = StudentReg.LastName;
                studentDetails.Address = StudentReg.Address;
                studentDetails.MobileNumber = StudentReg.MobileNumber;
                // studentDetails.Gender = StudentReg.Gender;
                studentDetails.State = StudentReg.State;
                studentDetails.City = StudentReg.City;
                studentDetails.Country = StudentReg.Country;
                studentDetails.EmailD = StudentReg.EmailD;
                studentDetails.Pincode = StudentReg.Pincode;
                studentDetails.DateOfBirth = StudentReg.DateOfBirth;
                studentDetails.CourseID = StudentReg.CourseID;
            }
            await _unitOfWork.StudentDetailsRepository.AddAsync(studentDetails);

            var qualifications = new Qualifications()
            {
                StudentID = studentDetails.ID, // Use the generated StudentID
                ClassXBoard = StudentReg.ClassXBoard,
                ClassXPercentage = StudentReg?.ClassXPercentage == null ? 0 : StudentReg.ClassXPercentage,
                ClassXYearOfPassing = StudentReg.ClassXYearOfPassing,
                ClassX11Board = StudentReg.ClassX11Board,
                Class11Percentage = StudentReg.Class11Percentage,
                ClassX11YearOfPassing = StudentReg.ClassX11YearOfPassing,
                GraduationBoard = StudentReg.GraduationBoard,
                GraduationPercentage = StudentReg.GraduationPercentage,
                GraduationYearOfPasssing = StudentReg.GraduationYearOfPasssing,
                MastersBoard = StudentReg.MastersBoard,
                MastersPercentage = StudentReg.MastersPercentage,
                MastersYearOfPasssing = StudentReg.MastersYearOfPasssing
            };
            await _unitOfWork.QualificationsRepository.AddAsync(qualifications);

            foreach (var hobbyDto in StudentReg.Hobbies)
            {
                var hobby = new StudentHobbiesDTO
                {
                    StudentID = studentDetails.ID,
                    Hobbie = hobbyDto.Hobbie
                };
                var hobbyModel = new StudentHobbies();
                {
                    hobbyModel.StudentID = hobby.StudentID;
                    hobbyModel.Hobbie = hobby.Hobbie;
                }
                await _unitOfWork.StudentHobbiesRepository.AddAsync(hobbyModel);
            }

            return StatusCode(201, "Student Registration Successfull");
        }

        [HttpGet]
        public async Task<IActionResult> GetRegister()
        {
            var getStudent = await _unitOfWork.StudentDetailsRepository.GetAll();
            var getCourse = await _unitOfWork.CourseRepository.GetAll();
            var getQualification = await _unitOfWork.QualificationsRepository.GetAll();
            var getHobbie = await _unitOfWork.StudentHobbiesRepository.GetAll();
            if (getStudent == null || !getStudent.Any())
            {
                return StatusCode(500, "Unexpected error occured while retriving data");
            }

            // Create a list to hold the combined data
            var studentRegisterDetails = new List<StudentRegisterDTO>();

            foreach (var student in getStudent)
            {
                // Get related courses, qualifications, and hobbies for each student
                var studentCourses = getCourse.Where(c => c.CourseID == student.CourseID).FirstOrDefault();
                var studentQualifications = getQualification.FirstOrDefault(q => q.StudentID == student.ID);

                var studentHobbies = getHobbie.Where(h => h.ID == student.ID).Select(h => new StudentHobbiesDTO // Map each hobby entity to StudentHobbiesDTO
                {
                    Hobbie = h.Hobbie, // Adjust based on your actual property names
                    StudentID = h.StudentID
                }).ToList();  // Adjust based on how hobbies are linked

                // Create a DTO object for each student
                var studentRegister = new StudentRegisterDTO()
                {
                    StudentID = student.ID,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    MobileNumber = student.MobileNumber,
                    Address = student.Address,
                    State = student.State,
                    City = student.City,
                    // Gender = student.Gender,
                    EmailD = student.EmailD,
                    Pincode = student.Pincode,
                    DateOfBirth = student.DateOfBirth,
                    Country = student.Country,


                    // Use the generated StudentID
                    ClassXBoard = studentQualifications?.ClassXBoard,
                    ClassXPercentage = studentQualifications?.ClassXPercentage == null ? 0 : studentQualifications.ClassXPercentage,
                    ClassXYearOfPassing = studentQualifications?.ClassXYearOfPassing == null ? 0 : studentQualifications.ClassXYearOfPassing,
                    ClassX11Board = studentQualifications?.ClassX11Board,
                    Class11Percentage = studentQualifications?.Class11Percentage == null ? 0 : studentQualifications.Class11Percentage,
                    ClassX11YearOfPassing = studentQualifications?.ClassX11YearOfPassing == null ? 0 : studentQualifications.ClassX11YearOfPassing,
                    GraduationBoard = studentQualifications?.GraduationBoard,
                    GraduationPercentage = studentQualifications?.GraduationPercentage == null ? 0 : studentQualifications.GraduationPercentage,
                    GraduationYearOfPasssing = studentQualifications?.GraduationYearOfPasssing == null ? 0 : studentQualifications.GraduationYearOfPasssing,
                    MastersBoard = studentQualifications?.MastersBoard,
                    MastersPercentage = studentQualifications?.MastersPercentage == null ? 0 : studentQualifications.MastersPercentage,
                    MastersYearOfPasssing = studentQualifications?.MastersYearOfPasssing == null ? 0 : studentQualifications.MastersYearOfPasssing,


                    CourseID = studentCourses.CourseID,
                    //CourseName = studentCourses.CourseName,

                    Hobbies = studentHobbies

                };
                // Add to the result list
                studentRegisterDetails.Add(studentRegister);
            }
            return Ok(studentRegisterDetails);
        }



    }





}

