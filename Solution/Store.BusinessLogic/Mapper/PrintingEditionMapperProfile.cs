using AutoMapper;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Mapper
{
    class PrintingEditionMapperProfile : Profile 
    {
        public PrintingEditionMapperProfile()
        {
            CreateMap<PrintingEdition, PrintingEditionModel>();
            CreateMap<PrintingEditionModel, PrintingEdition>();
        }
    }
}
