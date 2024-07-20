using MediatR;

namespace ApplicationCore.BaseClasses;

public abstract class BaseCommandHandler<TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    public BaseCommandHandler(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected IMediator Mediator { get; private set; }
    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}
