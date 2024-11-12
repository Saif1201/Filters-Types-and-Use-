using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPractice.Filters
{
    public class MyExceptionFilter : IExceptionFilter
    {
        private readonly ILogger<MyExceptionFilter> _logger;
        private readonly IHostEnvironment _hostEnvironment;

        public MyExceptionFilter(ILogger<MyExceptionFilter> logger, IHostEnvironment hostEnvironment)
        {
            _logger = logger;
            _hostEnvironment = hostEnvironment;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError("Filter Name : {}\n" +
                " Filter Method : {}\n" +
                " Exception Type : {}\n" +
                " Exception Time : {}\n" +
                " Exception Message : {}",
                nameof(MyExceptionFilter),
                nameof(OnException),
                context.Exception.GetType().ToString(),
                DateTime.Now.ToString("dd MM yyyy H:mm:ss"),
                context.Exception.Message
            );

            if (_hostEnvironment.IsDevelopment() || _hostEnvironment.IsStaging())
            {
                context.Result = new ContentResult()
                {
                    Content = context.Exception.Message
                };
            }
            else
            {
                context.Result = new ContentResult()
                {
                    Content = "Apne kaam se kaam rakh............"
                };
            }

        }
    }
}
