using MediatR;
using WebApp.Business.Queries;
using WebApp.Business.Responses;
using WebApp.Data.Entities;
using WebApp.Data.Repositories.Abstract;

namespace WebApp.Business.Handlers
{
    public class GetSampleByIdHandler : IRequestHandler<GetSampleByIdQuery, ServiceResponse>
    {
        private readonly IReadOnlyRepository<Sample> repository;

        public GetSampleByIdHandler(IReadOnlyRepository<Sample> repository)
        {
            this.repository = repository;
        }

        public async Task<ServiceResponse> Handle(GetSampleByIdQuery request, CancellationToken cancellationToken)
        {
            var sample = await repository.GetSingleAsync(x => x.Id == request.Id);

            return ServiceResponse.CreateSuccess(string.Empty, sample);
        }
    }
}