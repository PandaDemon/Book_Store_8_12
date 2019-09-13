using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Models.User;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<UserModel, User>();
            CreateMap<UserCreateModel, User>();
            CreateMap<UserEditModel, User>();
            CreateMap<UserChangePasswordModel, User>();
            CreateMap<UserSignUpModel, User>();
            CreateMap<PrintingEdition, PrintingEditionModel>();
            CreateMap<PrintingEditionModel, PrintingEdition>();

            CreateMap<Author, AuthorModel>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(c => $"{c.FirstName} {c.LastName}"));

            CreateMap<AuthorModel, Author>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(c => c.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(c => c.LastName))
                .ForSourceMember(x => x.FirstName, opt => opt.DoNotValidate());

        }
    }
}
