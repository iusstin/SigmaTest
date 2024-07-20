using MediatR;

namespace ApplicationCore.BaseClasses;

public class BaseQuery<TResponse> : IRequest<TResponse>
{ }
