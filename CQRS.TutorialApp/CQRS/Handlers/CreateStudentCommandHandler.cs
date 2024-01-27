using CQRS.TutorialApp.CQRS.Commands;
using CQRS.TutorialApp.CQRS.Results;
using CQRS.TutorialApp.Data.Context;
using CQRS.TutorialApp.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.TutorialApp.CQRS.Handlers
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand,CreateStudentCommandResult>
    {
        private readonly AppDbContext _context;

        public CreateStudentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

      

        public async Task<CreateStudentCommandResult> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            await _context.Set<Student>().AddAsync(new Student()
            {
                Name = request.Name,
                Age = request.Age,
                Surname = request.Surname,
            });
            await _context.SaveChangesAsync();

            Student? currentStudent = await _context.Set<Student>().Where(x => x.Name == request.Name && x.Surname == request.Surname).FirstOrDefaultAsync();
            return new CreateStudentCommandResult
            {
                Id = currentStudent.Id,
                Name = currentStudent.Name
            };
        }
    }
}
