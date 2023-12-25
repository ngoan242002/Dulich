using DuLichWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DuLichWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private List<BaiDang> _baiDangs = new List<BaiDang>();
        private DuLichContext _context;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = new DuLichContext();
            _baiDangs.AddRange(_context.BaiDangs.ToList());
        }

        public IActionResult Index()
        {
            List<BaiDang> l = new List<BaiDang>();
            for (int i = _baiDangs.Count - 1; i >= 0; i--)
            {
                l.Add(_baiDangs[i]);
            }
            return View(l);
        }

        [HttpPost]
        public IActionResult Search()
        {
            List<BaiDang> l = new List<BaiDang>();
            var data = Request.Form["search"];
            l.AddRange(_context.BaiDangs.Where(bd => bd.TieuDe.Contains(data!) || bd.DiaDiem.Contains(data!)).ToList());
            return View("Index", l);
        }

        public IActionResult XemTour(int id)
        {

            return View(_context.BaiDangs.Find(id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }


}