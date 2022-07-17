using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PhoneBook.Core.DTOs;
using PhoneBook.Core.Models;
using PhoneBook.Core.Services;

namespace PhoneBook.Web.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IGenericService<T> _genericService;

        public NotFoundFilter(Core.Services.IGenericService<T> genericService)
        {
            _genericService = genericService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }
            var id = (int)idValue;

            var anyEntity = await _genericService.AnyAsync(x => x.Id == id);
            if (anyEntity)
            {
                await next.Invoke();
                return;
            }

            var errorViewModel = new ErrorViewModel();
            errorViewModel.Errors.Add($"{typeof(T).Name} ({id}) not found");

            context.Result = new RedirectToActionResult("Error", "Home", errorViewModel);

        }
    }
}
