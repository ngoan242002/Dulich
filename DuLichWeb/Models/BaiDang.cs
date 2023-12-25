using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DuLichWeb.Models;

public partial class BaiDang
{
    public int BaiDangId { get; set; }

    [Display(Name = "Link ảnh")]
    public string UrlImage { get; set; } = null!;

    [Display(Name = "Tiêu đề")]
    public string TieuDe { get; set; } = null!;

    [Display(Name = "Địa Điểm")]
    public string DiaDiem { get; set; } = null!;

    [Display(Name = "Ngày bắt đầu")]
    [DataType(DataType.Date)]
    public DateTime NgayBatDau { get; set; }

    [Display(Name = "Ngày kết thúc")]
    [DataType(DataType.Date)]
    public DateTime NgayKetThuc { get; set; }

    [Display(Name = "Giá tour")]
    public double GiaTour { get; set; }

    public string Uemail { get; set; } = null!;

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();

    public virtual TaiKhoan UemailNavigation { get; set; } = null!;
}
