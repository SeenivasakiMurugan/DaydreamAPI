using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Daydream.Filters
{
    public class AppException : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var actionName = ((ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controllerName = ((ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            WriteLog(actionName, controllerName, context.Exception);
            context.Result = new ObjectResult(new StringContent("An internal error occurred."))
            {
                StatusCode = (int)HttpStatusCode.InternalServerError,
            };
            context.ExceptionHandled = true;
        }

        public void WriteLog(string actionName, string controllerName, Exception exception)
        {
            string monthYear = DateTime.Now.ToString("MMyyyy");
            string day = DateTime.Now.ToString("yyyyMMdd");
            var filePath = Path.Combine("logs", monthYear, day, $"{controllerName}.txt");

            var logDir = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(logDir))
            {
                Directory.CreateDirectory(logDir);
            }

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"Time : {DateTime.Now:HH:mm:ss}");
                writer.WriteLine($"---------------------------------------");
                writer.WriteLine($"Action name : { actionName }");
                writer.WriteLine($"Error Message : { exception.Message }");
                writer.WriteLine("Stack trace : ");
                writer.WriteLine(exception.StackTrace);
                writer.WriteLine();
            }
        }
    }
}
