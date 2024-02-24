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
    public class CreateActivity : IRequest
    {
    
        public class Command : IRequest
        { 
            public CreateActivityDto Dto { get; set; }
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
                var activity = _mapper.Map<Activity>(request.Dto);

                _context.Activities.Add(activity);

                await _context.SaveChangesAsync();  
            }
        }
    }
}
