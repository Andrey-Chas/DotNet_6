namespace Authentication.Models
{
    public class UserModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<RoleModel> Roles { get; set; }
    }
}
