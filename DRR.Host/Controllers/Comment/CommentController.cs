using Microsoft.AspNetCore.Mvc;

namespace DRR.Host.Controllers.Comment
{
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
