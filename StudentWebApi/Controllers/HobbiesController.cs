using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Student.Application.Abstractions;
using Student.Domain.Entities;

namespace StudentWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public HobbiesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> AddHobbies(Hobbies hobby)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.HobbiesRepository.AddAsync(hobby);
                return StatusCode(201, "Hobby added successfully");
            }
            return StatusCode(400, "Please provide valid data ");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHobbbies()
        {
            var hobbies = await _unitOfWork.HobbiesRepository.GetAll();
            if (hobbies != null)
            {
                return Ok(hobbies);

            }
            return StatusCode(500, "Unable to fetch the data.");

        }

        [HttpGet("Hobbies{id}")]
        public async Task<IActionResult> GetHobbiesById(int id) {
            var hobbie=await _unitOfWork.HobbiesRepository.GetById(id);   
            if(hobbie != null)
            {
                return Ok(hobbie);
            }
            return StatusCode(404, "Student does not exist");
        }

        [HttpPut("Hobbies{id}")]
        public async Task<IActionResult> UpdateHobbies(int id,Hobbies hobbie)
        {
            var existHobbie =await  _unitOfWork.HobbiesRepository.GetById(id);
            if(existHobbie != null)
            {
                return StatusCode(404, "Hobbie does not exist");
            }
            if(ModelState.IsValid)
            {
                existHobbie.Hobbie = hobbie.Hobbie;
                return Ok(existHobbie);
            }
            return StatusCode(404, "Invalid data");
        }

        [HttpDelete("Hobbies{id}")]
        public async Task<IActionResult> DeleteHobbie(int id)
        {
            var hobbies = await _unitOfWork.HobbiesRepository.GetById(id);
            if (hobbies != null)
            {
                await  _unitOfWork.HobbiesRepository.DeleteAsync(hobbies);
                return StatusCode(204, "Successfully deleted");
            }
            return StatusCode(404, "Hobbie does not exist");
        }

    }
}
