using AutoMapper;
using TRM_STT.Api.DTO;
using TRM_STT.Core.Domain.Models;

namespace TRM_STT.Api.Mappings
{
    public class GoodsProfile : Profile
    {
        public GoodsProfile()
        {
            CreateMap<Good, CreateGoodDto>().ReverseMap();
            CreateMap<Good, GoodDto>().ReverseMap();
        }
    }
}