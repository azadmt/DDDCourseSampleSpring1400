using SecurityManagement.Model;
using System.Collections.Generic;

namespace SecurityManagement
{
    public static class InMemoryDB
    {
        public static List<Model.User> Users = new List<Model.User>();
        public static Dictionary<string, UserClaim> Claims = new Dictionary<string, UserClaim>();
        public static Dictionary<string, string[]> UserPermissions = new Dictionary<string, string[]>();
        static InMemoryDB()
        {
            Users.Add(new Model.User { Id = 1, Username = "admin", Password = "123", EmailAddress = "admin@mail.com" });
            Users.Add(new Model.User { Id = 2, Username = "guest", Password = "123", EmailAddress = "guest@mail.com" });
            UserPermissions.Add("admin", new[] { "RegisterCustomer", "ApproveCustomer","ApproveLoan","RejectLoan" });
            UserPermissions.Add("guest", new[] { "RegisterCustomer","RequestLoan" });

        }
    }
}
