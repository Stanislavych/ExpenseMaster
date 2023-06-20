﻿using AutoMapper;
using ExpenseMaster.BusinessLogic.Dto;
using ExpenseMaster.BusinessLogic.Infrastructure.Cryptography;
using ExpenseMaster.DAL.Models;

namespace ExpenseMaster.BusinessLogic.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserRegistrationDto, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.Ignore())
            .ForMember(dest => dest.PasswordSalt, opt => opt.Ignore())
            .AfterMap((src, dest) =>
            {
                PasswordHasher.CreatePasswordHash(src.Password, out byte[] passwordHash, out byte[] passwordSalt);
                dest.PasswordHash = passwordHash;
                dest.PasswordSalt = passwordSalt;
            })
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(_ => 1))
            .ReverseMap()
            .ForMember(dest => dest.Password, opt => opt.Ignore());

            CreateMap<User, UserDto>()
    .ReverseMap();

            CreateMap<Role, RoleDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToString()))
                .ReverseMap();

            CreateMap<UserUpdateDto, User>()
                .ForMember(dest=>dest.PasswordHash, opt=>opt.Ignore())
                .ForMember(dest=>dest.PasswordSalt, opt=>opt.Ignore())
                .AfterMap((src,dest) =>
                {
                    PasswordHasher.CreatePasswordHash(src.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    dest.PasswordHash = passwordHash;
                    dest.PasswordSalt = passwordSalt;
                })
                .ReverseMap()
                .ForMember(dest=>dest.Password, opt =>opt.Ignore());
        }
    }
}
