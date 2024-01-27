using CQRS.TutorialApp.CQRS.Results;
using MediatR;

namespace CQRS.TutorialApp.CQRS.Commands
{
    public class UpdateOneStudentCommand : IRequest<UpdateOneStudentCommandResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
    }
}
