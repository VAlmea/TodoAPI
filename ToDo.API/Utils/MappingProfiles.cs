using AutoMapper;
using ToDo.Common.DTO.Request;
using ToDo.Common.DTO.Response;
using ToDo.Data.Entities;

namespace ToDo.API.Utils
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Activity, ActivityResponseDTO>();
            CreateMap<ActivityRequestDTO, Activity>();
        }
    }
}