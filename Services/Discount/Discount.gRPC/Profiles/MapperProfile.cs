using AutoMapper;
using Discount.gRPC.Entities;
using Discount.gRPC.Protos;

namespace Discount.gRPC.Profiles;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Coupon, CouponModel>().ReverseMap();
    }
}