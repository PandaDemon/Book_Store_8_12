using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;

namespace Store.Presentation.Controllers
{
	public class PrintingStoreController : BaseApiController
	{
		private readonly IPrintStoreService _printingStoreService;

		public PrintingStoreController(IPrintStoreService printStoreService)
		{
			_printingStoreService = printStoreService;
		}



		[HttpGet("GetPrintingEdition")]
		//a
		///
		public IEnumerable<PrintingEditionModel> GetAllPrintingEditions()
		{
			var model = _printingStoreService.GetAllPrintingEditions();
			return model;
		}
	}
}
