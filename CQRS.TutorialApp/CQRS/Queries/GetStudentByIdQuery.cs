using CQRS.TutorialApp.CQRS.Results;
using MediatR;

namespace CQRS.TutorialApp.CQRS.Queries
{
    public class GetStudentByIdQuery : IRequest<GetStudentByIdQueryResult>
    {
        public int Id { get; set; }

        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
