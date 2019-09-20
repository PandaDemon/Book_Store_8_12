using AutoMapper;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.DataAccess.Entities;

namespace Store.BusinessLogic.Mapper
{
    class PrintingEditionMapper : Profile 
    {
        public PrintingEditionMapper()
        {
            CreateMap<PrintingEdition, PrintingEditionModel>();
            CreateMap<PrintingEditionModel, PrintingEdition>();
        }
    }
}
