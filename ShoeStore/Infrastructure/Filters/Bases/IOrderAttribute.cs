using System.Web.Http.Filters;

namespace ShoeStore.Infrastructure
{
    public interface IOrderAttribute : IFilter
    {
        int Order { get; set; }
    }
}
