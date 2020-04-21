using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Rest.Courses.Controllers
{
    public class BaseController: Controller
    {
        private IMediator mediator;
         protected IMediator _mediator => mediator ?? (mediator = HttpContext.RequestServices.GetService<IMediator>());
    }
}