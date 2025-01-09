using AutoMapper;

namespace FuelChampion.Api;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        //CreateMap<dynamic, GasStationAvgVoivodeshipPrice>()
        //   .ForMember(dest => dest.Voivodeship, opt => opt.MapFrom(src => "Voivodeship"))
        //   .ForMember(dest => dest.FuelType, opt => opt.MapFrom(src => "FuelType"))
        //   .ForMember(dest => dest.PricePerLiterAvg, opt => opt.MapFrom(src => "PricePerLiterAvg"));
    }
}
