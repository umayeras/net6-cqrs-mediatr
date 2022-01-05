using MediatR;
using Microsoft.EntityFrameworkCore;
using WebApp.Business.Queries;
using WebApp.Business.Responses;
using WebApp.Data.Entities;
using WebApp.Data.Repositories.Abstract;

namespace WebApp.Business.Handlers;

public class GetSamplesHandler : IRequestHandler<GetSamplesQuery, ServiceResponse>
{
    private readonly IReadOnlyRepository<Sample> repository;

    public GetSamplesHandler(IReadOnlyRepository<Sample> repository)
    {
        this.repository = repository;
    }

    public async Task<ServiceResponse> Handle(GetSamplesQuery request, CancellationToken cancellationToken)
    {
        var samples = await repository.GetAsync(
            predicate: null,
            orderBy: o => o.OrderBy(x => x.Order),
            tracking: false,
            includes: i => i.Include(s => s.Status)
        );

        return ServiceResponse.CreateSuccess(string.Empty, samples);
    }
}