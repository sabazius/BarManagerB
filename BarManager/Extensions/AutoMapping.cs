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
            CreateMap<Tag, TagResponse>();
            CreateMap<TagRequest, Tag>();
            CreateMap<Employee, EmployeeResponse>();
            CreateMap<EmployeeRequest, Employee>();
            CreateMap<Products, ProductsResponse>();
            CreateMap<ProductsRequest, Products>();
            CreateMap<Shift, ShiftResponse>();
            CreateMap<ShiftRequest, Shift>();
            CreateMap<Bill, BillResponse>();
            CreateMap<BillRequest, Bill>();
        }
    }
}
