using System.Web.Http.Filters;

namespace ShoeStore.Infrastructure
{
    public class OrderedActionFilterAttribute : ActionFilterAttribute, IOrderAttribute
    {
        public int Order { get; set; }

        public OrderedActionFilterAttribute()
        {
            Order = 0;
        }
        public OrderedActionFilterAttribute(int positon)
        {
            Order = positon;
        }
    }
}
