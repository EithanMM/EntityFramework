using AutoMapper;
using Store.Core.Models;
using Store.Data.Entities.Store;

namespace Store.Data;

public class DataMapperProfile : Profile
{
    public DataMapperProfile()
    {
        CreateMap<StoreEntity, StoreModel>(MemberList.Destination);
    }
}
