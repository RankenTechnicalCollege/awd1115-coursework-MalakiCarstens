using Microsoft.AspNetCore.Identity;

namespace HOT3.Models.ViewModels
{
    public class UserViewModels
    {
        public IEnumerable<User> Users { get; set; } = null!;
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    } 
}
