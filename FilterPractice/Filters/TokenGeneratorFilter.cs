using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPractice.Filters
{
    public class TokenGeneratorFilter : IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
            
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Response.Cookies.Append("AUTH-KEY","ABC123");
        }
    }
}
