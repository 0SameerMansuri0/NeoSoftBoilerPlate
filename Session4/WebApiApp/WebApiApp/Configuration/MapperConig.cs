using AutoMapper;
using WebApiApp.Context;
using WebApiApp.Model;

namespace WebApiApp.Configuration
{
    public class MapperConig:Profile
    {
        public MapperConig()
        {
            CreateMap<Hotel, HotelVM>().ReverseMap();
            CreateMap<Country, CountryVM>().ReverseMap();
        }
    }
}
