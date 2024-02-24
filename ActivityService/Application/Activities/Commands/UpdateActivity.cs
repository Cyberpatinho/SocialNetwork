using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Activities.Commands
{
    public class UpdateActivity
    {
        public class Command : IRequest
        {
            public UpdateActivityDto Dto { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ActivityContext _context;
            private readonly IMapper _mapper;

            public Handler(ActivityContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var activity = await _context.Activities.FindAsync(request.Dto.Id);

                if (activity == null)
                {
                    throw new Exception("Invalid activity id.");
                }

                _mapper.Map(request.Dto, activity);

                await _context.SaveChangesAsync();
            }
        }
    }
}
