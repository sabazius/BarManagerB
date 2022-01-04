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
            CreateMap<OrderItem, OrderItemResponse>().ReverseMap();
            CreateMap<OrderItemRequest, OrderItem>().ReverseMap();
            CreateMap<Tag, TagResponse>().ReverseMap();
            CreateMap<TagRequest, Tag>().ReverseMap();
            CreateMap<TagUpdateRequest, Tag>().ReverseMap();
            CreateMap<Client, ClientResponse>();
            CreateMap<ClientRequest, Client>();
            CreateMap<Employee, EmployeeResponse>().ReverseMap();
            CreateMap<EmployeeRequest, Employee>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateRequest>();
            CreateMap<Products, ProductsResponse>();
            CreateMap<ProductsRequest, Products>();
            CreateMap<Client, ClientResponse>().ReverseMap();
            CreateMap<ClientRequest, Client>().ReverseMap();
            CreateMap<ClientUpdateRequest, Client>().ReverseMap();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<Products, ProductsResponse>().ReverseMap();
            CreateMap<ProductsRequest, Products>().ReverseMap();
            CreateMap<ProductsUpdateRequest, Products>().ReverseMap();
            CreateMap<Shift, ShiftResponse>();
            CreateMap<ShiftRequest, Shift>();
            CreateMap<Bill, BillResponse>().ReverseMap();
            CreateMap<BillRequest, Bill>().ReverseMap();
            CreateMap<BillUpdateRequest, Bill>().ReverseMap();

        }
    }
}
