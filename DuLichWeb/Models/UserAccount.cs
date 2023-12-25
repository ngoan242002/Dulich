namespace DuLichWeb.Models
{
    public class UserAccount
    {
        private static UserAccount? _instance;

        public TaiKhoan? taiKhoan { get; set; } 

        public static UserAccount Instance()
        {
            if (_instance == null) _instance = new UserAccount();
            return _instance;
        }
    }
}
