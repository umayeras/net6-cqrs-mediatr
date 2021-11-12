using MediatR;
using WebApp.Business.Responses;

namespace WebApp.Business.Commands
{
    public class AddSampleCommand : IRequest<ServiceResponse>
    {
        public string Title { get; set; }
        public string Detail { get; set; }

        public AddSampleCommand(string title, string detail)
        {
            Title = title;
            Detail = detail;
        }
    }
}