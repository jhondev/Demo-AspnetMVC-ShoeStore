using ShoeStore.Domain.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ShoeStore.Domain.ViewModels
{
    public class ArticleViewModel
    {
        public IEnumerable<Article> Articles
        {
            get { return new Persistence.ShoeStoreDbContext().Articles.Include(a => a.Store).ToList(); }
        }
    }
}