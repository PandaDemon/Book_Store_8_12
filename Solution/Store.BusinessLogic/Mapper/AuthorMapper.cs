using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Mapper
{
    class AuthorMapper : Profile
    {
        public AuthorMapper()
        {
            CreateMap<Author, AuthorModel>();
            CreateMap<AuthorModel, Author>();
        }
    }
}
