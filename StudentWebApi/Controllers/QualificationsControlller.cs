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
    public class QualificationsControlller : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        public QualificationsControlller(IUnitOfWork unitOfWork, IMapper mapper,ApplicationDbContext _context)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddQualification(Qualifications qualifications)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.QualificationsRepository.AddAsync(qualifications);
                return StatusCode(201, "Hobby added successfully");
            }
            return StatusCode(400, "Please provide valid data ");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQualification()
        {
            var qualifications = await _unitOfWork.QualificationsRepository.GetAll();
            if (qualifications != null)
            {
                return Ok(qualifications);

            }
            return StatusCode(500, "Unable to fetch the data.");

        }

        [HttpGet("Qualifications{id}")]
        public async Task<IActionResult> GetQualificationById(int id)
        {
            var qualification = await _unitOfWork.QualificationsRepository.GetById(id);
            if (qualification != null)
            {
                return Ok(qualification);
            }
            return StatusCode(404, "Student does not exist");
        }

        [HttpPut("Hobbies{id}")]
        public async Task<IActionResult> UpdateQualification(int id,QualificationDTO qualification )
        {
            //var existqualification = await _unitOfWork.HobbiesRepository.GetById(id);
            var existQual = await _context.Qualifications.FindAsync(id);
            if (existQual != null)
            {
                return StatusCode(404, "Hobbie does not exist");
            }
            if (ModelState.IsValid)
            {

                var mappedQalification = _mapper.Map<Qualifications>(qualification);
               // existqualification.Hobbie = qualification;
                return Ok(mappedQalification);
            }
            return StatusCode(400, "Invalid data");
        }

        [HttpDelete("Hobbies{id}")]
        public async Task<IActionResult> DeleteQualification(int id)
        {
            var qualification = await _unitOfWork.QualificationsRepository.GetById(id);
            if (qualification != null)
            {
                await _unitOfWork.QualificationsRepository.DeleteAsync(qualification);
                return StatusCode(204, "Successfully deleted");
            }
            return StatusCode(404, "Qualification does not exist");
        }
    }
}
