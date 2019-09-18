using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthorControler
    {
        private readonly IPrintStoreService _printStoreService;
        private readonly IAuthorService _authorService;

        public AuthorControler(IPrintStoreService printStoreService, IPrintingEditionService printingEditionService, IAuthorService authorService)
        {
            _printStoreService = printStoreService;
            _authorService = authorService;
        }

        [HttpGet("GetAutor")]
        public AuthorModel GetAuthor(int id)
        {
            var model = _authorService.Get(id);
            return model;
        }

        [HttpGet("GetAllAuthors")]
        public IEnumerable<AuthorModel> GetAllAuthors()
        {
            var model = _printStoreService.GetAllAuthors();
            return model;
        }

        
    }
}
