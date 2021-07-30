using ManagementSystem.Handlers.Request;
using ManagementSystem.Handlers.Response;
using ManagementSystem.Models.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ManagementSystem.Helpers
{
    public class Helper<T>
    {
        public static async Task<Response<T>> SendRequestAsync(IMediator mediator, RequestType reqType, T value, int id = 0)
        {
            try
            {
                Request<T> req = Request<T>.CreateRequest();
                req.Type = reqType;
                req.ID = id;
                req.Entity = value;
                return await mediator.Send(req);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

    }
}
