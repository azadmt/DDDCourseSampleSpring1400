namespace SecurityManagement.Model
{
    public class UserModel
    {
        public string Username { get; set; }
        public string EmailAddress { get; set; }

        public string[] Roles { get; set; }
    }
}
