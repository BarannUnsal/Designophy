using Designophy.Entities.Common;

namespace Designophy.Entities
{
    public class SubCategory : BaseEntitiy
    {
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public string Name { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Blog> Blogs { get; set; }
    }
}
