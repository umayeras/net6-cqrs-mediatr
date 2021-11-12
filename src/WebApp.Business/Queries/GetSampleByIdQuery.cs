using MediatR;
using WebApp.Business.Responses;

namespace WebApp.Business.Queries
{
    public class GetSampleByIdQuery : IRequest<ServiceResponse>
    {
        public int Id { get; set; }

        public GetSampleByIdQuery(int id)
        {
            Id = id;
        }
    }
}