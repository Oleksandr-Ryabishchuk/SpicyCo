using AutoMapper;
using SpicyCo.DataAccessLayer.Dtos;
using SpicyCo.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyCo.DataAccessLayer.Helpers
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            //CreateMap<User, UserForRegisterDto>();
            CreateMap<User, UserForRegisterDto>().ReverseMap();

            CreateMap<User, UserForListDto>()
                .ForMember(m => m.Age, opt =>
                {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                }).ReverseMap();
            
            CreateMap<User, UserForDetailedDto>()
                .ForMember(dest => dest.Age, opt => {
                    opt.MapFrom(d => d.DateOfBirth.CalculateAge());
                });
            
            CreateMap<UserForUpdateDto, User>();

           
        }
    }
}
