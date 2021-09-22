﻿using Grader.Api.Business.Enums;
using Grader.Api.Data.Context;
using Grader.Api.Data.QueryBuilders;
using Mapster;
using MediatR;
using Newtonsoft.Json;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Grader.Api.Business.Commands
{
    public static class CategoryUpdate
    {
        // command
        public record Command([property:JsonIgnore] long Id, string Name) : IRequest<UpdateCommandResult>;

        // handler
        public class Handler : IRequestHandler<Command, UpdateCommandResult>
        {
            public Handler(GraderDbContext dbContext)
            {
                _dbContext = dbContext;
            }

            private readonly GraderDbContext _dbContext;


            public async Task<UpdateCommandResult> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = _dbContext.Categories.WhereId(request.Id).SingleOrDefault();
                if (entity == null) return UpdateCommandResult.NotFound;

                request.Adapt(entity);

                await _dbContext.SaveChangesAsync(cancellationToken);

                return UpdateCommandResult.Ok;
            }
        }
    }
}
