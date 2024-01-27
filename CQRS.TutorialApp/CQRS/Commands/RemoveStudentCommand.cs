using CQRS.TutorialApp.CQRS.Results;
using MediatR;

namespace CQRS.TutorialApp.CQRS.Commands
{
    public class RemoveStudentCommand : IRequest<RemoveStudentCommandResult>
    {
        public int Id { get; set; }
        public RemoveStudentCommand(int id)
        {
            Id = id;

        }
    }
}
