﻿using AutoMapper;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models;

namespace OzeSomeAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Customer Mapping
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Address.Code))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country))
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street));
            CreateMap<CustomerDto, Customer>()
                .ForMember(c => c.Address, i => i.MapFrom(dto => 
                new Address() { City = dto.City, Code = dto.Code, Street = dto.Street, Country = dto.Country, 
                    Number = dto.Number, CreationDateTime = DateTime.UtcNow, EditDateTime = DateTime.UtcNow, IsActive = true }));
            // XXX Mapping
        }
    }
}
