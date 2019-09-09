namespace Store.BusinessLogic.Models.User
{
    public class UserChangePasswordModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
