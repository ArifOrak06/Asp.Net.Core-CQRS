using CQRS.TutorialApp.CQRS.Results;
using MediatR;

namespace CQRS.TutorialApp.CQRS.Commands
{
    public class CreateStudentCommand : IRequest<CreateStudentCommandResult>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
