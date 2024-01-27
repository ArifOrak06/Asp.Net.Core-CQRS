using CQRS.TutorialApp.CQRS.Results;
using MediatR;

namespace CQRS.TutorialApp.CQRS.Queries
{
    public class GetStudentsQuery : IRequest<IEnumerable<GetStudentsQueryResult>>
    {

    }
}
