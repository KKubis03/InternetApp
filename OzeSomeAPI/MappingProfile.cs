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
                .ForMember(dest => dest.Street, opt => opt.MapFrom(src => src.Address.Street))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Address.Number))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Address.Code))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.Address.City))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Address.Country));
            CreateMap<CustomerDto, Customer>();
            // Address Mapping
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
            // Category Mapping
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            // Note Mapping
            CreateMap<Note, NoteDto>();
            CreateMap<NoteDto, Note>();
            // Order Mapping
            CreateMap<Order, OrderDto>();
            CreateMap<OrderDto, Order>();
            // Product Mapping
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<ProductDto, Product>();
            // User Mapping
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
            // OrderDetail Mapping
            CreateMap<OrderDetail, OrderDetailsDto>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.Order.OrderDate))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.Order.OrderStatus))
                .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Product.Category.CategoryName))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price));
            CreateMap<OrderDetailsDto, OrderDetail>();
            // Meeting Mapping
            CreateMap<Meeting, MeetingDto>()
                .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.LastName));
            CreateMap<MeetingDto, Meeting>();
            // Document Mapping
            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentDto, Document>();
            // Contract Mapping
            CreateMap<Contract, ContractDto>()
                .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.Order.OrderDate))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.Order.OrderStatus));
            CreateMap<ContractDto, Contract>();
            // OrderDetail Mapping
            CreateMap<OrderDetail, OrderDetailsDto>()
                .ForMember(dest => dest.OrderDate, opt => opt.MapFrom(src => src.Order.OrderDate))
                .ForMember(dest => dest.OrderStatus, opt => opt.MapFrom(src => src.Order.OrderStatus))
                .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Product.Category.CategoryName))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price));
            CreateMap<OrderDetailsDto, OrderDetail>();
            // Task Mapping
            CreateMap<OzeSome.Data.Models.Task, TaskDto>();
            CreateMap<TaskDto, OzeSome.Data.Models.Task>();

            
        }
    }
}
