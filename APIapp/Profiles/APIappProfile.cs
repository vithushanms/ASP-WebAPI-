using AutoMapper;
using System;
using APIapp.Models;
using APIapp.DTOs;

namespace APIapp.Profiles
{
    public class APIappProfile : Profile
    {
        public APIappProfile()
        {
            CreateMap<appCommands, APIappControllerRead>();
        }
    }
}