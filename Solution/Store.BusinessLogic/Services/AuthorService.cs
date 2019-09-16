using AutoMapper;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using Store.DataAccess.Entities;
using Store.DataAccess.Repositories.Interfaces;
using System.Collections.Generic;

namespace Store.BusinessLogic.Services
{
    class AuthorService : IAuthorService
    {
        private readonly IAuthorInPrintingEditionRepository _authorInPrintingEdition;
        private readonly IAuthorRepository _author;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository authorRepository, IAuthorInPrintingEditionRepository authorInPrintingEditionRepository, IMapper mapper)
        {
            _author = authorRepository;
            _authorInPrintingEdition = authorInPrintingEditionRepository;
            _mapper = mapper;
        }
        public void CreateAuthor(AuthorModel model)
        {
            var author = _mapper.Map<Author>(model);
            _author.Create(author);
        }

        public void Delete(Author item)
        {
            _author.Delete(item);
        }

        public void DeleteAuthor(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AuthorModel> FilterAuthor(string filter)
        {
            throw new System.NotImplementedException();
        }

        //public IEnumerable<AuthorModel> FilterAuthor(string filter)
        //{
        //    var authors = _author.FilterAuthors(filter);
        //    var model = new List<AuthorModel>();
        //    foreach (var a in authors)
        //    {
        //        model.Add(_mapper.Map<AuthorModel>(a));
        //    }
        //    return model;
        //}

        public AuthorModel GetAuthorById(Author item)
        {
            Author author = _author.Get(item);
            var model = _mapper.Map<AuthorModel>(author);
            return model;
        }

        public AuthorModel GetAuthorById(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<PrintingEditionModel> GetAuthorPritningEditions(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AuthorModel> SortByFirstName(string order)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<AuthorModel> SortByLastName(string order)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateInformationAboutAuthor(AuthorModel model)
        {
            throw new System.NotImplementedException();
        }

        //public IEnumerable<PrintingEditionModel> GetAuthorPritningEditions(int id)
        //{
        //    IEnumerable<AuthorInPrintingEditions> printingEditions = _authorInPrintingEdition.FindByAuthor(_author.Get(id).LastName);
        //    var model = new List<PrintingEditionModel>();
        //    foreach (var printEdition in printingEditions)
        //    {
        //        model.Add(_mapper.Map<PrintingEditionModel>(printEdition.PrintingEdition));
        //    }
        //    return model;
        //}

        //public IEnumerable<AuthorModel> SortByFirstName(string order)
        //{
        //    var authors = _author.SortByFirstName(order);
        //    var model = new List<AuthorModel>();
        //    foreach (var a in authors)
        //    {
        //        model.Add(_mapper.Map<AuthorModel>(a));
        //    }
        //    return model;
        //}

        //public IEnumerable<AuthorModel> SortByLastName(string order)
        //{
        //    var authors = _author.SortByLastName(order);
        //    var model = new List<AuthorModel>();
        //    foreach (var a in authors)
        //    {
        //        model.Add(_mapper.Map<AuthorModel>(a));
        //    }
        //    return model;
        //}

        //public void UpdateInformationAboutAuthor(AuthorModel model)
        //{
        //    var author = _mapper.Map<Author>(model);
        //    if (_author.Get(author.Id) != null)
        //    {
        //        _author.Update(author);
        //    }
        //}
    }
}
