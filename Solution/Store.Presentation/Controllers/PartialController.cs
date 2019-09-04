﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

//Этот новый контроллер будет использоваться для доставки HTML-шаблонов и представлений на клиентскую сторону с Angular компонентами.
namespace Store.Presentation.Controllers
{
    public class PartialController : Controller
    {
        public IActionResult AboutComponent() => PartialView();

        public IActionResult AppComponent() => PartialView();

        public IActionResult ContactComponent() => PartialView();

        public IActionResult IndexComponent() => PartialView();
    }
}