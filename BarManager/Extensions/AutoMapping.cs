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
            CreateMap<Tag, TagResponse>();
            CreateMap<TagRequest, Tag>();
            CreateMap<Client, ClientResponse>();
            CreateMap<ClientRequest, Client>();

        }
    }
}
