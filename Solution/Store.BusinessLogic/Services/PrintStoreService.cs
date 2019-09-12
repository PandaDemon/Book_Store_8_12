using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services
{
    public class PrintStoreService : IPrintStoreService
    {
        private readonly IAuthor _author;
        private readonly IPrintingEdition _printingEdition;
        private readonly IAuthorInPrintingEdition _authorInPrintingEdition;
        private readonly IMapper _mapper;

        public PrintStoreService(IAuthorInPrintingEdition authorInPrintingEdition,
            IAuthor author,
            IPrintingEdition printingEdition,
            IMapper mapper)
        {
            _authorInPrintingEdition = authorInPrintingEdition;
            _author = author;
            _printingEdition = printingEdition;
            _mapper = mapper;
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> SortByPrintingEditionPrice(string filterPrice)
        {
            var priningEditions = _authorInPrintingEdition.FilterByPrintingEditionPrice(filterPrice);
            var model = new List<AuthorsInPrintingEditionsModel>();

            foreach (var p in priningEditions)
            {
                PrintingEdition pe = _printingEdition.Get(p.PrintingEdidtionId);
                Author author = _author.Get(p.AuthorId);
                model.Add(new AuthorsInPrintingEditionsModel
                {
                    AuthorFirstName = author.FirstName,
                    AuthorLastName = author.LastName,
                    PrintingEditionName = pe.Name,
                    PrintingEditionPrice = pe.Price,
                    PrintingEditionImage = pe.Img,
                    PrtintingEditionCategory = pe.CategoryId,
                    PrintingEditionIsInStock = pe.IsInStock,
                    PrtintingEditionDescription = pe.Desc

                });
            }
            return model;
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> FilterByPrintingEditionCategory(int filterCategory)
        {
            var priningEditions = _authorInPrintingEdition.FilterByPrintingEditionCategory(filterCategory);
            var model = new List<AuthorsInPrintingEditionsModel>();

            foreach (var p in priningEditions)
            {
                PrintingEdition pe = _printingEdition.Get(p.PrintingEdidtionId);
                Author author = _author.Get(p.AuthorId);
                model.Add(new AuthorsInPrintingEditionsModel
                {
                    AuthorFirstName = author.FirstName,
                    AuthorLastName = author.LastName,
                    PrintingEditionName = pe.Name,
                    PrintingEditionPrice = pe.Price,
                    PrintingEditionImage = pe.Img,
                    PrtintingEditionCategory = pe.CategoryId,
                    PrintingEditionIsInStock = pe.IsInStock,
                    PrtintingEditionDescription = pe.Desc
                });
            }
            return model;
        }

        public IEnumerable<AuthorModel> GetAllAuthors()
        {
            var authors = _author.GetAll();
            var model = new List<AuthorModel>();

            foreach (var a in authors)
            {
                model.Add(_mapper.Map<AuthorModel>(a));
            }
            return model;
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> GetAllAuthorsInPrintingEditions()
        {
            var priningEditions = _authorInPrintingEdition.GetAll();
            var model = new List<AuthorsInPrintingEditionsModel>();

            foreach (var p in priningEditions)
            {
                PrintingEdition pe = _printingEdition.Get(p.PrintingEdidtionId);
                Author author = _author.Get(p.AuthorId);
                model.Add(new AuthorsInPrintingEditionsModel
                {
                    AuthorFirstName = author.FirstName,
                    AuthorLastName = author.LastName,
                    PrintingEditionName = pe.Name,
                    PrintingEditionPrice = pe.Price,
                    PrintingEditionImage = pe.Img,
                    PrtintingEditionCategory = pe.CategoryId,
                    PrintingEditionIsInStock = pe.IsInStock,
                    PrtintingEditionDescription = pe.Desc
                });
            }
            return model;
        }

        public IEnumerable<PrintingEditionModel> GetAllPrintingEditions()
        {
            var priningEditions = _authorInPrintingEdition.GetAll();
            var model = new List<PrintingEditionModel>();

            foreach (var p in priningEditions)
            {
                PrintingEdition pe = _printingEdition.Get(p.PrintingEdidtionId);
                model.Add(_mapper.Map<PrintingEditionModel>(pe));
            }
            return model;
        }

        public IEnumerable<PrintingEditionModel> GetAuthorPrintingEditions(string authorName)
        {
            var priningEditions = _authorInPrintingEdition.FindByAuthor(authorName);
            var model = new List<PrintingEditionModel>();

            foreach (var p in priningEditions)
            {
                PrintingEdition pe = _printingEdition.Get(p.PrintingEdidtionId);
                model.Add(_mapper.Map<PrintingEditionModel>(pe));
            };
            return model;
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> FilterByPrintingEditionName(string filter)
        {
            var priningEditions = _authorInPrintingEdition.FilterByPrintingEditionName(filter);
            var model = new List<AuthorsInPrintingEditionsModel>();

            foreach (var p in priningEditions)
            {
                PrintingEdition pe = _printingEdition.Get(p.PrintingEdidtionId);
                Author author = _author.Get(p.AuthorId);
                model.Add(new AuthorsInPrintingEditionsModel
                {
                    AuthorFirstName = author.FirstName,
                    AuthorLastName = author.LastName,
                    PrintingEditionName = pe.Name,
                    PrintingEditionPrice = pe.Price,
                    PrintingEditionImage = pe.Img,
                    PrtintingEditionCategory = pe.CategoryId,
                    PrintingEditionIsInStock = pe.IsInStock,
                    PrtintingEditionDescription = pe.Desc
                });
            }
            return model;
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> FilterByAuthor(string filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AuthorsInPrintingEditionsModel> FilterByPrintingEditionIsInStock(bool isInStock)
        {
            var priningEditions = _authorInPrintingEdition.FilterByPrintingEditionIsInStock(isInStock);
            var model = new List<AuthorsInPrintingEditionsModel>();

            foreach (var p in priningEditions)
            {
                PrintingEdition pe = _printingEdition.Get(p.PrintingEdidtionId);
                Author author = _author.Get(p.AuthorId);
                model.Add(new AuthorsInPrintingEditionsModel
                {
                    AuthorFirstName = author.FirstName,
                    AuthorLastName = author.LastName,
                    PrintingEditionName = pe.Name,
                    PrintingEditionPrice = pe.Price,
                    PrintingEditionImage = pe.Img,
                    PrtintingEditionCategory = pe.CategoryId,
                    PrintingEditionIsInStock = pe.IsInStock,
                    PrtintingEditionDescription = pe.Desc
                });
            }
            return model;
        }
    }
}
