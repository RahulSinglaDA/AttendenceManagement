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
    public class StudentRequestHandler : IRequestHandler<Request<Student>, Response<Student>>
    {
        private readonly IRepository<Student> repository;
        public StudentRequestHandler(IRepository<Student> repository)
        {
            this.repository = repository;
        }
        public Task<Response<Student>> Handle(Request<Student> request, CancellationToken cancellationToken)
        {
            BaseRequestHandler<Student> genericRequestHandler = new BaseRequestHandler<Student>(repository);
            return genericRequestHandler.Handle(request, cancellationToken);
        }
    }
}
