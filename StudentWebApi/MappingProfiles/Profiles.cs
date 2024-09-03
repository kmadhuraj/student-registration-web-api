using AutoMapper;
using Student.Domain.Entities;
using StudentWebApi.DTOs;

namespace StudentWebApi.MappingProfiles
{
    public class Profiles:Profile
    {
        public Profiles()
        {
            CreateMap<StudentDetailsDTO,StudentDetails>();
            CreateMap<QualificationDTO,Qualifications>();
            CreateMap<StudentHobbiesDTO, StudentHobbies>();
        }
    }
}
