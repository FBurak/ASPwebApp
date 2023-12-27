﻿using ASPwebApp.Entities;
using ASPwebApp.Models;
using AutoMapper;

namespace ASPwebApp
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<User,UserModel>().ReverseMap();
            CreateMap<User,CreateUserModel>().ReverseMap();
            CreateMap<User,EditUserModel>().ReverseMap();
            CreateMap<Doctor,DoctorModel>().ReverseMap();
            CreateMap<Doctor,CreateDoctorModel>().ReverseMap();
            CreateMap<Doctor,EditDoctorModel>().ReverseMap();

        }
    }
}
