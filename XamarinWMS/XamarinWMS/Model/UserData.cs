using SQLite;

namespace XamarinWMS.Model
{
    public class UserData
    {
        [PrimaryKey]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public bool IsRegistred { get; set; }

    }
}
