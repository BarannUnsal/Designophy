using Designophy.Entities.Common;

namespace Designophy.Entities
{
    public class Blog : BaseEntitiy
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}
