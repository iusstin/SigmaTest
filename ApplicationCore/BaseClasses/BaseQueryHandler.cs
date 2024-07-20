using MediatR;

namespace ApplicationCore.BaseClasses;

public abstract class BaseQueryHandler<TRequest, TResponse>
    : IRequestHandler<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    public BaseQueryHandler(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected IMediator Mediator { get; private set; }
    public abstract Task<TResponse> Handle(TRequest cmd, CancellationToken cancellationToken);
}
