using Designophy.Entities.Common;

namespace Designophy.Entities
{
    public class Category : BaseEntitiy
    {
        public string Name { get; set; }

        public ICollection<SubCategory> SubCategories { get; set; }
    }
}
