using CQRS.TutorialApp.CQRS.Queries;
using CQRS.TutorialApp.CQRS.Results;
using CQRS.TutorialApp.Data.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS.TutorialApp.CQRS.Handlers
{
    public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery,IEnumerable<GetStudentsQueryResult>>
    {
        private readonly AppDbContext _context;

        public GetStudentsQueryHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<GetStudentsQueryResult>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _context.Students.Select(x => new GetStudentsQueryResult
            {
                Name = x.Name,
                Surname = x.Surname
            }).ToListAsync();
        }
    }
}
