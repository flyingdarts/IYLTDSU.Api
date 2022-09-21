using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IYLTDSU.Backend.LambdaApi.Controllers;

[ApiController]
public class BaseController : ControllerBase
{
    protected IMapper Mapper => HttpContext.RequestServices.GetRequiredService<IMapper>();
    protected IMediator Mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();

    protected async Task<TApplicationResponse> Execute<TApplicationRequest, TApplicationResponse, TBusinessRequest>(TApplicationRequest request, CancellationToken cancellationToken) where TApplicationResponse : new()
    {
        var businessRequest = Mapper.Map<TApplicationRequest, TBusinessRequest>(request);

        var businessResponse = await Mediator.Send(businessRequest, cancellationToken);

        var applicationResponse = Mapper.Map(businessResponse, new TApplicationResponse());

        return applicationResponse;
    }
}
