using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repos.Abstract;
using WebApi.Responses;

namespace WebApi.Filters
{
    public class UserExistsFilter : Attribute, IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // я знаю только такой способ получения сервиса в фильтре. Иньекция через конструктор - это конечно хорошо,
            // но тогда при вызове аттрибута мне придется передать объект внешнего сервиса в конструктор
            // аттрибута. А это уже не очень. Я имею ввиду [UserExistsFilter(?????)]
            var userRepository = context.HttpContext.RequestServices.GetService<IUserRepository>();
            var id = context.HttpContext.GetRouteValue("id");

            var anyJobs = await userRepository.All.AnyAsync(x => x.Id == Convert.ToInt32(id));

            if (anyJobs)
            {
                await next();
            }
            else
            {
                context.Result = new NotFoundObjectResult(new HttpResponse(ResponseStatus.Error,"User not found"));
            }
        }
    }
}