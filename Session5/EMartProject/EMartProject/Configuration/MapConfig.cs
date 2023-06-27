using AutoMapper;
using EMartProject.Context;
using EMartProject.Models;

namespace EMartProject.Configuration
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
        
    }
}
