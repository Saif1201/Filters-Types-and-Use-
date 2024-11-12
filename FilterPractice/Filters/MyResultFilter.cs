using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPractice.Filters
{
    public class MyResultFilter : IResultFilter
    {
        private readonly ILogger<MyResultFilter> _logger;

        public MyResultFilter(ILogger<MyResultFilter> logger)
        {
            _logger = logger;
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _logger.LogInformation("From OnResultExecuting --------");

            context.HttpContext.Response.Headers.Add("X-CUSTOM-KEY", "X-COSTOM-VALUE");
            context.HttpContext.Response.Headers["X-DOB"] = new DateTime(1993, 12, 10).ToString();
            context.HttpContext.Response.Headers["X-CurrentdateTime"] = DateTime.Now.ToString("yyyy MM dd H:mm:ss");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            _logger.LogInformation("From OnResultExecuted");
        }
    }
}
