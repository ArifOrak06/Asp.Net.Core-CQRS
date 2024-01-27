using CQRS.TutorialApp.CQRS.Commands;
using CQRS.TutorialApp.CQRS.Results;
using CQRS.TutorialApp.Data.Context;
using CQRS.TutorialApp.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.TutorialApp.CQRS.Handlers
{
    public class RemoveStudentCommandHandler :IRequestHandler<RemoveStudentCommand,RemoveStudentCommandResult>
    {
        private readonly AppDbContext _context;

        public RemoveStudentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<RemoveStudentCommandResult> Handle(RemoveStudentCommand request, CancellationToken cancellationToken)
        {
            var removedEntity = await _context.Set<Student>().Where(x => x.Id == request.Id).FirstOrDefaultAsync();
            if (removedEntity is not null)
            {
                _context.Set<Student>().Remove(removedEntity);
                await _context.SaveChangesAsync();
            }
            return new RemoveStudentCommandResult
            {
                Id = request.Id,

            };
        }
    }
}
