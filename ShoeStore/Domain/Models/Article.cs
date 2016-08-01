namespace ShoeStore.Domain.Models
{
    public class Article
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Desription { get; set; }

        public decimal Price { get; set; }

        public int TotalInShelf { get; set; }

        public int TotalInVault { get; set; }

        public int StoreId { get; set; }
        public Store Store { get; set; }
    }
}