namespace User_ASP.Helpers;

using AutoMapper;
using User_ASP.Entities;
using User_ASP.Models.Users;

/// <summary>
/// use to pass values between objects with common props
/// </summary>
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // specify object mappings
        CreateMap<User, AuthenticateResponse>();
        CreateMap<RegisterRequest, User>();
    }
}
