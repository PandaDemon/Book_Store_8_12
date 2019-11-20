using AutoMapper;
using PrintStore.BusinessLogic.ViewModels;
using PrintStore.DataAccess.Entities;

namespace PrintStore.BusinessLogic.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Author, AuthorViewModel>();

            CreateMap<AuthorViewModel, Author>();

            CreateMap<PrintingEdition, PrintingEditionViewModel>();

            CreateMap<PrintingEditionViewModel, PrintingEdition>();

            CreateMap<Currency, CurrencyViewModel>();

            CreateMap<CurrencyViewModel, Currency>();

            CreateMap<AuthorsInPrintingEditionsViewModel, PrintingEdition>()
                .ForMember(dest => dest.NameEdition, opt => opt.MapFrom(src => src.PrintingEditionTitle))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PrtintingEditionId))
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.PrintingEditionPrice))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.PrintingEditionStatus))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.PrtintingEditionDescription))
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => src.PrintingEditionImage))
                .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.CurrencyId))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.PrtintingEditionType))
                .ForSourceMember(sor => sor.AuthorFirstName, dest => dest.DoNotValidate())
                .ForSourceMember(sor => sor.AuthorLastName, dest => dest.DoNotValidate())
                .ForSourceMember(sor => sor.CurrencyName, dest => dest.DoNotValidate())
                .ForSourceMember(sor => sor.AuthorsList, dest => dest.DoNotValidate())
                .ForSourceMember(sor => sor.PrintinEditionQuantityForOrder, dest => dest.DoNotValidate());

            CreateMap<PrintingEdition, AuthorsInPrintingEditionsViewModel>()
                .ForMember(dest => dest.PrtintingEditionId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PrintingEditionTitle, opt => opt.MapFrom(src => src.NameEdition))
                .ForMember(dest => dest.PrintingEditionPrice, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.PrintingEditionStatus, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.PrtintingEditionDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.PrintingEditionImage, opt => opt.MapFrom(src => src.ImageUrl))
                .ForMember(dest => dest.PrtintingEditionType, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.CurrencyName, opt => opt.MapFrom(src => src.Currency.CurrencyName));


            CreateMap<AuthorsInPrintingEditionsViewModel, Author>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.AuthorFirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.AuthorLastName));


            CreateMap<Author, AuthorsInPrintingEditionsViewModel>()
                .ForMember(dest => dest.AuthorFirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.AuthorLastName, opt => opt.MapFrom(src => src.LastName));

            CreateMap<Currency, AuthorsInPrintingEditionsViewModel>()
               .ForMember(dest => dest.CurrencyId, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.CurrencyName, opt => opt.MapFrom(src => src.CurrencyName));

            CreateMap<OrderViewModel, Order>()
                .ForMember(dest => dest.ApplicationUserId, opt => opt.MapFrom(src => src.UserId));

            CreateMap<ApplicationUser, ApplicationUserViewModel>();

            CreateMap<Payment, PaymentViewModel>();

            CreateMap<PaymentViewModel, Payment>();

            CreateMap<ApplicationUserViewModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email));

            CreateMap<CreateUserViewModel, ApplicationUser>();

            CreateMap<EditUserViewModel, ApplicationUser>();

            CreateMap<ChangePasswordViewModel, ApplicationUser>();

            CreateMap<RegisterUserViewModel, ApplicationUser>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email)); ;
        }
    }
}
