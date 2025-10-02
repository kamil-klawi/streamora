using AutoMapper;
using UsersService.Application.Commands.CreateUser;
using UsersService.Application.Commands.UpdateUser;
using UsersService.Domain.Entities;
using UsersService.Domain.ValueObjects;

namespace UsersService.Application.Dtos
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<UserDto, User>()
                .ForMember(user => user.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(user => user.PersonalData, opt => opt.MapFrom(
                    src => new PersonalData(src.FirstName, src.LastName, src.Gender, src.DateOfBirth, src.Nationality)));

            CreateMap<CreateUserCommand, User>()
                .ForMember(user => user.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(user => user.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(user => user.PersonalData, opt => opt.MapFrom(
                    src => new PersonalData(src.FirstName, src.LastName, src.Gender, src.DateOfBirth, src.Nationality)));
        }
    }
}
