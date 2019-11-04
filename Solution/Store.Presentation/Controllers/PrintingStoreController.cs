using Microsoft.AspNetCore.Mvc;
using Store.BusinessLogic.Models.Author;
using Store.BusinessLogic.Models.PrintingEditions;
using Store.BusinessLogic.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
	public class PrintingStoreController : BaseApiController
	{
		private readonly IPrintStoreService _printingStoreService;
		private readonly IPrintingEditionService _printingEditionsService;

		public PrintingStoreController(IPrintStoreService printStoreService, IPrintingEditionService printEditionsService)
		{
			_printingStoreService = printStoreService;
			_printingEditionsService = printEditionsService;
		}



		[HttpGet("GetPrintingEdition")]
		public IEnumerable<PrintingEditionModel> GetAllPrintingEditions()
		{
			var model = _printingStoreService.GetAllPrintingEditions();
			return model;
		}

		[HttpPost("AddPrintingEdition")]
		public async Task<IActionResult> Create([FromBody]AuthorsInPrintingEditionsModel model)
		{
			await _printingEditionsService.Create(model);
			return Ok(201);
		}

		
	}
}
