using Microsoft.AspNetCore.Identity;

namespace Designophy.Entities
{
    public class User : IdentityUser<int>
    {
        public ICollection<Blog> Blogs { get; set; }
    }
}
