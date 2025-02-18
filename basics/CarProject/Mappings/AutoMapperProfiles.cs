using AutoMapper;
using CarProject.DTOs;
using CarProject.Models;

namespace CarProject.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Car, CarDTO.GetCarDto>().ReverseMap();  //Car modelimi CarDTO'ya çevir. Bazen de CarDTO'dan Car modele çevirmek için "ReverseMap" kullanıyoruz.
            CreateMap<Car, CarDTO.CreateCarDto>().ReverseMap();
            CreateMap<Car, CarDTO.UpdateCarDto>().ReverseMap();
        }
    }
}
