using System;
using System.Collections.Generic;

namespace DuLichWeb.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public int BaiDangId { get; set; }

    public string NguoiBook { get; set; } = null!;

    public virtual BaiDang BaiDang { get; set; } = null!;

    public virtual TaiKhoan NguoiBookNavigation { get; set; } = null!;
}
