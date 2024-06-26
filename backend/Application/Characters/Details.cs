using Domain;
using MediatR;
using Persistence;

namespace Application.Characters
{
    public class Details
    {
        public class Query : IRequest<Character>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Character>
        {
        private readonly DataContext _context;
            public Handler(DataContext context)
            {
                 _context = context;
            }
            public async Task<Character> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Characters.FindAsync(request.Id);
            }
        }
    }
}