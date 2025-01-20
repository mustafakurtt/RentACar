using Application.Features.Users.Commands.Create;
using AutoMapper;

namespace Application.Features.Users.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Core.Security.Entities.User, CreateUserCommand>().ReverseMap();
        CreateMap<Core.Security.Entities.User, CreatedUserResponse>().ReverseMap();
    }
}