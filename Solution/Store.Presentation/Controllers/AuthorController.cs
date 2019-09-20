using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;

namespace Store.Presentation.Controllers
{
    public class AuthorController : BaseApiController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("GetAuthor/{id}")]
        public AuthorModel GetAuthor(int id)
        {
            var model = _authorService.Get(id);
            return model;
        }

        [HttpGet("GetAllAuthors")]
        public IEnumerable<AuthorModel> GetAllAuthors()
        {
            var model = _authorService.GetAll();
            return model;
        }

        [HttpGet("GetFilteredAuthorsByName")]
        public IEnumerable<AuthorModel> GetFilteredAuthorsByName(string firstName, string lastName)
        {
            var model = _authorService.FilterByName(firstName, lastName);
            return model;
        }
    }
}
