namespace Practise.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual IList<Product> Products { get; set; } = new List<Product>();
    }
}
