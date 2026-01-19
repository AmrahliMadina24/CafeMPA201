using CafeMPA201.Models.Common;

namespace CafeMPA201.Models
{
    public class Position : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public ICollection<Chef> Chefs { get; set; } = [];
    }
}
