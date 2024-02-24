using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Queries
{
    public class GetActivities
    {
        public class Query : IRequest<List<Activity>> { }

        public class Handler : IRequestHandler<Query, List<Activity>>
        {
            private readonly ActivityContext _context;

            public Handler(ActivityContext context)
            {
                _context = context;
            }

            public async Task<List<Activity>> Handle(Query request, CancellationToken cancellationToken)
            {
                var activities = await _context.Activities.ToListAsync();

                return activities;
            }
        }
    }
}
