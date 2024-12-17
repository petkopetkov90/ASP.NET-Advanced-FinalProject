namespace FleetRouteManager.Web.Models.AdminAreaViewModels.UserViewModels
{
    public class UserViewModel
    {
        public required string Id { get; set; }

        public required string Email { get; set; }

        public ICollection<string> Roles { get; set; } = new List<string>();
    }
}
