using FilterPractice.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FilterPractice.Filters
{
    public class EmployeeListActionFilter : IActionFilter
    {
        private readonly ILogger<EmployeeListActionFilter> _logger;

        public EmployeeListActionFilter(ILogger<EmployeeListActionFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
          {
            if (context.ActionArguments.ContainsKey(nameof(Employee.Name)))
            {
                var name = Convert.ToString(context.ActionArguments[nameof(Employee.Name)]);

                if(!string.IsNullOrEmpty(name))
                {
                    context.ActionArguments[nameof(Employee.Name)] = name.TrimEnd('0');
                }
            }

            _logger.LogWarning("From OnActionExecuting$$$$$$$$--------");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation("From OnActionExecuted--------$$$$$$$$");
        }
    }
}
