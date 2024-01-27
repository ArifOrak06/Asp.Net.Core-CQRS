using CQRS.TutorialApp.CQRS.Queries;
using CQRS.TutorialApp.CQRS.Results;
using CQRS.TutorialApp.Data.Context;
using CQRS.TutorialApp.Models;
using MediatR;

namespace CQRS.TutorialApp.CQRS.Handlers
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery,GetStudentByIdQueryResult>
    {
        private readonly AppDbContext _context;

        public GetStudentByIdQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetStudentByIdQueryResult> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            Student? currentStudent = await _context.Set<Student>().FindAsync(request.Id);
            return new GetStudentByIdQueryResult
            {
                Age = currentStudent!.Age,
                Name = currentStudent.Name,
                Surname = currentStudent.Surname
            };
        }
    }
}
