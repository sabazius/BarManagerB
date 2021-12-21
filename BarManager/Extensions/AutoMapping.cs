using AutoMapper;
using BarManager.Models.DTO;
using BarManager.Models.Requests;
using BarManager.Models.Responses;

namespace BarManager.Extensions
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<OrderItem, OrderItemResponse>();
            CreateMap<OrderItemRequest, OrderItem>();
            CreateMap<Tag, TagResponse>().ReverseMap();
            CreateMap<TagRequest, Tag>().ReverseMap();
            CreateMap<TagUpdateRequest, Tag>().ReverseMap();
            CreateMap<Client, ClientResponse>();
            CreateMap<ClientRequest, Client>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<Products, ProductsResponse>().ReverseMap();
            CreateMap<ProductsRequest, Products>().ReverseMap();
            CreateMap<ProductsUpdateRequest, Products>().ReverseMap();
            CreateMap<Shift, ShiftResponse>();
            CreateMap<ShiftRequest, Shift>();
            CreateMap<Bill, BillResponse>();
            CreateMap<BillRequest, Bill>();
        }
    }
}
