using DuLichWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DuLichWeb.Controllers
{
    public class TaiKhoanController : Controller
    {
        DuLichContext _context;
        public TaiKhoanController()
        {
            _context = new DuLichContext();
        }
        public IActionResult Index()
        {
            if (UserAccount.Instance().taiKhoan == null)
            {
                return View("Login");
            }
            var list = _context.BaiDangs.Where(bd => bd.Uemail == UserAccount.Instance().taiKhoan!.UserEmail).ToList();
            return View(list);
        }

        public IActionResult Add() { 
            return View(); 
        }

        [HttpPost]
        public IActionResult Add(BaiDang model) {

            if (model != null)
            {
                model.Uemail = UserAccount.Instance().taiKhoan!.UserEmail;
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "TaiKhoan");
            }
            else Console.WriteLine("not valid");
            return View("Add", model);
        }

        public IActionResult Update(int id)
        {
            BaiDang baiDang = _context.BaiDangs.Find(id)!;
            return View(baiDang);
        }
        [HttpPost]
        public IActionResult Update(BaiDang baiDang)
        {
            if (baiDang == null) return View("Update", baiDang);
            var bd = _context.BaiDangs.Find(baiDang.BaiDangId);
            bd!.UrlImage = baiDang.UrlImage;
            bd.TieuDe = baiDang.TieuDe;
            bd.DiaDiem = baiDang.DiaDiem;
            bd.NgayBatDau = baiDang.NgayBatDau;
            bd.NgayKetThuc = baiDang.NgayKetThuc;
            bd.GiaTour = baiDang.GiaTour;
            _context.SaveChanges();
            return RedirectToAction("Index", "TaiKhoan");
        }

        public IActionResult Delete(int id)
        {
            _context.BaiDangs.Remove(_context.BaiDangs.Find(id)!);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Login() {
            return View();
        }
        [HttpPost]
        public IActionResult Login(TaiKhoan taiKhoan) {

            if (taiKhoan == null)
            {
                Console.WriteLine("Account null");
            }

            var tk = _context.TaiKhoans.Find(taiKhoan!.UserEmail);
            if (tk != null && tk.UserPass == taiKhoan.UserPass) {
                UserAccount.Instance().taiKhoan = tk;
                return RedirectToAction("Index", "Home");
            }
            return View("Login", taiKhoan);
        }

        public IActionResult Signup() {
            return View();
        }
        [HttpPost]
        public IActionResult Signup(TaiKhoan taiKhoan)
        {

            if (ModelState.IsValid)
            {
                if (_context.TaiKhoans.Find(taiKhoan.UserEmail) != null)
                {
                    return View("Signup", taiKhoan);
                }
                _context.TaiKhoans.Add(taiKhoan);
                _context.SaveChanges();
                return RedirectToAction("Login", "TaiKhoan");
            }

            return View("Signup", taiKhoan);
        }

        public IActionResult Logout()
        {
            UserAccount.Instance().taiKhoan = null;
            return RedirectToAction("Index", "Home");
        }

        public IActionResult XemSau() {
            List<Booking> bookings = new List<Booking>();
            bookings.AddRange(_context.Bookings.Where(b => b.NguoiBook == UserAccount.Instance().taiKhoan!.UserEmail).ToList());
            List<BaiDang> l = new List<BaiDang>();
            foreach (Booking booking in bookings)
            {
                l.Add(_context.BaiDangs.Find(booking.BaiDangId)!);
            }
            return View(l);
        }
    }
}
