using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Mapper
{
	class AuthorsInPrintingEditionsMapperProfile : Profile
	{
		public AuthorsInPrintingEditionsMapperProfile()
		{
			CreateMap<PrintingEdition, AuthorsInPrintingEditionsModel>()
			 .ForMember(dest => dest.EditionName, opt => opt.MapFrom(src => src.Name))
			 .ForMember(dest => dest.EditionPrice, opt => opt.MapFrom(src => src.Price))
			 .ForMember(dest => dest.EditionCategoryId, opt => opt.MapFrom(src => src.CategoryId))
			 .ForMember(dest => dest.EditionDesc, opt => opt.MapFrom(src => src.Desc))
			 .ForMember(dest => dest.EditionAvatarUrl, opt => opt.MapFrom(src => src.AvatarUrl))
			.ForMember(dest => dest.EditionCurencyId, opt => opt.MapFrom(src => src.CurrencyId));

			CreateMap<AuthorsInPrintingEditionsModel, PrintingEdition>()
			.ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EditionName))
			.ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.EditionPrice))
			.ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.EditionCategoryId))
			.ForMember(dest => dest.Desc, opt => opt.MapFrom(src => src.EditionDesc))
			.ForMember(dest => dest.AvatarUrl, opt => opt.MapFrom(src => src.EditionAvatarUrl))
			.ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.EditionCurencyId))
			.ForSourceMember(sor => sor.AuthorsList, dest => dest.DoNotValidate());
		}
	}
}
