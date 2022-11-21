using DesktopS1_Helper;

namespace DesktopS1_Model.DisplayDto
{
    public class UserDisplayDto : Bll
    {
        public static UserDisplayDto InstanceUser => Singleton<UserDisplayDto>.Instance;

        public string Telephone { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }
    }
}