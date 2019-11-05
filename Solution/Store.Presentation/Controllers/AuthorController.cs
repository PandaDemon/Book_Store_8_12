﻿using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    public class AuthorController : BaseApiController
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost("Create")]
        public HttpStatusCode Create(AuthorModel model)
        {
            _authorService.Create(model);
            return HttpStatusCode.OK;
        }

        [HttpPost("Delete")]
        public HttpStatusCode Delete(int id)
        {
            try
            {
                _authorService.Delete(id);
            }
            catch (Exception excceptionText)
            {
                var excception = excceptionText;
            }

            return HttpStatusCode.OK;
        }

        [HttpGet("GetAuthor/{id}")]
        public async Task<AuthorModel> GetAuthor(int id)
        {
            var model = await _authorService.Get(id);
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
