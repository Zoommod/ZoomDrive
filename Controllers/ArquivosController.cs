using Microsoft.AspNetCore.Mvc;
using ZoomDrive.web.Data;
using ZoomDrive.web.Models;

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
        public ActionResult Index(string tipo)
        {
            ViewBag.TipoFiltro = tipo;
            var arquivos = _context.Arquivos.AsQueryable();
            if(tipo != "")
            {
                arquivos = arquivos.Where(a => a.Extensao.Contains(tipo));
            }

            return View(arquivos.OrderByDescending(a => a.DataUpload).ToList());
        }

        [HttpPost]
        public IActionResult Upload(IFormFile arquivo)
        {
            if(arquivo != null && arquivo.Length > 0)
            {
                using(var ms = new MemoryStream())
                {
                    arquivo.CopyTo(ms);
                    var arquivoModel = new ArquivoModel
                    {
                        NomeArquivo = Path.GetFileNameWithoutExtension(arquivo.FileName),
                        Extensao = Path.GetExtension(arquivo.FileName).TrimStart('.'),
                        TipoMime = arquivo.ContentType,
                        Tamanho = arquivo.Length,
                        DataUpload = DateTime.Now,
                        ArquivoBytes = ms.ToArray()
                    };
                    _context.Arquivos.Add(arquivoModel);
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }

    }
}