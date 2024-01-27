using CQRS.TutorialApp.CQRS.Commands;
using CQRS.TutorialApp.CQRS.Results;
using CQRS.TutorialApp.Data.Context;
using CQRS.TutorialApp.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.TutorialApp.CQRS.Handlers
{
    public class UpdateOneStudentCommandHandler : IRequestHandler<UpdateOneStudentCommand,UpdateOneStudentCommandResult>
    {
        private readonly AppDbContext _context;

        public UpdateOneStudentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

     

        public async Task<UpdateOneStudentCommandResult> Handle(UpdateOneStudentCommand request, CancellationToken cancellationToken)
        {
            var currentEntity = await _context.Set<Student>().Where(x => x.Id.Equals(request.Id)).SingleOrDefaultAsync();

            if(currentEntity != null)
            {
                currentEntity.Name = request.Name;
                currentEntity.Surname = request.Surname;
                currentEntity.Age = request.Age;

                
            }
            await _context.SaveChangesAsync();


            return new UpdateOneStudentCommandResult
            {
                Id = currentEntity!.Id,
                Name = currentEntity.Name,
                Surname = currentEntity.Surname,
                Age = currentEntity.Age
            };


            
        }
    }
}
