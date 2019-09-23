using AutoMapper;
using Store.BusinessLogic.Models.User;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Mapper
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<UserCreateModel, User>();
            CreateMap<UserEditModel, User>();
            CreateMap<UserChangePasswordModel, User>();
            CreateMap<UserSignUpModel, User>();
        }
    }
}
