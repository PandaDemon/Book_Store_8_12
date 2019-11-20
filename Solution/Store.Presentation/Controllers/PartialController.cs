using Microsoft.AspNetCore.Mvc;

namespace Store.Presentation.Controllers
{
    public class PartialController : Controller
    {
        public IActionResult AboutComponent() => PartialView();

        public IActionResult AppComponent() => PartialView();

        public IActionResult ContactComponent() => PartialView();

        public IActionResult IndexComponent() => PartialView();

        public IActionResult RegistrationComponent() => PartialView();

        public IActionResult SignInComponent() => PartialView();
    }
}