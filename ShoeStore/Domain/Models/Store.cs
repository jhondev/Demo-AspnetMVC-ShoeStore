using System.Collections.Generic;

namespace ShoeStore.Domain.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }

        public ICollection<Article> Articles { get; set; }
    }
}