using MediatR;

namespace ApplicationCore.BaseClasses;

public class BaseCommand<TResponse> : IRequest<TResponse>
{ }
