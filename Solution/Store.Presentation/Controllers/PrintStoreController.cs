using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
	public class PrintStoreController
	{
		private readonly IPrintStoreService _printService;


		public PrintStoreController(IPrintStoreService printrService)
		{
			_printService = printrService;
		}

		[HttpGet("GetPrintingEdition")]
		public async Task<object> GetAllUsers()
		{
			var users = await _printService.GetAllPrintingEditions();
			return users;
		}
	}
}
