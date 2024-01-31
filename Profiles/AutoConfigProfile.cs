using AutoMapper;
using CountryDropDownAPI.DTO;
using CountryDropDownAPI.Models;

namespace CountryDropDownAPI.Profiles
{
    public class AutoConfigProfile : Profile
    {
        public AutoConfigProfile()
        {
            //country
            CreateMap<Country, CountryDto>().ReverseMap();
            CreateMap<Country, AddCountryDto>().ReverseMap();

            CreateMap<Country, CountryListDto>().ReverseMap();

            //state
            CreateMap<State, StateDto>().ReverseMap();
            CreateMap<State, AddStateDto>().ReverseMap();
            CreateMap<State, CountryStateDto>().ReverseMap();

            //district
            CreateMap<District, DistrictDto>().ReverseMap();
            CreateMap<District, AddDistrictDto>().ReverseMap();
            CreateMap<District, StateDistrictDto>().ReverseMap();

            //city
            CreateMap<City, CityDto>().ReverseMap();
            CreateMap<City, AddCityDto>().ReverseMap();
            CreateMap<City, DistrictCityDto>().ReverseMap();

            CreateMap<City, DistrictCityOnlyDto>().ReverseMap();

            //person
            CreateMap<Person, AddPersonDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            CreateMap<Person, UpdatePersonDto>().ReverseMap();

            CreateMap<Person, PersonDetailsDto>().ReverseMap();

        }
    }
}
