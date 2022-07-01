using AutoMapper;
using Entity = statemachineSagasRabbitmqDemo.Infrastructure.Database.Entities;

namespace statemachineSagasRabbitmqDemo.Infrastructure.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Entity.File, Domain.File.File>().ReverseMap();
            CreateMap<Entity.FileDetail, Domain.Detail.FileDetail>().ReverseMap();
            CreateMap<Entity.FileLog, Domain.Log.FileLog>().ReverseMap();
        }
    }
}
