using ShoeStore.Persistence;
using System.Linq;
using System.Web.Http;

namespace ShoeStore.Controllers.Api
{
    public class StoresController : ApiController
    {
        public IHttpActionResult GetStores()
        {
            var stores = new ShoeStoreDbContext().Stores.ToList();
            return Ok(new
            {
                Stores = stores,
                Success = true,
                total_elements = stores.Count
            });
        }
    }
}
