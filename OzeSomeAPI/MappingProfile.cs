using AutoMapper;
using OzeSome.Data.Models.Dtos;
using OzeSome.Data.Models;
using OzeSome.Data.Models.Dtos.New;

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
            CreateMap<NewCustomerDto, Customer>();
            // Address Mapping
            CreateMap<Address, AddressDto>();
            CreateMap<AddressDto, Address>();
            CreateMap<NewAddressDto, Address>();
            // Category Mapping
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryDto, Category>();
            CreateMap<NewCategoryDto, Category>();
            // Note Mapping
            CreateMap<Note, NoteDto>();
            CreateMap<NoteDto, Note>();
            CreateMap<NewNoteDto, Note>();
            // Order Mapping
            CreateMap<Order, OrderDto>()
                .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.OrderStatusName, opt => opt.MapFrom(src => src.OrderStatus.StatusName));
            CreateMap<OrderDto, Order>();
            CreateMap<NewOrderDto, Order>();
            // Product Mapping
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.CategoryName));
            CreateMap<ProductDto, Product>();
            CreateMap<NewProductDto, Product>();
            // Meeting Mapping
            CreateMap<Meeting, MeetingDto>()
                .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.Customer.FirstName))
                .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.Customer.LastName))
                .ForMember(dest => dest.MeetingStatusName, opt => opt.MapFrom(src => src.MeetingStatus.StatusName));
            CreateMap<MeetingDto, Meeting>();
            CreateMap<NewMeetingDto, Meeting>();
            // Document Mapping
            CreateMap<Document, DocumentDto>();
            CreateMap<DocumentDto, Document>();
            CreateMap<NewDocumentDto, Document>();
            // Task Mapping
            CreateMap<OzeSome.Data.Models.Task, TaskDto>()
                .ForMember(dest => dest.TaskStatusName, opt => opt.MapFrom(src => src.TaskStatus.StatusName));
            CreateMap<TaskDto, OzeSome.Data.Models.Task>();
            CreateMap<NewTaskDto, OzeSome.Data.Models.Task>();
            // OrderItem Mapping
            CreateMap<OrderItem, OrderItemDto>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.ProductPrice, opt => opt.MapFrom(src => src.Product.Price))
                .ForMember(dest => dest.ProductCategoryName, opt => opt.MapFrom(src => src.Product.Category.CategoryName));
            CreateMap<OrderItemDto, OrderItem>();
            CreateMap<NewOrderItemDto, OrderItem>();
        }
    }
}
