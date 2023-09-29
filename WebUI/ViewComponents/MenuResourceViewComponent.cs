using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wbc.Application.Common.Interfaces;
using Wbc.Application.MenuResource.Query.GetMenuResource;

namespace Wbc.WebUI.ViewComponents
{
    public class MenuResourceViewComponent : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;

        public MenuResourceViewComponent(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        public IViewComponentResult Invoke()
        {

            var menuResourceVm = _mediator.Send(new GetMenuResourceQuery { UserId = _currentUserService.GetUserId() }).Result;

            return View(menuResourceVm);
        }
    }
}
