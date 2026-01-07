using Microsoft.AspNetCore.Mvc;
using ZoomDrive.web.Data;

namespace ZoomDrive.web.Controllers
{
    public class ArquivosController : Controller
    {

        private readonly AppDbContext _context;
        public ArquivosController(AppDbContext context)
        {
            _context = context;
        }
        // GET: ArquivosController
        public ActionResult Index()
        {
            return View();
        }

    }
}