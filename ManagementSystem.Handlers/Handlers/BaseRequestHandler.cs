using DBManager.Repositories;
using ManagementSystem.Models.Enums;
using ManagementSystem.Handlers.Request;
using ManagementSystem.Handlers.Response;
using System.Threading;
using System.Threading.Tasks;

namespace ManagementSystem.Handlers.Handlers
{
    public class BaseRequestHandler<T> 
    {
        private readonly IRepository<T> repository;
        public BaseRequestHandler(IRepository<T> repository)
        {
            this.repository = repository;
        }
        public Task<Response<T>> Handle(Request<T> request, CancellationToken cancellationToken)
        {
            Response<T> res = new Response<T>();
            if (request.Type == RequestType.GetAll)
            {
                res.Entity = repository.GetAll();
            }
            else if (request.Type == RequestType.Get)
            {
                res.Entity = repository.Get(request.ID);
            }
            else if (request.Type == RequestType.Add)
            {
                repository.Add(request.Entity);
            }
            else if (request.Type == RequestType.Update)
            {
                repository.Update(request.ID, request.Entity);
            }
            else if (request.Type == RequestType.Delete)
            {
                repository.Delete(request.ID);
            }
            return Task.FromResult(res);
        }
    }
}
