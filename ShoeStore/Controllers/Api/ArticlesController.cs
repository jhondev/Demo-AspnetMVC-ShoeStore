using ShoeStore.Infrastructure;
using ShoeStore.Persistence;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace ShoeStore.Controllers.Api
{
    public class ArticlesController : ApiController
    {
        private readonly ShoeStoreDbContext _context;

        public ArticlesController()
        {
            _context = new ShoeStoreDbContext();
        }

        public IHttpActionResult GetArticles()
        {
            var articles = _context.Articles
                .Select(a => new
                {
                    a.Id,
                    a.Description,
                    a.Name,
                    a.Price,
                    total_in_shelf = a.TotalInShelf,
                    total_in_vault = a.TotalInVault,
                    store_name = a.Store.Name
                }).ToList();

            return Ok(new
            {
                Articles = articles,
                Success = true,
                total_elements = articles.Count
            });
        }

        [ValidateModel]
        [HttpGet]
        [Route("services/articles/stores/{storeId}")]
        public IHttpActionResult GetStoreArticles(int storeId)
        {
            if (!_context.Stores.Any(s => s.Id == storeId))
                return new ErrorResult(Request, "Record not Found", HttpStatusCode.NotFound);

            var articles = _context.Articles
                .Where(a=>a.StoreId == storeId)
                .Select(a => new
                {
                    a.Id,
                    a.Description,
                    a.Name,
                    a.Price,
                    total_in_shelf = a.TotalInShelf,
                    total_in_vault = a.TotalInVault,
                    store_name = a.Store.Name
                }).ToList();

            return Ok(new
            {
                Articles = articles,
                Success = true,
                total_elements = articles.Count
            });
        }
    }
}
