using DBManager.Repositories;
using ManagementSystem.Handlers.Request;
using ManagementSystem.Handlers.Response;
using ManagementSystem.Models.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ManagementSystem.Handlers.Handlers
{
    public class StandardRequestHandler : IRequestHandler<Request<Standard>, Response<Standard>>
    {
        private readonly IRepository<Standard> repository;
        public StandardRequestHandler(IRepository<Standard> repository)
        {
            this.repository = repository;
        }
        public Task<Response<Standard>> Handle(Request<Standard> request, CancellationToken cancellationToken)
        {
            BaseRequestHandler<Standard> genericRequestHandler = new BaseRequestHandler<Standard>(repository);
            return genericRequestHandler.Handle(request, cancellationToken);
        }
    }
}
