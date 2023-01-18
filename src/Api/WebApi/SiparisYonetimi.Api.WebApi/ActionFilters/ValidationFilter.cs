﻿using Microsoft.AspNetCore.Mvc.Filters;

namespace SiparisYonetimi.Api.WebApi.ActionFilters
{
    public class ValidationFilter : ActionFilterAttribute
    {
        public async override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var message = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => !string.IsNullOrEmpty(x.ErrorMessage) ? x.ErrorMessage : x.Exception?.Message).Distinct().ToList();
                return;
            }
            await next();
        }
    }
}
