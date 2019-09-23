using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Mapper
{
    class AuthorMapperProfile : Profile
    {
        public AuthorMapperProfile()
        {
            CreateMap<Author, AuthorModel>();
            CreateMap<AuthorModel, Author>();
        }
    }
}
