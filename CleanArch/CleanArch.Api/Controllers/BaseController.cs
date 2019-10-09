using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Api.Controllers
{
    
        public abstract class BaseController : ControllerBase
        {
            private IMediator _mediator;

            protected IMediator Mediator => _mediator ?? HttpContext.RequestServices.GetService<IMediator>();

        }
    
}
