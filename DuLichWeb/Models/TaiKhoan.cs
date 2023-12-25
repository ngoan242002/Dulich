using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DuLichWeb.Models;

public partial class TaiKhoan
{
    [DisplayName("Email")]
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Must be email")]
    public string UserEmail { get; set; } = null!;
    [DisplayName("Mật Khẩu")]
    [DataType(DataType.Password)]
    public string UserPass { get; set; } = null!;
    [DisplayName("Tên Người Dùng")]
    [Required(AllowEmptyStrings = true)]
    public string UserName { get; set; } = null!;
    [DisplayName("Số Điện Thoại")]
    [Required(AllowEmptyStrings = true)]
    public string UserPhone { get; set; } = null!;

    public virtual ICollection<BaiDang> BaiDangs { get; set; } = new List<BaiDang>();

    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
