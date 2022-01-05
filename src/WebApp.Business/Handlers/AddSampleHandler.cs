using MediatR;
using WebApp.Business.Commands;
using WebApp.Business.Constants;
using WebApp.Business.Responses;
using WebApp.Data.Entities;
using WebApp.Data.Repositories.Abstract;

namespace WebApp.Business.Handlers;

public class AddSampleHandler : IRequestHandler<AddSampleCommand, ServiceResponse>
{
    private readonly IWritableRepository<Sample> repository;

    public AddSampleHandler(IWritableRepository<Sample> repository)
    {
        this.repository = repository;
    }

    public async Task<ServiceResponse> Handle(AddSampleCommand request, CancellationToken cancellationToken)
    {
        var sample = new Sample(request.Title, request.Detail);
        var result = await repository.AddAsync(sample);

        return result != null
            ? ServiceResponse.CreateError(ResponseMessage.AddedFailed)
            : ServiceResponse.CreateSuccess(ResponseMessage.AddedSuccessfully);
    }
}