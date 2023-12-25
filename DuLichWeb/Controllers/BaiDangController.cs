using DuLichWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace DuLichWeb.Controllers
{
    public class BaiDangController : Controller
    {
        private DuLichContext context;

        public BaiDangController()
        {
            this.context = new DuLichContext();
        }

        public IActionResult AddCheckLate(int id)
        {
            if (UserAccount.Instance().taiKhoan == null)
            {
                return RedirectToAction("Login", "TaiKhoan");
            }
            List<Booking> bookings = context.Bookings.Where(b => b.NguoiBook == UserAccount.Instance().taiKhoan!.UserEmail).ToList();
            foreach (var item in bookings)
            {
                if (item.BaiDangId == id)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            Booking booking = new Booking();
            booking.BaiDangId = id;
            booking.NguoiBook = UserAccount.Instance().taiKhoan!.UserEmail;
            this.context.Bookings.Add(booking);
            this.context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Book()
        {
            return View();
        }

        public IActionResult Delete(int id)
        {
            List<BaiDang> list = new List<BaiDang>();
            foreach (var item in context.Bookings.Where(book => book.NguoiBook == UserAccount.Instance().taiKhoan!.UserEmail && book.BaiDangId == id).ToList())
            {
                context.Bookings.Remove(item);
            }
            context.SaveChanges();
            
            return RedirectToAction("XemSau", "TaiKhoan");
        }
    }
}
