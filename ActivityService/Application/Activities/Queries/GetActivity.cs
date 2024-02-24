using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Buffers;

namespace Application.Activities.Queries
{
    public class GetActivity
    {
        public class Query : IRequest<Activity>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Activity>
        {
            private readonly ActivityContext _context;

            public Handler(ActivityContext context)
            {
                _context = context;
            }

            public async Task<Activity> Handle(Query request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.Where(x => x.Id == request.Id).FirstOrDefaultAsync();

                return activity;
            }
        }
    }
}
